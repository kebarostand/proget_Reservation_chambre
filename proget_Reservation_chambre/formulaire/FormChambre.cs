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
    public partial class FormChambre : Form
    {
        public FormChambre()
        {
            InitializeComponent();
        }
        clsChambre cb = new clsChambre();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            initialiser();
        }
        void initialiser()
        {
            txtCode.Text = "";
            txtCodeClasse.Text = "";
            txtNumeroChambre.Text = "";
            cmbClasse.Text = "";
        }

        private void cmbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           // 
        }
        #region Chargement et sectionner Combo MyRegion
        void ChargeCombo()
        {
            ClsBase bs = new ClsBase();
            bs.NomTable = "Tclasse";
            bs.NomChamp = "Designation";
            clsGlossaires.GetInstance().loadCombo(bs, cmbClasse);
        }

        void sectionnerCombo()
        {
            ClsBase bs = new ClsBase();
            bs.NomTable = "Tclasse";
            bs.NomChamp = "codeClasse";
            clsGlossaires.GetInstance().getcode_Combo(bs, txtCodeClasse, "Designation", cmbClasse.Text);
        }
        #endregion

       

        #region saveUptadeDelete MyRegion
        void saveUpdateDelete(int i)
        {
            try
            {
                if (i == 1 || i == 2)
                {
                    cb.NumChambre = txtNumeroChambre.Text;
                    cb.RefChambre = int.Parse(txtCodeClasse.Text);
                    if (i == 1)
                    {
                        clsGlossaires.GetInstance().insert_Chambre(cb);
                        gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tchambre");
                    }
                    else if (i == 2)
                    {
                        cb.CodeChambre = int.Parse(txtCode.Text);
                        clsGlossaires.GetInstance().update_Chambre(cb);
                        gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tchambre");
                    }
                }
                else if (i == 3)
                {
                    cb.CodeChambre = int.Parse(txtCode.Text);
                    clsGlossaires.GetInstance().deleteFrom("Tclasse", "codeClasse", txtCode.Text);
                    gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tchambre");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("champs Obligatoire ", "0bligatoire", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }
        #endregion


        void chargerGrid()
        {
            gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tchambre");
        }

        private void FormChambre_Load(object sender, EventArgs e)
        {
            ChargeCombo();
            chargerGrid();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(1);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(2);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(3);
        }

        private void cmbClasse_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            sectionnerCombo();
        }

        private void cmbClasse_SelectedValueChanged(object sender, EventArgs e)
        {
            //sectionnerCombo();
        }

        private void cmbClasse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sectionnerCombo();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            txtCode.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["codeChambre"]).ToString();
            txtNumeroChambre.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["NumeroChambre"]).ToString();
            txtCodeClasse.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["RefClasse"]).ToString();
            //cmbClasse.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["codeClient"]).ToString();
        }
    }
}
