using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GesBudget
{
    public partial class AjouterChapitre : Form
    {
        public AjouterChapitre()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object [] tabvaleur = new object[4];
                    tabvaleur[0] = textBox1.Text;
                    tabvaleur[1] = textBox2.Text;
                    //tabvaleur[2] = textBox3.Text;
                    tabvaleur[2] = comboBox1.Text;


                    if (textBox1.Text != "" && textBox2.Text != ""  && comboBox1.Text != "")
                    {
                        AccesBD obj = new AccesBD();

                        try
                        {
                            obj.Insert("Chapitre", "NumChapitre,Libelle,Type", 3, tabvaleur);
                            MessageBox.Show("Insertion d'un nouveau Chapitre reussie");

                            textBox1.Text = "";
                            textBox2.Text = "";
                           // textBox3.Text = "";
                            comboBox1.Text = "";
                        }
                        catch
                        {
                            MessageBox.Show("Verifiez que le numero sois bien un chiffre, Sinon ce Chapitre existe deja ");
                        }


                        DataTable datatable = obj.Visualiser("select * from Chapitre ORDER BY NumChapitre ASC");//Recharger la liste dans la dataGridview
                        dataGridView1.DataSource = datatable;
                    }
                    else
                    {
                        MessageBox.Show("Entrez toutes les valeurs s'il vous plait");
                    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AjouterChapitre_Load(object sender, EventArgs e)
        {
            AccesBD obj = new AccesBD();
            DataTable datatable = obj.Visualiser("select * from Chapitre ORDER BY NumChapitre ASC");
            dataGridView1.DataSource = datatable;

            //---

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Visible = true;
            textBox1.Visible = false;

            
            comboBox2.Text = (dataGridView1.CurrentRow.Cells[0].Value).ToString();
            textBox2.Text = (dataGridView1.CurrentRow.Cells[1].Value).ToString();
            comboBox1.Text = (dataGridView1.CurrentRow.Cells[2].Value).ToString();

            comboBox2.Enabled = false;
            button3.Visible = true;
            button4.Visible = true;
            button1.Visible = false;

           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;

            
            AccesBD obj = new AccesBD();
            try
            {
                obj.Select("Update Chapitre set Libelle='" + textBox2.Text + "', Type='" + comboBox1.Text + "' where NumChapitre=" + comboBox2.Text );

                MessageBox.Show("Mise a jour reussie");
                textBox2.Text = "";

            }
            catch 
            {
                MessageBox.Show("Remplissez tous les champs et verifiez vos données");
            }
            DataTable datatable = obj.Visualiser("select * from Chapitre ORDER BY NumChapitre ASC");//Recharger la liste dans la dataGridview
            dataGridView1.DataSource = datatable;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;
            textBox1.Visible = true;
            
            
            AccesBD obj = new AccesBD();
            try
            {
                
                obj.Select("Delete from Chapitre where NumChapitre=" + comboBox2.Text);

                MessageBox.Show("Le Chapitre a bien été supprimé");
                textBox1.Visible = true;
                textBox2.Text = "";
            }
            catch 
            {
                MessageBox.Show("Ce Chapitre ne peut pas etre supprimé car il contient des articles qui lui sont liés ");
            }


            DataTable datatable = obj.Visualiser("select * from Chapitre ORDER BY NumChapitre ASC");//Recharger la liste dans la dataGridview
            dataGridView1.DataSource = datatable;
        }
    }
}
