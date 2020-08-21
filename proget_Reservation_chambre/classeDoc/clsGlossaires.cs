using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;
using DevExpress.XtraEditors;

namespace proget_Reservation_chambre.classeDoc
{
    class clsGlossaires
    {
        SqlConnection con = null;
        clcConnexion cnx = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        SqlDataAdapter dt = null;
        private static clsGlossaires glos = null;

        public void initialiseConnect()
        {
            try
            {
                cnx = new clcConnexion();
                cnx.connect();
                con = new SqlConnection(cnx.chemin);
            }
            catch
            {
                MessageBox.Show("L'un de vos fichier de configuration est incorrecté");
            }
        }

        public static clsGlossaires GetInstance()
        {
            if (glos == null)
                glos = new clsGlossaires();
            return glos;
        }

        //Le parametrage des commande
        private static void setParameter(SqlCommand cmd, string name, DbType type, int length, object paramValue)
        {

            IDbDataParameter a = cmd.CreateParameter();
            a.ParameterName = name;
            a.Size = length;
            a.DbType = type;

            if (paramValue == null)
            {
                if (!a.IsNullable)
                {
                    a.DbType = DbType.String;
                }
                a.Value = DBNull.Value;
            }
            else
                a.Value = paramValue;
            cmd.Parameters.Add(a);
        }

        //La fonction chargement pour toutes les classes
        //==============================================

        public DataTable chargementGrid(string nomTable)
        {
            initialiseConnect();
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            DataTable table = new DataTable();
            dt = new SqlDataAdapter("select * from " + nomTable + "", con);
            dt.Fill(table);
            con.Close();

            return table;
        }

//==================================================================
        public DataTable chargementGrididMessage(string nomTable)
        {
            initialiseConnect();
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            DataTable table = new DataTable();
            dt = new SqlDataAdapter("select Nom,Contact from " + nomTable + "", con);
            dt.Fill(table);
            con.Close();

            return table;
        }

        // La fonction suppression
        //=======================================================================================

        public void deleteFrom(string nomTable, string nomChamp, string Valeur)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("Delete from " + nomTable + " where " + nomChamp + "=@valCode", con);
                cmd.Parameters.AddWithValue("@valCode", Valeur);

