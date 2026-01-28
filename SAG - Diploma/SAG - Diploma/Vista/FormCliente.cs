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

            if (cliente.IdPersonaNavigation != null)
            {
                txtDocumento.Text = cliente.IdPersonaNavigation.Dni;
                txtNombre.Text = cliente.IdPersonaNavigation.Nombre;
                txtApellido.Text = cliente.IdPersonaNavigation.Apellido;
                txtMail.Text = cliente.IdPersonaNavigation.Email;
            }
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
                Persona nuevaPersona = new Persona();

                nuevaPersona.Nombre = txtNombre.Text;
                nuevaPersona.Dni = txtDocumento.Text;
                nuevaPersona.Apellido = txtApellido.Text;
                nuevaPersona.Email = txtMail.Text;


                Cliente nuevoCliente = new Cliente();
                
                nuevoCliente.FechaAlta = DateOnly.FromDateTime(DateTime.Now);
                nuevoCliente.IdPersonaNavigation = nuevaPersona;

                _clienteControlador.AgregarCliente(nuevoCliente);
                MessageBox.Show("Cliente agregado correctamente");
            }
            else
            {
                if (clienteExistente.IdPersonaNavigation == null)
                {
                    clienteExistente.IdPersonaNavigation = new Persona();
                }

                clienteExistente.IdPersonaNavigation.Dni = txtDocumento.Text;
                clienteExistente.IdPersonaNavigation.Nombre = txtNombre.Text;
                clienteExistente.IdPersonaNavigation.Apellido = txtApellido.Text;
                clienteExistente.IdPersonaNavigation.Email = txtMail.Text;

                _clienteControlador.ModificarCliente(clienteExistente);
                MessageBox.Show("Cliente modificado correctamente");

            }

            this.Close();
        }



    }
}
