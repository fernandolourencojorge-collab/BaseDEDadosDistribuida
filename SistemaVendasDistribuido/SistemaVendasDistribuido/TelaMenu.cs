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
    public partial class TelaMenu : Form
    {
        // Variáveis globais que vão distribuir os dados para todas as outras telas
        private string stringConexaoGlobal;
        private string utilizadorLogado; // ADICIONAR Variável global para guardar o utilizador

        //  O construtor agora recebe a Conexão E o Utilizador vindos do Login!
        public TelaMenu(string conexaoRecebida, string usuarioRecebido)
        {
            InitializeComponent();
            stringConexaoGlobal = conexaoRecebida;
            utilizadorLogado = usuarioRecebido; 
        }

        //  Load  vazio para esperar as ações dos botões
        private void TelaMenu_Load(object sender, EventArgs e)
        {
            // Limpo
        }

        // Botão para abrir os Clientes
        private void btnMenuClientes_Click(object sender, EventArgs e)
        {
            TelaClientes tela = new TelaClientes(stringConexaoGlobal);
            tela.ShowDialog();
        }

        // Botão para abrir os Produtos
        private void btnMenuProdutos_Click_1(object sender, EventArgs e)
        {
            TelaProdutos tela = new TelaProdutos(stringConexaoGlobal);
            tela.ShowDialog();
        }

        // Botão para abrir a Caixa de Vendas
        private void btnMenuVendas_Click(object sender, EventArgs e)
        {
            try
            {
                
                TelaVendas telaVen = new TelaVendas(stringConexaoGlobal, utilizadorLogado);

                // Abrir a janela de vendas 
                telaVen.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a Caixa de Vendas: " + ex.Message, "Erro");
            }
        }

        private void FECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


