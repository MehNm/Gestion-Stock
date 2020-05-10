using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Gestion_Stock
{
  
    public partial class Gestion_Stock : Form
    {
       

        public Gestion_Stock()
        {
            
            InitializeComponent();
        }

        private void Gestion_Stock_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(! char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                throw new Exception("pls enter entier ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("IdProduit", "IdProduit");
            dataGridView1.Columns.Add("Quantite", "Quantite");
            dataGridView1.Columns.Add("Nom_produit", "Nom_produit");
            dataGridView1.Columns.Add("DateFabricatio", "DateFabricatio");


            if (Program.produits.Count > 0)
            {
                foreach (Produit item in Program.produits)
                {
                    dataGridView1.Rows.Add(item.Idproduit, item.Quantite, item.Nom_produit, item.DateFabrication);
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool b = textBox1.Text != string.Empty && textBox2.Text != string.Empty;
            if (b)
            {
                Program.produits.Add(new Produit(textBox1.Text, int.Parse(textBox2.Text), dateTimePicker1.Value));
                string message = "added successfully";
                string title = "added";
                MessageBox.Show(message, title, MessageBoxButtons.OK);
            }
            else
            {
                string message = "pls fill all Text box";
                string title = "Warning";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                XmlSerializer xml = new XmlSerializer(Program.produits.GetType());
                StreamWriter fs = new StreamWriter(path);


                xml.Serialize(fs, Program.produits);
                fs.Close();

            }
            
            


        }

        private void Gestion_Stock_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = " do you wanna really quit";
            string title ="Confirm";
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;          
            DialogResult res;
            res = MessageBox.Show(message, title, btn, icon);
            if (res == DialogResult.Yes)
            {
                return;
            }
            else
            {
                 e.Cancel=true;
            }

        }
    }
}
