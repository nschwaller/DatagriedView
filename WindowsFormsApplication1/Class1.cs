using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Eleve
    {
        private string nom;
        private string prenom;
        private string dateN;
        private string classe;

        public Eleve(string nom, string prenom, string date, string classe)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.dateN = date;
            this.classe = classe;
        }
        public string getnom()
        {
            return this.nom;
        }

        public string getprenom()
        {
            return this.prenom;
        }
        public string getdateN()
        {
            return this.dateN;
        }

        public void setnom(string newnom)
        {
            this.nom = newnom;
        }
        public void setprenom(string newprenom)
        {
            this.prenom = newprenom;
        }
        public void setdateN(string newd)
        {
            this.dateN = newd;
        }

        public string getclasse()
        {
            return this.classe;
        }

        public void setclasse(string newclasse)
        {
            this.classe = newclasse;
        }
    }
}
