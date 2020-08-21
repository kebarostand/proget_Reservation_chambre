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
using proget_Reservation_chambre.ripoty;
using DevExpress.XtraReports.UI;

namespace proget_Reservation_chambre.formulaire
{
    public partial class formPaiement : Form
    {
        public formPaiement()
        {
            InitializeComponent();
        }
        clsPaiement cb = new clsPaiement();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(1);
        }
        void initialiser()
        {
            txtCodePayer.Text = "";
            txtMontant.Text = "";
            txtUser.Text = pubCon.GetInstance().Username;
            cmbDateRese.Text = "";
        }
        void chargerCombo()
        {
            ClsBase bs = new ClsBase();
            bs.NomTable = "listeReservation";
            bs.NomChamp = "Nom";
            clsGlossaires.GetInstance().loadCombo(bs, cmbDateRese);
        }
        void selectionnerCombo()
        {
            ClsBase bs = new ClsBase();
            bs.NomTable = "listeReservation";
            bs.NomChamp = "codeReservation";
            clsGlossaires.GetInstance().getcode_Combo(bs, txtCodeReservation, "Nom", cmbDateRese.Text);
        }
        void saveUpdateDelete(int i)
        {
            try
            {
                if(i==1 || i == 2)
                {
                    cb.DatePayer =DateTime.Parse(dttDatePaiement.Text);
                    cb.MontantPayer =float.Parse(txtMontant.Text);
                    cb.RefReservation =int.Parse(txtCodeReservation.Text);
                    cb.Usersession = txtUser.Text;
                    if (i == 1)
                    {
                        clsGlossaires.GetInstance().insert_Paiement(cb);
                        gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tpaiement");
                        initialiser();
                    }
                    else if (i == 2)
                    {
                        cb.CodePaiement = int.Parse(txtCodePayer.Text);
                        clsGlossaires.GetInstance().update_Paiement(cb);
                        gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tpaiement");
                        initialiser();
                    }
                }
                else if (i == 3)
                {
                    cb.CodePaiement = int.Parse(txtCodePayer.Text);
                    clsGlossaires.GetInstance().deleteFrom("Tpaiement","codePaiement",txtCodePayer.Text);
                    gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Treservation");
                    initialiser();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Champs Obligatoire ", "0bligatoire", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void formPaiement_Load(object sender, EventArgs e)
        {
            chargerCombo();
            txtUser.Text = pubCon.GetInstance().Username;
            gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tpaiement");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(2);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(3);
        }

        private void cmbDateRese_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectionnerCombo();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            txtCodePayer.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["codePaiement"]).ToString();
            txtCodeReservation.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["RefReserv"]).ToString();
            txtMontant.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["Montant"]).ToString();
            txtUser.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["UserSession"]).ToString();
            dttDatePaiement.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["datePaiement"]).ToString();
        }

        private void txtCodeReservation_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                recuPaiement be = new recuPaiement();
                be.DataSource = clsGlossaires.GetInstance().get_Report_X("viewRecu", "codePaiement", txtCodePayer.Text);
                using (ReportPrintTool printTool = new ReportPrintTool(be))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
