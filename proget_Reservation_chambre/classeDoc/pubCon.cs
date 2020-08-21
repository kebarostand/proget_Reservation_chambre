using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proget_Reservation_chambre.formulaire;

namespace proget_Reservation_chambre.classeDoc
{
    class pubCon
    {
        public static int textCon;
        public static pubCon pub = null;
        private string niveau;
        private string username;

        public string Niveau
        {
            get
            {
                return niveau;
            }

            set
            {
                niveau = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public static pubCon GetInstance()
        {
            if (pub == null)
            {
                pub = new pubCon();
            }
            return pub;
        }

        public static void testFile()
        {
            if (Directory.Exists(clsConstante.Table.InitialDirectory) == true) { }

            else
            {
                Directory.CreateDirectory(clsConstante.Table.InitialDirectory);
            }

            if (File.Exists(clsConstante.Table.chemin) == true)
            {
                //connec = File.ReadAllText("C:\\cheminBdCredit\\monChemin.txt");
            }
            else
            {
                frmConfigiration frm = new frmConfigiration();
                frm.ShowDialog();
                
            }
        }
    }
}
