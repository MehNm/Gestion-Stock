using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Stock
{
    [Serializable]
    public class Produit
    {

        #region Dec les attributes
        private int idProduit;
        private static int cpe = 0;
        private string nom_produit;
        private int quantite;
        private double prix;
        private DateTime dateFabrication;
        #endregion
        #region Dec les Propriete
        public int Idproduit
        {
            get { return idProduit; }
            set { idProduit = value; }
        }
        public string Nom_produit
        {
            get { return this.nom_produit; }
            set { this.nom_produit = value; }
        }
        public int Quantite
        {
            get { return this.quantite; }
            set { this.quantite = value; }
        }

        public DateTime DateFabrication
        {
            get { return this.dateFabrication; }
            set { this.dateFabrication = value; }

        }
        #endregion

        #region Dec Constructeur
        public Produit() { }
        public Produit(string nom_produit, int quantite, DateTime dateFabrication)
        {
            cpe++;
            this.idProduit = cpe;
            this.nom_produit = nom_produit;
            this.quantite = quantite;
            this.dateFabrication = dateFabrication;
        }
        #endregion

        #region Dec method EtatDuStock
        public void EtatDuStock(Produit produit)
        {
            if (produit.quantite > 10)
            {
                Console.WriteLine("Disponible");
            }
            else if (produit.quantite >= 1 && produit.quantite <= 10)
            {
                Console.WriteLine("Critique");
            }
            else
            {
                Console.WriteLine("Non disponible");
            }

        }
        #endregion
        
        #region Dec method ToString
        public override string ToString()
        {
            string str = String.Empty;
            str += "Id Produit: " + this.idProduit + "\n";
            str += "Nom Produit: " + this.nom_produit + "\n";
            str += "Quantite: " + this.quantite + "\n";
            str += "Prix: " + this.prix + "\n";
            str += "Date Fabrication: " + this.dateFabrication + "\n";


            return str;
        }
        #endregion
        #region dec method Equals
        public override bool Equals(object obj)
        {
            Produit produit = obj as Produit;
            if (produit != null)
            {
                return this.nom_produit == produit.nom_produit && this.prix == produit.prix && this.quantite == produit.quantite;
            }
            else
            {
                return false;
            }
        } 
        #endregion
    }
}
