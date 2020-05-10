using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Stock
{
   
    class Program
        

    {

        
        public static List<Produit> produits = new List<Produit>();
        [STAThread]
       
        static void Main(string[] args)
        {
    
            Application.EnableVisualStyles();
            Application.Run(new Gestion_Stock());
            

        }

    }
    }

