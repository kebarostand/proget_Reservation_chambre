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
    public partial class frmSms : Form
    {
        public frmSms()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (radioChoix.Checked == true)
            {
                if(txtNumTel.Text=="" || txtMessage.Text=="")
                {
                    MessageBox.Show("Complete tous");
                }
                else
                {
                    clsSms ms = new clsSms();
                    ms.Numero_tutaire = txtNumTel.Text;
                    ms.Corps_message = txtMessage.Text;
                    ms.Utilisateur = pubCon.GetInstance().Username;
                    ms.Etats_sms = 0;
                    ms.Date_envoie = DateTime.Now;
                    clsGlossaires.GetInstance().insert_SMS(ms);
                }
            }
            else if (radioTous.Checked == true)
            {
                for(int i=0; i < (gridMessagerie.Rows.Count) - 1; i++)
                {
                    clsSms ms = new clsSms();
                    ms.Numero_tutaire = gridMessagerie[1,i].Value.ToString();
                    ms.Corps_message = txtMessage.Text;
                    ms.Utilisateur = pubCon.GetInstance().Username;
                    ms.Etats_sms = 0;
                    ms.Date_envoie = DateTime.Now;
                    clsGlossaires.GetInstance().insert_SMS(ms);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gridMessagerie.DataSource = clsGlossaires.GetInstance().chargementGrididMessage("Tclient");
        }

        private void radioTous_CheckedChanged(object sender, EventArgs e)
        {
            txtNumTel.Enabled = false;
        }

        private void radioChoix_CheckedChanged(object sender, EventArgs e)
        {
            txtNumTel.Enabled = true;
        }

        private void frmSms_Load(object sender, EventArgs e)
        {
            radioTous.Checked = true;
        }

        private void gridMessagerie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = gridMessagerie.CurrentRow.Index;
                txtNumTel.Text = gridMessagerie[1, 1].Value.ToString();
            }
            catch
            {

            }
        }
    }
}