                DialogResult res = MessageBox.Show("voulez vous vraiment enregistrer cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Suppréssion réussi avec succès", "Message de confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("vous n'avez pas Supprimer!");

                }

            }
            catch (Exception)
            {
                throw new Exception("Ce code n'existe pas!");
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        // La selection de la photo
        //========================================================================================

        public void retreivePhoto(string ChampPhoto, string nomTable, string ChampCode, string Valeur, PictureEdit pic)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();

                cmd = new SqlCommand("SELECT " + ChampPhoto + " from " + nomTable + " WHERE  " + ChampCode + " = '" + Valeur + "'", con);
                dt = new SqlDataAdapter(cmd);
                Object result = cmd.ExecuteScalar();

                if (DBNull.Value == (result))
                {
                }
                else
                {
                    Byte[] buffer = (Byte[])result;
                    MemoryStream ms = new MemoryStream(buffer);
                    Image image = Image.FromStream(ms);
                    pic.Image = image;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        // chargement comboBox
        //=================================================================================

        public void loadCombo(ClsBase cb, System.Windows.Forms.ComboBox cmb)
        {
            try
            {
                cmb.Items.Clear();
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open"))
                    con.Open();
                cmd = new SqlCommand("select * from " + cb.NomTable , con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb.Items.Add(dr[cb.NomChamp].ToString());
                }
                cmd.Dispose();
                con.Close();
            }
            catch (Exception)
            { throw new Exception("Erreur de selection"); }
        }

        //=======================================================================================

        public void getcode_Combo(ClsBase cb, TextBox txt, String champ, String val)
        {
            try
            {
                txt.Clear();
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("select " + cb.NomChamp + " from " + cb.NomTable + " where " + champ + "=@a", con);
                cmd.Parameters.AddWithValue("@a", val);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txt.Text = (dr[cb.NomChamp].ToString());
                }
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Teste Login
        //============================================================================================

        string n;
        public int loginTest(String nom, String password)
        {
            int count = 0;

            try
            {
                initialiseConnect();
                con.Open();
                cmd = new SqlCommand("exec SP_Login '" + nom + "','" + password + "'", con);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    n = dr["Niveau"].ToString();
                    count += 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("La connection a reussie !!!!!!");
                   pubCon.GetInstance().Username = nom;
                    pubCon.GetInstance().Niveau = n;
                }
                else
                {
                    MessageBox.Show("Echec de Connexion");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return count;
        }

        // insertion Utilisateur ====================================================================
        //============================================================================================

        public void Enregistre_Utilisateur(clsUtilisateur user)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("exec inserer_user @a,@b,@c,@d", con);
                cmd.Parameters.AddWithValue("@a", user.CodeUser);
                cmd.Parameters.AddWithValue("@b", user.Nom);
                cmd.Parameters.AddWithValue("@c", user.MotPasse);
                cmd.Parameters.AddWithValue("@d", user.Niveau);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Enregistrement reussi avec succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de sauvegarde :" + ex.ToString());
            }
        }

        //controle chambre==================================================
        // =========================================================================


        public bool teste_ReserveChambre(string chambreEntree, DateTime DateEntree, DateTime DateSortie)
        {
            bool teste = true;
            DateTime DateEntreeTest;
            DateTime DateSortieTest;
            initialiseConnect();
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            SqlCommand cmd = new SqlCommand("select * from Treservation where RefChambre=@chambre ", con);
            setParameter(cmd, "@chambre", DbType.String, 20, chambreEntree);
            //setParameter(cmd, "@date2", DbType.Date, 20, DateSortie);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                try
                {
                    DateEntreeTest = DateTime.Parse(dr["dateDebut"].ToString());
                    DateSortieTest = DateTime.Parse(dr["dateFin"].ToString());

                    if (DateEntree == DateEntreeTest || DateEntree == DateSortieTest || ((DateEntree >= DateEntreeTest) && (DateEntree <= DateSortieTest)) || DateSortie == DateSortieTest || DateSortie == DateEntreeTest || ((DateSortie >= DateEntreeTest) && (DateSortie <= DateSortieTest)))
                    {
                        count += 1;
                    }
                    else
                    {
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

            if (count == 1)
            {
                teste = false;
            }



            else
            {
                teste = true;
            }

            return teste;

        }



        //Les Etatx de sortie================================================================================
        //===================================================================================================

        public DataSet get_Report_X(string nomTable, string nomchamp, string valchamp)
        {
            DataSet dst;
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE " + nomchamp + "='" + valchamp + "'", con);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }

        public DataSet get_Report_Tous(string nomTable)
        {
            DataSet dst;
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + " ", con);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }
        public DataSet get_Report_Trier(string nomTable, string nomchamp, DateTime val1, DateTime val2)
        {
            DataSet dst;
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE " + nomchamp + " between @date1 and @date2 ", con);
                setParameter(cmd, "@date1", DbType.DateTime, 30, val1);
                setParameter(cmd, "@date2", DbType.DateTime, 30, val2);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }
        //=========================================================================================
        //ENREGISTREMENT ET SUPPRESSIONS
        //===================================================================================================

        public void insert_Client(clsClient cb)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(cb.Photo);
                byte[] bytImage;
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                bytImage = ms.ToArray();
                ms.Close();
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("insert into Tclient values (@Nom, @Adresse, @Contact, @Photo, @sexe)", con);
                cmd.Parameters.AddWithValue("@Nom", cb.NomClient);
                cmd.Parameters.AddWithValue("@Adresse", cb.Adresse);
                cmd.Parameters.AddWithValue("@Contact", cb.Contact);
                setParameter(cmd, "@photo", DbType.Binary, int.MaxValue, bytImage);
                cmd.Parameters.AddWithValue("@sexe", cb.Sexe);
                //cmd.Parameters.AddWithValue("@userSession", pubCon.GetInstance().Username);

                DialogResult res = MessageBox.Show("voulez vous vraiment enregistrer cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Enregistrement réussi avec succès", "Message de confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Opération Annulée!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        #region client  MyRegion
        public void update_Client(clsClient cb)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(cb.Photo);
                byte[] bytImage;
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                bytImage = ms.ToArray();
                ms.Close();
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("update Tclient set Nom=@Nom, Adresse=@Adresse, Contact=@Contact, Photo=@Photo, sexe=@sexe where codeClient=@codeClient", con);
                cmd.Parameters.AddWithValue("@codeClient", cb.CodeClient);
                cmd.Parameters.AddWithValue("@Nom", cb.NomClient);
                cmd.Parameters.AddWithValue("@Adresse", cb.Adresse);
                cmd.Parameters.AddWithValue("@Contact", cb.Contact);
                setParameter(cmd, "@photo", DbType.Binary, int.MaxValue, bytImage);
                cmd.Parameters.AddWithValue("@sexe", cb.Sexe);
                DialogResult res = MessageBox.Show("voulez vous vraiment modifier cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Opération Annulée!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
        #endregion
        
//=======================================================================================================
        public void insert_Reservation(clsReservation cb)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("insert into Treservation values (@RefClient,@RefChambre, @dateDebut, @dateFin, @prix, @dateReserv,@UserSession)", con);
                cmd.Parameters.AddWithValue("@RefClient", cb.RefClient);
                cmd.Parameters.AddWithValue("@RefChambre", cb.RefChambre);
                cmd.Parameters.AddWithValue("@dateDebut", cb.DateDebut);
                cmd.Parameters.AddWithValue("@dateFin", cb.DateFin);
                cmd.Parameters.AddWithValue("@prix", cb.Prix);
                cmd.Parameters.AddWithValue("@dateReserv", cb.DateEnregistrement);
                cmd.Parameters.AddWithValue("@UserSession", cb.Usersession);
                DialogResult res = MessageBox.Show("voulez vous vraiment enregistrer cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Enregistrement réussi avec succès", "Message de confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Opération Annulée!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }


        public void update_Reservation(clsReservation cb)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("update Treservation set RefClient=@RefClient,RefChambre=@RefChambre, dateDebut=@dateDebut, dateFin=@dateFin, prix=@prix, dateReserv=@dateReserv,UserSession=@UserSession where codeReservation=@codeReservation", con);
                cmd.Parameters.AddWithValue("@codeReservation", cb.CodeReservation);
                cmd.Parameters.AddWithValue("@RefClient", cb.RefClient);
                cmd.Parameters.AddWithValue("@RefChambre", cb.RefChambre);
                cmd.Parameters.AddWithValue("@dateDebut", cb.DateDebut);
                cmd.Parameters.AddWithValue("@dateFin", cb.DateFin);
                cmd.Parameters.AddWithValue("@prix", cb.Prix);
                cmd.Parameters.AddWithValue("@dateReserv", cb.DateEnregistrement);
                cmd.Parameters.AddWithValue("@UserSession", cb.Usersession);
                DialogResult res = MessageBox.Show("voulez vous vraiment modifier cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Opération Annulée!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }


        }
        //=========================================================================================================

        public void insert_Paiement(clsPaiement cb)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("insert into Tpaiement values (@RefReserv, @datePaiement, @Montant, @UserSession)", con);
                cmd.Parameters.AddWithValue("@RefReserv", cb.RefReservation);
                cmd.Parameters.AddWithValue("@datePaiement", cb.DatePayer);
                cmd.Parameters.AddWithValue("@Montant", cb.MontantPayer);
                cmd.Parameters.AddWithValue("@UserSession", cb.Usersession);
                DialogResult res = MessageBox.Show("voulez vous vraiment enregistrer cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Enregistrement réussi avec succès", "Message de confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Opération Annulée!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }


        public void update_Paiement (clsPaiement cb)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("update Tpaiement set RefReserv=@RefReserv, datePaiement=@datePaiement, Montant=@Montant, UserSession=@UserSession where codePaiement=@codePaiement", con);
                cmd.Parameters.AddWithValue("@codePaiement", cb.CodePaiement);
                cmd.Parameters.AddWithValue("@RefReserv", cb.RefReservation);
                cmd.Parameters.AddWithValue("@datePaiement", cb.DatePayer);
                cmd.Parameters.AddWithValue("@Montant", cb.MontantPayer);
                cmd.Parameters.AddWithValue("@UserSession", cb.Usersession);
                DialogResult res = MessageBox.Show("voulez vous vraiment modifier cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Opération Annulée!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }


        }
        //==================================================================================================

        public void insert_Chambre(clsChambre cb)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("insert into Tchambre values (@NumeroChambre,@RefClasse)", con);
                cmd.Parameters.AddWithValue("@NumeroChambre", cb.NumChambre);
                cmd.Parameters.AddWithValue("@RefClasse", cb.RefChambre);
                DialogResult res = MessageBox.Show("voulez vous vraiment enregistrer cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Enregistrement réussi avec succès", "Message de confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Opération Annulée!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }


        public void update_Chambre(clsChambre cb)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("update Tchambre set NumeroChambre=@NumeroChambre,RefClasse=@RefClasse where codeChambre=@codeChambre", con);
                cmd.Parameters.AddWithValue("@codeChambre", cb.CodeChambre);
                cmd.Parameters.AddWithValue("@NumeroChambre", cb.NumChambre);
                cmd.Parameters.AddWithValue("@RefClasse", cb.RefChambre);
                DialogResult res = MessageBox.Show("voulez vous vraiment modifier cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Opération Annulée!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
        //=========================================================================================================

        public void insert_Classe(clsClasse cb)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("insert into Tclasse values (@Designation)", con);
                cmd.Parameters.AddWithValue("@Designation", cb.Designation);
                DialogResult res = MessageBox.Show("voulez vous vraiment enregistrer cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Enregistrement réussi avec succès", "Message de confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Opération Annulée!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }


        public void update_Classe(clsClasse cb)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("update Tclasse set Designation=@Designation where codeClasse=@codeClasse ", con);
                cmd.Parameters.AddWithValue("@codeClasse", cb.CodeClasse);
                cmd.Parameters.AddWithValue("@Designation", cb.Designation);
                DialogResult res = MessageBox.Show("voulez vous vraiment modifier cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Opération Annulée!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
        //==============================================================================================================




        //=========================================================================================
        //ENREGISTREMENT message
        //===================================================================================================

        public void insert_SMS(clsSms cb)
        {
            try
            {
                initialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("insert into Tmessagerie values (@numero_tutaire, @corps_message,@date_envoie, @etats_sms, @utilisateur)", con);
                cmd.Parameters.AddWithValue("@numero_tutaire", cb.Numero_tutaire);
                cmd.Parameters.AddWithValue("@corps_message", cb.Corps_message);
                cmd.Parameters.AddWithValue("@date_envoie", cb.Date_envoie);
                cmd.Parameters.AddWithValue("@etats_sms", cb.Etats_sms);
                //setParameter(cmd, "@etats_sms", DbType.Binary, int.MaxValue, bytImage);
                cmd.Parameters.AddWithValue("@utilisateur", cb.Utilisateur);

               // DialogResult res = MessageBox.Show("voulez vous vraiment enregistrer cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               // if (res == DialogResult.Yes)
                //{
                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Enregistrement réussi avec succès", "Message de confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
               // else
               // {
                   // MessageBox.Show("Opération Annulée!");

               // }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }





        /* public void insert_Utilisateur(clsUtilisateur cb)
         {
             try
             {
                 initialiseConnect();
                 if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                 cmd = new SqlCommand("insert into Tutilisateur values (@Nom, @Mot_Pass,@Niveau)", con);
                 cmd.Parameters.AddWithValue("@Nom", cb.Nom);
                 cmd.Parameters.AddWithValue("@Mot_Pass", cb.MotPasse);
                 cmd.Parameters.AddWithValue("@Niveau", cb.Niveau);
                 DialogResult res = MessageBox.Show("voulez vous vraiment enregistrer cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (res == DialogResult.Yes)
                 {
                     cmd.ExecuteNonQuery();
                     // MessageBox.Show("Enregistrement réussi avec succès", "Message de confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 else
                 {
                     MessageBox.Show("Opération Annulée!");

                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 cmd.Dispose();
                 con.Close();
             }
         }


         public void update_Utilisateur(clsUtilisateur cb)
         {
             try
             {
                 initialiseConnect();
                 if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                 cmd = new SqlCommand("update Tutilisateur values set Nom=@Nom, Mot_Pass=@Mot_Pass,Niveau=@Niveau  where codeUser=@codeUser ", con);
                 cmd.Parameters.AddWithValue("@codeUser", cb.CodeUser);
                 cmd.Parameters.AddWithValue("@Nom", cb.Nom);
                 cmd.Parameters.AddWithValue("@Mot_Pass", cb.MotPasse);
                 cmd.Parameters.AddWithValue("@Niveau", cb.Niveau);
                 DialogResult res = MessageBox.Show("voulez vous vraiment enregistrer cette operation?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (res == DialogResult.Yes)
                 {
                     cmd.ExecuteNonQuery();
                 }
                 else
                 {
                     MessageBox.Show("Opération Annulée!");

                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 cmd.Dispose();
                 con.Close();
             }
         } */

    }
}
