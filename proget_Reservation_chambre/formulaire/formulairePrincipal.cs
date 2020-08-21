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

namespace proget_Reservation_chambre.formulaire
{
    public partial class formulairePrincipal : DevExpress.XtraEditors.XtraForm
    {
        public formulairePrincipal()
        {
            InitializeComponent();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formClient fc = new formClient();
            fc.MdiParent = this;
            fc.Text= "Client";
            fc.Show();

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmClasse fc = new frmClasse();
            fc.MdiParent = this;
            fc.Text = "Classe";
            fc.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formReservation fc = new formReservation();
            fc.MdiParent = this;
            fc.Text = "Reservation";
            fc.Show();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormChambre fc = new FormChambre();
            fc.MdiParent = this;
            fc.Text = "Chambre";
            fc.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formPaiement fc = new formPaiement();
            fc.MdiParent = this;
            fc.Text = "Paiements";
            fc.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formUser fc = new formUser();
            fc.MdiParent = this;
            fc.Text = "Utilisateur";
            fc.Show();
        }

        void niveau_acces()
        {
            if (pubCon.GetInstance().Niveau == "2")
            {
                pag_resrevation.Enabled = false;
                pag_chambre.Enabled = false; ;
                pag_classe.Enabled = false;
            }
        }

        private void formulairePrincipal_Load(object sender, EventArgs e)
        {
            pubCon.testFile();
           // niveau_acces();
            ribbonControl1.Enabled = false;
            navBarControl1.Enabled = false;

            frmLogin log = new frmLogin();
            log.ShowDialog();

            if (pubCon.textCon == 1)
            {
                ribbonControl1.Enabled = true;
                navBarControl1.Enabled = true;
                niveau_acces();
            }

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSms fc = new frmSms();
            fc.MdiParent = this;
            fc.Text = "Envoie sms";
            fc.Show();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}