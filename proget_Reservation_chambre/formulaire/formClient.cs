using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proget_Reservation_chambre.formulaire;
using proget_Reservation_chambre.classeDoc;

namespace proget_Reservation_chambre.formulaire
{
    public partial class formClient : Form
    {
        public formClient()
        {
            InitializeComponent();
        }

        clsClient cb = new clsClient();
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void formClient_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tclient");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            initialiser();
        }
        void initialiser()
        {
            txtAdresse.Text = "";
            txtContact.Text = "";
            txtNom.Text = "";
            pictureEdit1.Image = null;
        }
        void saveUpdateDelete(int i)
        {
            try
            {
                if (i == 1 || i == 2)
                {
                    cb.NomClient = txtNom.Text;
                    cb.Contact = txtContact.Text;
                    cb.Adresse = txtAdresse.Text;
                    cb.Sexe = cmbSexe.Text;
                    cb.Photo = pictureEdit1.Image;
                    if (i == 1)
                    {
                        clsGlossaires.GetInstance().insert_Client(cb);
                        gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tclient");
                    }
                    else if (i == 2)
                    {
                        cb.CodeClient = int.Parse(txtCode.Text);
                        clsGlossaires.GetInstance().update_Client(cb);
                        gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tclient");
                    }
                }
                else if (i == 3)
                {
                    cb.CodeClient = int.Parse(txtCode.Text);
                    clsGlossaires.GetInstance().deleteFrom("Tclient", "codeClient", txtCode.Text);
                    gridControl1.DataSource = clsGlossaires.GetInstance().chargementGrid("Tclient");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("champs Obligatoire " ,"0bligatoire", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveUpdateDelete(3);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
               
                txtCode.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["codeClient"]).ToString();
                txtNom.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["Nom"]).ToString();
                txtAdresse.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["Adresse"]).ToString();
                txtContact.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["Contact"]).ToString();
                cmbSexe.Text = gridView1.GetFocusedRowCellValue(gridView1.Columns["sexe"]).ToString();
                clsGlossaires.GetInstance().retreivePhoto("Photo", "Tclient", "codeClient", txtCode.Text, pictureEdit1);

            }
            catch { }
        }
    }
}
