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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUtilizador_TextChanged(object sender, EventArgs e)
        {
            // --- EVENTOS PARA O CAMPO UTILIZADOR ---

            if (txtUtilizador.Text == "Insira o utilizador...")
            {
                txtUtilizador.Text = ""; 
                txtUtilizador.ForeColor = Color.White; 
            }
        }

        
        private void txtUtilizador_Leave(object sender, EventArgs e)
        {
            if (txtUtilizador.Text == "")
            {
                txtUtilizador.Text = "Insira o utilizador..."; 
                txtUtilizador.ForeColor = Color.DarkGray; 
            }
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Insira a senha...")
            {
                txtSenha.Text = ""; 
                txtSenha.ForeColor = Color.White; 
                txtSenha.PasswordChar = '*'; 
            }
        }

        // Quando o utilizador sai da caixa da senha
        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.Text = "Insira a senha..."; 
                txtSenha.ForeColor = Color.DarkGray; 
                txtSenha.PasswordChar = '\0'; 
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            
            // 1. Validar 
            if (txtUtilizador.Text == "Insira o utilizador..." || txtSenha.Text == "Insira a senha...")
            {
                MessageBox.Show("Por favor, preencha todos os campos de acesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Criar a String de Conexão Dinâmica utilizando os dados digitados no ecrã
            
            string servidor = "localhost";
            string bancoDados = "BD_Vendas";
            string utilizador = txtUtilizador.Text;
            string senha = txtSenha.Text;

            string stringConexao = $"Data Source={servidor};Initial Catalog={bancoDados};User ID={utilizador};Password={senha};";

            // Abrir a conexão com o SQL Server
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                try
                {
                    conexao.Open(); // Tenta ligar ao servidor

                    
                    MessageBox.Show($"Bem-vindo ao Sistema, {utilizador}!\nAcesso ao Servidor Central autorizado.", "Sucesso de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                    TelaMenu menu = new TelaMenu(stringConexao,utilizador);
                    menu.Show();
                    this.Hide(); // Esconde a tela de login

                   
                }
                catch (SqlException ex)
                {
                    // Se houver erro de senha errada ou utilizador inexistente, o SQL Server devolve um erro que capturamos aqui
                    MessageBox.Show("Falha na Autenticação Distribuída!\nUtilizador ou Senha incorretos no SQL Server.\n\nErro original: " + ex.Message, "Erro de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    }
    
    

