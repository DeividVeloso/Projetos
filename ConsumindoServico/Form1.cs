using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using ConsumindoServico.ClienteService;

namespace ConsumindoServico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;

            try
            {
                ClienteServiceClient service = new ClienteServiceClient();
                Cliente cliente = new Cliente();

                cliente.Nome = nome;
                cliente.CPF = cpf;

                if (service.Salvar(cliente))
                {
                    MessageBox.Show("Cliente cadastrado com sucesso!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            try
            {
                ClienteServiceClient service = new ClienteServiceClient();

                Cliente cliente  = service.Buscar(nome);
                if (cliente != null)
                {
                    txtCpf.Text = cliente.CPF;
                    
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
