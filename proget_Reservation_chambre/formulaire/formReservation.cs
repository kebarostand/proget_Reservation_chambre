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
    public partial class formReservation : Form
    {
        public formReservation()
        {
            InitializeComponent();
        }
        clsReservation cb = new clsReservation();
        void initialiser()
        {
            txtCodeChambre.Text = "";
            txtCodeClient.Text = "";
            txtCodeRese.Text = "";
            txtPrix.Text = "";
            txtUsers.Text = pubCon.GetInstance().Username;
            cmbNomClient.Text = "";
            cmbNumChambre.Text = "";
        }

        #region chargement et sectionner combo MyRegion
        void chargerComboNom()
        {
            ClsBase bs = new ClsBase();
            bs.NomChamp = "Nom";
            bs.NomTable = "Tclient";
            clsGlossaires.GetInstance().loadCombo(bs, cmbNomClient);
        }

        void chargerComboChambre()
        {
            ClsBase bs = new ClsBase();
            bs.NomChamp = "NumeroChambre";
            bs.NomTable = "Tchambre";
            clsGlossaires.GetInstance().loadCombo(bs, cmbNumChambre);
        }

        void selectionnerComboNom()
        {
            ClsBase bs = new ClsBase();
            bs.NomChamp = "codeClient";
            bs.NomTable = "Tclient";
            clsGlossaires.GetInstance().getcode_Combo(bs, txtCodeClient, "Nom", cmbNomClient.Text);
        }
        void selectionnerComboChambre()
        {
            ClsBase bs = new ClsBase();
            bs.NomChamp = "codechambre";
            bs.NomTable = "Tchambre";
            clsGlossaires.GetInstance().getcode_Combo(bs, txtCodeChambre, "NumeroChambre", cmbNumChambre.Text);
        }
        #endregion

        #region saveUpdateDelete MyRegion
        void saveUpdateDelete(int i)
        {
            try
            {
                if (i == 1 || i == 2)
                {
                    cb.DateDebut = DateTime.Parse(txtDateDebut.Text);
                    cb.DateEnregistrement = DateTime.Parse(dttReservation.Text);
                    cb.DateFin = DateTime.Parse(txtDateFin.Text);
                    cb.Prix = float.Parse(txtPrix.Text);
                    cb.RefChambre = int.Parse(txtCodeChambre.Text);
                    cb.RefClient = int.Parse(txtCodeClient.Text);
                    cb.Usersession = txtUsers.Text;
                    //cb.Usersession = clsGlossaires.GetInstance();
                    if (i == 1)
                    {
                        clsGlossaires.GetInstance().insert_Reservation(cb);
                        gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("listeReservation");
                    }
                    else if (i == 2)
                    {
                        cb.CodeReservation = int.Parse(txtCodeRese.Text);
                        clsGlossaires.GetInstance().update_Reservation(cb);
                        gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("listeReservation");

                    }
                }
                else if (i == 3)
                {
                    cb.CodeReservation = int.Parse(txtCodeRese.Text);
                    clsGlossaires.GetInstance().deleteFrom("Treservation", "codeReservation", txtCodeRese.Text);
                    gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("listeReservation");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("champs Obligatoire ", "0bligatoire", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

        }
        #endregion


        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (clsGlossaires.GetInstance().teste_ReserveChambre(txtCodeChambre.Text, DateTime.Parse(txtDateDebut.Text), DateTime.Parse(txtDateFin.Text))==true)
            {
                saveUpdateDelete(1);
                initialiser();
            }
            else
            {
                MessageBox.Show("la chambre est ocuppé svp");
            }
            
        }

        private void formReservation_Load(object sender, EventArgs e)
        {
            chargerComboChambre();
            chargerComboNom();
            txtUsers.Text = pubCon.GetInstance().Username;
            gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("listeReservation");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(2);
            initialiser();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(3);
            initialiser();
        }

        private void cmbNomClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectionnerComboNom();
        }

        private void cmbNumChambre_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectionnerComboChambre();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            txtCodeRese.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["codeReservation"]).ToString();
            // txtCodeClient.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["RefClient"]).ToString();
            // txtCodeRese.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["codeReservation"]).ToString();
            
            cmbNumChambre.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["NumeroChambre"]).ToString();
            cmbNomClient.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["Nom"]).ToString();
            txtPrix.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["Prix"]).ToString();
     
            txtDateDebut.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["dateDebut"]).ToString();
            txtDateFin.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["dateFin"]).ToString();
            //dttReservation.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["dateReserv"]).ToString();
            txtUsers.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["userSession"]).ToString();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                listeReservation be = new listeReservation();
                be.DataSource = clsGlossaires.GetInstance().get_Report_X("listeReservation","codeReservation",txtCodeRese.Text);
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
