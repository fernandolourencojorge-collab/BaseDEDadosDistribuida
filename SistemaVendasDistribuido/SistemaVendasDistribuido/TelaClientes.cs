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
    public partial class TelaClientes : Form
    {
        private string stringConexaoGlobal;
        public TelaClientes(string conexaoRecebida)
        {

            InitializeComponent();
            stringConexaoGlobal = conexaoRecebida;
            }
        

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            // Validação simples
            if (string.IsNullOrEmpty(txtNomeCliente.Text) || string.IsNullOrEmpty(txtBI.Text))
            {
                MessageBox.Show("Nome e BI são obrigatórios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conexao = new SqlConnection(stringConexaoGlobal))
            {
                try
                {
                    conexao.Open();
                    string query = "INSERT INTO Clientes (Nome, Telefone, BI) VALUES (@nome, @tel, @bi)";

                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", txtNomeCliente.Text);
                        comando.Parameters.AddWithValue("@tel", txtTelefone.Text);
                        comando.Parameters.AddWithValue("@bi", txtBI.Text);

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Cliente registado com sucesso na BD_Vendas!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        // Limpar campos
                        txtNomeCliente.Clear();
                        txtTelefone.Clear();
                        txtBI.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar cliente: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Validar se o utilizador digitou o BI, o Nome e o Telefone
            if (string.IsNullOrEmpty(txtBI.Text) || string.IsNullOrEmpty(txtNomeCliente.Text) || string.IsNullOrEmpty(txtTelefone.Text))
            {
                MessageBox.Show("Por favor, preencha o BI, o Nome e o Telefone para atualizar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Clientes SET Nome = @Nome, Telefone = @Telefone WHERE BI = @BI";

            using (SqlConnection conexao = new SqlConnection(stringConexaoGlobal))
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, conexao);

                    // Passamos os dados das TextBoxes para os parâmetros do SQL
                    comando.Parameters.AddWithValue("@BI", txtBI.Text.Trim()); 
                    comando.Parameters.AddWithValue("@Nome", txtNomeCliente.Text.Trim()); 
                    comando.Parameters.AddWithValue("@Telefone", txtTelefone.Text.Trim()); 

                    conexao.Open();
                    int linhasAfetadas = comando.ExecuteNonQuery();

                
                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Dados do cliente atualizados com sucesso através do BI!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpa as caixas de texto após o sucesso
                        txtBI.Clear();
                        txtNomeCliente.Clear();
                        txtTelefone.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Não foi encontrado nenhum cliente com este número de BI no sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de Base de Dados ao atualizar: " + ex.Message, "Erro SQL");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar se o utilizador digitou o BI
            if (string.IsNullOrEmpty(txtBI.Text))
            {
                MessageBox.Show("Por favor, introduza o número de BI do cliente que deseja eliminar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pergunta de segurança para confirmar a ação
            DialogResult confirmacao = MessageBox.Show("Tens a certeza absoluta que desejas eliminar este cliente permanentemente?", "Confirmar Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                // A Query procura e elimina diretamente pelo campo BI
                string query = "DELETE FROM Clientes WHERE BI = @BI";

                using (SqlConnection conexao = new SqlConnection(stringConexaoGlobal))
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand(query, conexao);
                        comando.Parameters.AddWithValue("@BI", txtBI.Text.Trim());

                        conexao.Open();
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        // Verificar se o BI existia e se foi apagado
                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Cliente removido do sistema com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Limpa todas as caixas de texto após apagar
                            txtBI.Clear();
                            txtNomeCliente.Clear();
                            txtTelefone.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Não foi encontrado nenhum cliente com esse número de BI.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro de Base de Dados ao eliminar: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}











