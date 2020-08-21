using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proget_Reservation_chambre.classeDoc;

namespace proget_Reservation_chambre.formulaire
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pubCon.textCon = clsGlossaires.GetInstance().loginTest(txtNom.Text, txtMotDePasse.Text);
            if (pubCon.textCon == 1)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
