using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Obrigatório para comunicar com o SQL Server

namespace SistemaVendasDistribuido
{
    public partial class TelaVendas : Form
    {
        private string minhaStringConexao;
        private string utilizadorSistema;

        public TelaVendas()
        {
            InitializeComponent();
        }

        public TelaVendas(string conexaoRecebida, string utilizadorRecebido)
        {
            InitializeComponent();
            minhaStringConexao = conexaoRecebida;
            utilizadorSistema = utilizadorRecebido;
        }

        private void TelaVendas_Load_1(object sender, EventArgs e)
        {
            txtQuantidade.Text = "1";

            // Carregar os Clientes na ComboBox e os Produtos na DataGridView
            CarregarClientesBanco();
            CarregarProdutosGrelha();
        }
        private void CarregarClientesBanco()
        {
            cbClientes.Items.Clear();
            using (SqlConnection conexao = new SqlConnection(minhaStringConexao))
            {
                try
                {
                    conexao.Open();
                    string query = "SELECT ClienteID, Nome FROM Clientes";
                    using (SqlCommand cmd = new SqlCommand(query, conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbClientes.Items.Add(reader["ClienteID"].ToString() + " - " + reader["Nome"].ToString());
                            }
                        }
                    }
                    if (cbClientes.Items.Count > 0) cbClientes.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CarregarProdutosGrelha()
        {
            using (SqlConnection conexao = new SqlConnection(minhaStringConexao))
            {
                try
                {
                    conexao.Open();
                    string query = "SELECT ProdutoID, Nome, Preco, Stock FROM Produtos";

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(query, conexao))
                    {
                        DataTable tabelaProdutos = new DataTable();
                        adaptador.Fill(tabelaProdutos);

                        // Associar a tabela do SQL diretamente à DataGridView
                        dgProdutos.DataSource = tabelaProdutos;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a tabela de produtos: " + ex.Message, "Erro Grelha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            // Validação: Verificar se o utilizador selecionou alguma linha na DataGridView
            if (dgProdutos.CurrentRow == null || cbClientes.SelectedItem == null || string.IsNullOrEmpty(txtQuantidade.Text))
            {
                MessageBox.Show("Selecione o Cliente, clique num Produto da tabela e defina a Quantidade!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Extrair o ID do cliente da ComboBox
                string itemCliente = cbClientes.SelectedItem.ToString();
                int clienteID = int.Parse(itemCliente.Split('-')[0].Trim());

                // NOVO: Extrai o ID e o Preço DIRETAMENTE da linha selecionada na DataGridView!
                int produtoID = Convert.ToInt32(dgProdutos.CurrentRow.Cells["ProdutoID"].Value);
                decimal precoProduto = Convert.ToDecimal(dgProdutos.CurrentRow.Cells["Preco"].Value);
                int stockAtual = Convert.ToInt32(dgProdutos.CurrentRow.Cells["Stock"].Value);

                int quantidadeVendida = int.Parse(txtQuantidade.Text);

                // Validação local de stock antes de abrir a transação
                if (quantidadeVendida > stockAtual)
                {
                    MessageBox.Show($"Stock insuficiente! Apenas temos {stockAtual} unidades disponíveis.", "Aviso Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal totalVenda = precoProduto * quantidadeVendida;

                //Processo Transacional Mestre-Detalhe com COMMIT e ROLLBACK
                using (SqlConnection conexao = new SqlConnection(minhaStringConexao))
                {
                    conexao.Open();
                    using (SqlTransaction transacao = conexao.BeginTransaction())
                    {
                        using (SqlCommand comando = conexao.CreateCommand())
                        {
                            comando.Transaction = transacao;

                            try
                            {
                                // Inserir Cabeçalho da Venda 
                                comando.CommandText = "INSERT INTO Vendas (Utilizador, ClienteID, Total) VALUES (@user, @cliente, @total); SELECT SCOPE_IDENTITY();";
                                comando.Parameters.AddWithValue("@user", utilizadorSistema); 
                                comando.Parameters.AddWithValue("@cliente", clienteID);
                                comando.Parameters.AddWithValue("@total", totalVenda);

                                int novaVendaID = Convert.ToInt32(comando.ExecuteScalar());

                                //  Inserir Item da Venda 
                                comando.Parameters.Clear();
                                comando.CommandText = "INSERT INTO ItensVenda (VendaID, ProdutoID, Quantidade, Subtotal) VALUES (@venda, @prod, @qtd, @sub);";
                                comando.Parameters.AddWithValue("@venda", novaVendaID);
                                comando.Parameters.AddWithValue("@prod", produtoID);
                                comando.Parameters.AddWithValue("@qtd", quantidadeVendida);
                                comando.Parameters.AddWithValue("@sub", totalVenda);
                                comando.ExecuteNonQuery();

                                // Simular Regra para demonstrar o Rollback 
                                if (quantidadeVendida > 10)
                                {
                                    throw new Exception("Erro de Simulação: Venda superior a 10 unidades exige validação manual!");
                                }

                                //  Atualizar o Stock 
                                comando.Parameters.Clear();
                                comando.CommandText = "UPDATE Produtos SET Stock = Stock - @qtd WHERE ProdutoID = @prod;";
                                comando.Parameters.AddWithValue("@qtd", quantidadeVendida);
                                comando.Parameters.AddWithValue("@prod", produtoID);
                                comando.ExecuteNonQuery();

                                
                                transacao.Commit();
                                MessageBox.Show("Venda Finalizada com Sucesso usando a DataGridView!\nCOMMIT efetuado no SQL Server.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.Close(); // fech0 automático
                            }
                            catch (Exception ex)
                            {
                                transacao.Rollback(); // Desfaz tudo
                                MessageBox.Show("A Transação Falhou!\nMotivo: " + ex.Message + "\n\nO ROLLBACK foi executado com sucesso!", "Erro - Rollback", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar dados da tabela: " + ex.Message, "Erro Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}