using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OVINIManager
{
    public partial class Painel : Form
    {
        // Objetos Globais:
        BibliotecaOVNI.OVNI ovni;
        public Painel(BibliotecaOVNI.OVNI ovni)
        {
            InitializeComponent();
            this.ovni = ovni;
            AtualizarDados();
            // Popular o CMB:
            cmbPlanetas.DataSource = BibliotecaOVNI.OVNI.PlanetasValidos;
        }

        // Método para atualizar os dados:
        public void AtualizarDados()
        {
            lblAbduzidos.Text = "Abduzidos: " + ovni.QtdAbduzidos;
            lblTripulantes.Text = "Tripulantes: " + ovni.QtdTripulantes;
            lblSituacao.Text = "Situação: " + (ovni.Situacao ? "Ligado" : "Desligado");
            lblPlaneta.Text = "Planeta: " + ovni.PlanetaAtual;
            // Ativar os botões de acordo com o estado da nave: 
            btnLigar.Enabled = !ovni.Situacao;
            btnDesligar.Enabled = ovni.Situacao;
            // Habilitar/desabilitar botões de acordo com a situação:
            btnAbduzir.Enabled = ovni.Situacao;
            btnMudarPlaneta.Enabled = ovni.Situacao;
            cmbPlanetas.Enabled = ovni.Situacao;
            btnOrigem.Enabled= ovni.Situacao;
            
        }
        private void Painel_Load(object sender, EventArgs e)
        {

        }

        private void btnLigar_Click(object sender, EventArgs e)
        {
            ovni.Ligar();
            AtualizarDados();
        }

        private void btnDesligar_Click(object sender, EventArgs e)
        {
            ovni.Desligar();
            AtualizarDados();
        }

        private void btnAddTripulante_Click(object sender, EventArgs e)
        {
            if(ovni.AdicionarTripulante() == false)
            {
                MessageBox.Show("Limite máximo de tripulantes atingido");
            }
            AtualizarDados();
        }

        private void btnRemoverTripulante_Click(object sender, EventArgs e)
        {
            if(ovni.RemoverTripulante() == false)
            {
                MessageBox.Show("Somente o tripulante obrigatorio esta na nave");
            }
            AtualizarDados();
        }

        private void btnAbduzir_Click(object sender, EventArgs e)
        {
            if (ovni.Abduzir() == false)
            {
                MessageBox.Show("Limite máximo de abduzidos atingido");
            }
            AtualizarDados();
        }

        private void btnDesabduzir_Click(object sender, EventArgs e)
        {
            if (ovni.Desabduzir() == false)
            {
                MessageBox.Show("Não existe abduzidos na nave");
            }
            AtualizarDados();
        }

        private void btnMudarPlaneta_Click(object sender, EventArgs e)
        {
            if(ovni.MudarPlaneta(cmbPlanetas.Text) == true )
            {
                MessageBox.Show("Mudou de planeta");
            }
            AtualizarDados();
        }

        private void btnOrigem_Click(object sender, EventArgs e)
        {
            if (ovni.RetornarAoPlanetaDeOrigem() == true)
            {
                MessageBox.Show("Retornou ao planeta de origem");
            }
            else if (ovni.RetornarAoPlanetaDeOrigem() == false)
            {
                MessageBox.Show("Você já esta no planeta de origem");
            }
            AtualizarDados();
        }
    }
}
