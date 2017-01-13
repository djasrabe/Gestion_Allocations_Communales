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
    public partial class AjouterPayement : Form
    {
        public AjouterPayement()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                AccesBD obj = new AccesBD();
                try
                {
                    object[] tabvaleur = new object[5];

                    tabvaleur[0] = dateTimePicker1.Value.Date;
                    tabvaleur[1] = textBox1.Text;
                    tabvaleur[2] = comboBox1.Text;
                    tabvaleur[3] = comboBox2.Text;

                    tabvaleur[4] = textBox2.Text;

                    obj.Insert("Payement", "Date_Payement,Montant,NumArticle,Annee,Libelle_Payement", 5, tabvaleur);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                    MessageBox.Show("Insertion du payement reussie");

                    DataTable datatable = obj.Visualiser("select NumPayement,Date_Payement,NumArticle,Annee,Libelle_Payement,Montant from Payement ORDER BY NumPayement ASC");//Recharger la liste dans la dataGridview
                    dataGridView1.DataSource = datatable;
                }
                catch
                {
                    MessageBox.Show("Verifiez que le Montant soit bien un chiffre");
                }
            }
            else
            {
                MessageBox.Show("Entrez toutes les valeurs s'il vous plait");
            }

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AjouterPayement_Load(object sender, EventArgs e)
        {
            AccesBD obj1 = new AccesBD();
            DataTable datatable = obj1.Visualiser("select NumPayement,Date_Payement,NumArticle,Annee,Libelle_Payement,Montant from Payement ORDER BY NumPayement ASC");//Recharger la liste dans la dataGridview
            dataGridView1.DataSource = datatable;

            //

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = (dataGridView1.CurrentRow.Cells[5].Value).ToString();  //montant

            textBox2.Text = (dataGridView1.CurrentRow.Cells[4].Value).ToString();
            comboBox1.Text = (dataGridView1.CurrentRow.Cells[2].Value).ToString();  //annee          
            comboBox2.Text = (dataGridView1.CurrentRow.Cells[3].Value).ToString();   //a
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value);

          
            button3.Visible = true;
            button4.Visible = true;
            button1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            comboBox1.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;



            AccesBD obj = new AccesBD();
            try
            {

                obj.Select("Update Payement set Date_Payement=DateValue('" + dateTimePicker1.Value.Date + "'), Montant=" + textBox1.Text + ",Libelle_Payement='" + textBox2.Text + "',NumArticle= '" + comboBox1.Text + "',Annee='" + comboBox2.Text + "' where NumPayement=" + dataGridView1.CurrentRow.Cells[0].Value);

                MessageBox.Show("Modification du Payement reussie");


                button3.Visible = false;
                button4.Visible = false;
                button1.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            catch
            { 
                MessageBox.Show("Verifiez la saisi de vos données et remplissez tous les champs");

                textBox1.Text = "";
                textBox2.Text = "";
            }


            DataTable datatable = obj.Visualiser("select NumPayement,Date_Payement,NumArticle,Annee,Libelle_Payement,Montant from Payement ORDER BY NumPayement ASC");//Recharger la liste dans la dataGridview
            dataGridView1.DataSource = datatable;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            comboBox1.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;



            AccesBD obj = new AccesBD();
            try
            {
                obj.Select("Delete from Payement where NumPayement=" + dataGridView1.CurrentRow.Cells[0].Value);

                MessageBox.Show("Suppression du Payement reussie");

                button3.Visible = false;
                button4.Visible = false;
                button1.Visible = true;

                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            catch 
            {
                MessageBox.Show("Verifiez la saisi des données");
            }


            DataTable datatable = obj.Visualiser("select NumPayement,Date_Payement,NumArticle,Annee,Libelle_Payement,Montant from Payement ORDER BY NumPayement ASC");//Recharger la liste dans la dataGridview
            dataGridView1.DataSource = datatable;
        }

        private void comboBox1_DropDown_1(object sender, EventArgs e)
        {
            AccesBD obj = new AccesBD();
            comboBox1.DataSource = obj.Visualiser("select NumArticle from Article,Chapitre where Article.NumChapitre=Chapitre.NumChapitre and Chapitre.Type='Payement' ORDER BY NumArticle ASC");
            comboBox1.DisplayMember = "NumArticle";
        }

        private void comboBox2_DropDown_1(object sender, EventArgs e)
        {
            AccesBD obj = new AccesBD();
            comboBox2.DataSource = obj.Visualiser("select DISTINCT Annee from Budget,Article,Chapitre where Budget.NumArticle=Article.NumArticle and Article.NumChapitre=Chapitre.NumChapitre and Chapitre.Type='Payement'");
            comboBox2.DisplayMember = "Annee";
        }












    }
}
