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
    public partial class frmClasse : Form
    {
        public frmClasse()
        {
            InitializeComponent();
        }


        clsClasse cb = new clsClasse();
        private void button5_Click(object sender, EventArgs e)
        {
            initialiser();
        }
        void initialiser()
        {
            txtCode.Text = "";
            txtDesignationClasse.Text = "";
        }

        private void buttonSaveClas_Click(object sender, EventArgs e)
        {
            //cb.CodeClasse =int.Parse(txtCode.Text);
            cb.Designation = txtDesignationClasse.Text;
            clsGlossaires.GetInstance().insert_Classe(cb);
            gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tclasse");
        }

        private void buttonModi_Click(object sender, EventArgs e)
        {
            cb.CodeClasse =int.Parse(txtCode.Text);
            cb.Designation = txtDesignationClasse.Text;
            clsGlossaires.GetInstance().update_Classe(cb);
            gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tclasse");
        }

        private void frmClasse_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tclasse");
        }

        private void buttonSup_Click(object sender, EventArgs e)
        {
            cb.CodeClasse = int.Parse(txtCode.Text);
            clsGlossaires.GetInstance().deleteFrom("Tclasse", "codeClasse", txtCode.Text);
            gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tclasse");
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            txtCode.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["codeClasse"]).ToString();
            txtDesignationClasse.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["Designation"]).ToString();
        }
    }
}
