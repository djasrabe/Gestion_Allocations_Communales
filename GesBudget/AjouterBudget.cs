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
    public partial class AjouterBudget : Form
    {
        public AjouterBudget()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object[] tabvaleur = new object[3];
            tabvaleur[0] = comboBox1.Text;;
            tabvaleur[1] = comboBox2.Text;
            tabvaleur[2] = textBox2.Text;
            


            if (comboBox1.Text != "" && textBox2.Text != "" && comboBox2.Text != "")
            {

                AccesBD obj = new AccesBD();
                try
                {
                    
                    obj.Insert("Budget", "NumArticle,Annee,Montant", 3, tabvaleur);
                    
                    MessageBox.Show("Insertion du budget reussie");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    //textBox3.Text = "";
                    comboBox1.Text = "";
                }
                catch
                {
                    MessageBox.Show("Verifiez bien les donnée saisies, Sinon le budget pour cet article et cet exercice existe déja ");
                }




                DataTable datatable = obj.Visualiser("select * from Budget ORDER BY NumArticle ASC");//Recharger la liste dans la dataGridview
                dataGridView1.DataSource = datatable;

            }
            else
            {
                MessageBox.Show("Entrez toutes les valeurs s'il vous plait");
            }

        }

        private void AjouterBudget_Load(object sender, EventArgs e)
        {
            AccesBD obj1 = new AccesBD();
            DataTable datatable = obj1.Visualiser("select * from Budget ORDER BY NumArticle ASC");
            dataGridView1.DataSource = datatable;

            //

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            comboBox2.Enabled = false;

            comboBox1.Text = (dataGridView1.CurrentRow.Cells[0].Value).ToString();  //     numart    
            comboBox2.Text = (dataGridView1.CurrentRow.Cells[1].Value).ToString();   //   annee
            textBox2.Text = (dataGridView1.CurrentRow.Cells[2].Value).ToString();  //


            comboBox1.Enabled = false;
            button3.Visible = true;
            button4.Visible = true;
            button1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // comboBox2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;

            AccesBD obj = new AccesBD();
            try
            {

                obj.Select("Update Budget set Montant='" + textBox2.Text + "' where NumArticle=" + comboBox1.Text +"AND Annee='"+ comboBox2.Text+"'");

                MessageBox.Show("Mise a jour reussie du Budget ");
               
                textBox2.Text = "";
                
            }
            catch
            {
                MessageBox.Show("Remplissez tous les champs");
            }

            DataTable datatable = obj.Visualiser("select * from Budget ORDER BY NumArticle ASC");//Recharger la liste dans la dataGridview
            dataGridView1.DataSource = datatable;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            button3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;



            AccesBD obj = new AccesBD();
            try
            {
                obj.Select("Delete from Budget where NumArticle=" + dataGridView1.CurrentRow.Cells[0].Value + "And Annee='" + dataGridView1.CurrentRow.Cells[1].Value +"'");

                MessageBox.Show("Suppression du Budge reussie");

                button3.Visible = false;
                button4.Visible = false;
                button1.Visible = true;

                textBox2.Text = "";
            }
            catch
            {
                MessageBox.Show("Verifiez la saisi des données");
            }


            DataTable datatable = obj.Visualiser("select * from Budget ORDER BY NumArticle ASC");//Recharger la liste dans la dataGridview
            dataGridView1.DataSource = datatable;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void comboBox1_DropDown_1(object sender, EventArgs e)
        {
            AccesBD obj = new AccesBD();
            comboBox1.DataSource = obj.Visualiser("select NumArticle from Article ORDER BY NumArticle ASC");
            comboBox1.DisplayMember = "NumArticle";
            comboBox1.ValueMember = "NumArticle";
        }
    }
}
