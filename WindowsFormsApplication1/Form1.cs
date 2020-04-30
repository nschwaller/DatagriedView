using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

           
        }
        string line;

        private void button1_Click(object sender, EventArgs e)
        {
            ds_liste.Tables.Add("table1");
            ds_liste.Tables["table1"].Columns.Add("nom");
            ds_liste.Tables["table1"].Columns.Add("prenom");
            ds_liste.Tables["table1"].Columns.Add("date");
            ds_liste.Tables["table1"].Columns.Add("classe");
            DataRow ligne;

            StreamReader sr = new StreamReader("./Acreer.csv");
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] words = line.Split(';');
                Eleve lEleve =new Eleve(words[0], words[1], words[2],words[3]);
                

                ligne = ds_liste.Tables["table1"].NewRow();
                ligne["nom"] = lEleve.getnom();
                ligne["prenom"] = lEleve.getprenom();
                ligne["date"] = lEleve.getdateN();
                ligne["classe"] = lEleve.getclasse();
                ds_liste.Tables["table1"].Rows.Add(ligne);

            }
            sr.Close();

            dgv_liste.DataSource = ds_liste;
            dgv_liste.DataMember = "table1";
            dgv_liste.Update();
            dgv_liste.Refresh();

            button1.Enabled = false;

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            FileStream f = File.Open("./compte.bat", FileMode.Truncate | FileMode.OpenOrCreate);
            f.Close();
            List<string> Login = new List<string>();                      
            string mdp;
            char[] caractere = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            //7lettre random minuscule
            char[] chaine = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };       
            Random rand = new Random();            
            using (StreamWriter writer = new StreamWriter("./compte.bat", true))
            {
                
                for (int i=0;i<ds_liste.Tables["table1"].Rows.Count;i++)
                {
                    string newLogin = ds_liste.Tables["table1"].Rows[i]["prenom"].ToString().Substring(0, 1) + ds_liste.Tables["table1"].Rows[i]["nom"].ToString();
                    bool existe = false;
                    int chiffre = 1;

                    do
                    {
                        existe = false;
                        foreach (string liste in Login)
                        {
                            if (liste == newLogin)
                            {
                                existe = true;
                                break;
                            }
                        }
                        if (existe)
                        {
                            newLogin = ds_liste.Tables["table1"].Rows[i]["prenom"].ToString().Substring(0, 1) + ds_liste.Tables["table1"].Rows[i]["nom"].ToString() + chiffre.ToString();
                            chiffre++;
                        }
                    } while (existe);
                    Login.Add(newLogin);

                    //création mdp

                   mdp = caractere[rand.Next(0, 26)].ToString() + chaine[rand.Next(0,26)].ToString()+chaine[rand.Next(0, 26)].ToString()+rand.Next(0,10).ToString() + caractere[rand.Next(0, 26)].ToString()+ chaine[rand.Next(0, 26)].ToString();

                    writer.WriteLine("net user "+newLogin+" "+mdp+" /ADD /FULLNAME:\""+ ds_liste.Tables["table1"].Rows[i]["prenom"].ToString()+" " + ds_liste.Tables["table1"].Rows[i]["nom"].ToString()+"\" /DOMAIN");
                    
                }
                
            }
            MessageBox.Show("Votre fichier s'est bien créé");
        }
    }
}


