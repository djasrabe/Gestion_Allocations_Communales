using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GesBudget
{
    public partial class AjouterArticle : Form
    {
        public AjouterArticle()
        {
            InitializeComponent();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            AccesBD obj = new AccesBD();
            comboBox1.DataSource = obj.Visualiser("select * from Chapitre ORDER BY NumChapitre ASC");
            comboBox1.DisplayMember = "NumChapitre";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            object[] tabvaleur = new object[4];
            tabvaleur[0] = textBox1.Text;
            tabvaleur[1] = textBox2.Text;
           // tabvaleur[2] = textBox3.Text;
            tabvaleur[2] = comboBox1.Text;

          
            if (textBox1.Text != "" && textBox2.Text != ""  && comboBox1.Text !="")
            {

                 AccesBD obj = new AccesBD();
                try
                {
                    obj.Insert("Article", "NumArticle,Libelle,NumChapitre", 3, tabvaleur);
                    MessageBox.Show("Insertion de l'article reussie");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    //textBox3.Text = "";
                    comboBox1.Text = "";
                }
                catch
                {
                    MessageBox.Show("Verifiez que le numero soit bien un chiffre, Sinon cet article existe deja ");
                }




                DataTable datatable = obj.Visualiser("select * from Article ORDER BY NumArticle ASC");//Recharger la liste dans la dataGridview
                dataGridView1.DataSource = datatable;

            }
            else
            {
                MessageBox.Show("Entrez toutes les valeurs s'il vous plait");
            }

          
        }

        private void AjouterArticle_Load(object sender, EventArgs e)
        {
            AccesBD obj1 = new AccesBD();
            DataTable datatable = obj1.Visualiser("select * from Article ORDER BY NumArticle ASC");       
            dataGridView1.DataSource = datatable;

            //

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;

            textBox1.Visible = true;

            AccesBD obj = new AccesBD();
            try
            {
                
                obj.Select("Update Article set Libelle='" + textBox2.Text + "',NumChapitre= '" + comboBox1.Text +  "' where NumArticle=" + comboBox2.Text);

                MessageBox.Show("Mise a jour reussie");
                
                textBox2.Text = "";
                comboBox2.Enabled = true;
                comboBox1.Enabled = true;
            }
            catch 
            {
                MessageBox.Show("Remplissez tous les champs et verifiez les données saisies");
            }

            DataTable datatable = obj.Visualiser("select * from Article ORDER BY NumArticle ASC");//Recharger la liste dans la dataGridview
            dataGridView1.DataSource = datatable;
        
        
        
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Visible = true;
            textBox1.Visible = false;

            comboBox2.Text = (dataGridView1.CurrentRow.Cells[0].Value).ToString();
            textBox2.Text = (dataGridView1.CurrentRow.Cells[1].Value).ToString();
            comboBox1.Text = (dataGridView1.CurrentRow.Cells[2].Value).ToString();

            comboBox2.Enabled = false;
            comboBox1.Enabled = true;

            button3.Visible = true;
            button4.Visible = true;
            button1.Visible = false;
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

                obj.Select("Delete from Article where NumArticle=" + comboBox2.Text);

                MessageBox.Show("L'Article a bien été supprimé");
               
                textBox2.Text = "";
                comboBox1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Cet Article ne peut pas etre supprimé car il contient des Payements/Recettes qui lui sont liés ");
            }


            DataTable datatable = obj.Visualiser("select * from Article ORDER BY NumArticle ASC");//Recharger la liste dans le dataGridview
            dataGridView1.DataSource = datatable;
        }
    }
}
