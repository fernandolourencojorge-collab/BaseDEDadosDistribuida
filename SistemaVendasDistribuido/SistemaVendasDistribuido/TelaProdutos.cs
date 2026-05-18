using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SistemaVendasDistribuido
{
    public partial class TelaProdutos : Form
    {
        private string stringConexaoGlobal;

        // Recebe a conexão que vem do Menu Principal
        public TelaProdutos(string conexaoRecebida)
        {
            InitializeComponent();
            stringConexaoGlobal = conexaoRecebida; //  Guardar a conexão na variável!
        }

        private void btnSalvarProduto_Click(object sender, EventArgs e)
        {
            // Validação simples dos campos
            if (string.IsNullOrEmpty(txtNomeProduto.Text) || string.IsNullOrEmpty(txtPrecoProduto.Text) || string.IsNullOrEmpty(txtStockProduto.Text))
            {
                MessageBox.Show("Todos os campos (Nome, Preço e Stock) são obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conexao = new SqlConnection(stringConexaoGlobal))
            {
                try
                {
                    conexao.Open();
                    string query = "INSERT INTO Produtos (Nome, Preco, Stock) VALUES (@nome, @preco, @stock)";

                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        // Passagem dos parâmetros com conversão correta de tipos
                        comando.Parameters.AddWithValue("@nome", txtNomeProduto.Text);
                        comando.Parameters.AddWithValue("@preco", decimal.Parse(txtPrecoProduto.Text));
                        comando.Parameters.AddWithValue("@stock", int.Parse(txtStockProduto.Text));

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Produto cadastrado com sucesso na base de dados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // FLUXO AUTOMÁTICO: Fecha esta tela sozinho para o Menu abrir a Tela de Vendas!
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar produto no SQL Server: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAtualizarStockPreco_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeProduto.Text) || string.IsNullOrEmpty(txtNomeProduto.Text) || string.IsNullOrEmpty(txtPrecoProduto.Text))
            {
                MessageBox.Show("Por favor, preencha o ID, o Nome e o Preço para atualizar o produto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Query SQL que atualiza os dados baseando-se no ID_Produto
            string query = "UPDATE Produtos SET Nome_Produto = @nome, Preco = @preco, Estoque = @estoque WHERE ID_Produto = @id";

            using (SqlConnection conexao = new SqlConnection(stringConexaoGlobal))
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, conexao);

                    // Passar os parâmetros convertendo os números corretamente
                    comando.Parameters.AddWithValue("@id", txtNomeProduto.Text.Trim());
                    comando.Parameters.AddWithValue("@nome", txtNomeProduto.Text.Trim());
                    comando.Parameters.AddWithValue("@preco", decimal.Parse(txtPrecoProduto.Text.Trim())); // Converte para número com vírgula
                    comando.Parameters.AddWithValue("@estoque", int.Parse(txtStockProduto.Text.Trim())); // Converte para número inteiro

                    conexao.Open();
                    int linhasAfetadas = comando.ExecuteNonQuery();

                    // Verificar se o ID existia no banco
                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Produto atualizado com sucesso no stock!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpar campos
                        txtNomeProduto.Clear();
                        txtNomeProduto.Clear();
                        txtPrecoProduto.Clear();
                        txtStockProduto.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Não foi encontrado nenhum produto com esse ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de Base de Dados ao atualizar produto: " + ex.Message, "Erro SQL");
                }
            }
    }

        private void btnRemoverCatalago_Click(object sender, EventArgs e)
        {
            //Validar se o ID foi digitado
    if (string.IsNullOrEmpty(txtNomeProduto.Text))
            {
                MessageBox.Show("Por favor, introduza o ID do produto que deseja eliminar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Caixa de diálogo
            DialogResult confirmacao = MessageBox.Show("Tens a certeza que desejas remover este produto permanentemente do stock?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                string query = "DELETE FROM Produtos WHERE ID_Produto = @id";

                using (SqlConnection conexao = new SqlConnection(stringConexaoGlobal))
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand(query, conexao);
                        comando.Parameters.AddWithValue("@id", txtNomeProduto.Text.Trim());

                        conexao.Open();
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Produto removido do catálogo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Limpar todos os campos
                            txtNomeProduto.Clear();
                            txtNomeProduto.Clear();
                            txtPrecoProduto.Clear();
                            txtStockProduto.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Não foi encontrado nenhum produto com esse ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro de Base de Dados ao eliminar produto: " + ex.Message, "Erro SQL");
                    }
                }
    }
}

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


