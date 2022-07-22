using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinForm
{
    public partial class frmTipoClienteEdit : Form
    {
        private int? Id;
        public frmTipoClienteEdit(int? id = null)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int estado = chkEstado.Checked ? 1 : 0;
            string nombre = txtNombre.Text;
            var adaptador = new dsAppTableAdapters.TipoClienteTableAdapter();
            if(this.Id == null)
            {
                adaptador.Add(nombre, (byte)estado);
            } else
            {
                adaptador.Edit(nombre, (byte) estado, (int) this.Id);
            }            
            this.Close();
        }

        private void frmTipoClienteEdit_Load(object sender, EventArgs e)
        {
            if(this.Id != null)
            {
                this.Text = "Editar";
                var adaptador = new dsAppTableAdapters.TipoClienteTableAdapter();
                var tabla = adaptador.GetDataById((int) this.Id);
                var fila = (dsApp.TipoClienteRow) tabla.Rows[0];
                txtNombre.Text = fila.Nombre;
                chkEstado.Checked = fila.Estado == 1 ? true: false;
            } else
            {
                this.Text = "Nuevo";
            }
        }
    }
}
