using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using proget_Reservation_chambre.classeDoc;
using System.IO;
using proget_Reservation_chambre.classeDoc;

namespace proget_Reservation_chambre.formulaire
{
    public partial class frmConfigiration : DevExpress.XtraEditors.XtraForm
    {
        public frmConfigiration()
        {
            InitializeComponent();
        }

        void connecter()
        {
            pubConnect.database = txtDatabase.Text;
            pubConnect.server = cmbServer.Text;
            pubConnect.uid = txtUid.Text;
            pubConnect.pwd = txtPass.Text;
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            connecter();
            string chemin = "server=" + cmbServer.Text + ";database=" + txtDatabase.Text + ";uid=" + txtUid.Text + ";pwd=" + txtPass.Text + ";";
            File.WriteAllText(clsConstante.Table.chemin,chemin.ToString());
            this.Close();
        }

        private void frmConfigiration_Load(object sender, EventArgs e)
        {
            cmbServer.Items.Add(Environment.MachineName);
        }
    }
}