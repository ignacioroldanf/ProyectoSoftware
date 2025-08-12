using Controlador;
using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAG___Diploma.Vista
{
    public partial class FormCliente : Form
    {
        private readonly CtrlGestionarClientes _clienteControlador;

        private Cliente clienteExistente = null;

        public void CargarCliente(Cliente cliente)
        {
            clienteExistente = cliente;

            txtDocumento.Text = cliente.DniCliente.ToString();
            txtNombre.Text = cliente.NombreCliente;
            txtApellido.Text = cliente.ApellidoCliente;
            txtMail.Text = cliente.MailCliente;
        }



        public FormCliente()
        {
            InitializeComponent();
            _clienteControlador = new CtrlGestionarClientes(new DiplomaContext());

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (!int.TryParse(txtDocumento.Text, out int documento))
            {
                MessageBox.Show("Por favor, ingresa un número válido para el documento.");
                return;
            }
            if(clienteExistente == null)
            {
                Cliente nuevoCliente = new Cliente();

                nuevoCliente.DniCliente = Convert.ToInt32(txtDocumento.Text);
                nuevoCliente.NombreCliente = txtNombre.Text;
                nuevoCliente.MailCliente = txtMail.Text;
                nuevoCliente.ApellidoCliente = txtApellido.Text;
                nuevoCliente.FechaAlta = DateOnly.FromDateTime(DateTime.Now);

                _clienteControlador.AgregarCliente(nuevoCliente);
                MessageBox.Show("Cliente agregado correctamente");
            }
            else
            {

                clienteExistente.DniCliente = Convert.ToInt32(txtDocumento.Text);
                clienteExistente.NombreCliente = txtNombre.Text;
                clienteExistente.ApellidoCliente = txtApellido.Text;
                clienteExistente.MailCliente = txtMail.Text;

                _clienteControlador.ModificarCliente(clienteExistente);
                MessageBox.Show("Cliente modificado correctamente");

            }

            this.Close();
        }



    }
}
