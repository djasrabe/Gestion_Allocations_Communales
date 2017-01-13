using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace GesBudget
{
    public partial class RapportArticle : Form
    {
        public int val = 0;

        #region Member Variables
        //const string strConnectionString = "data source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;";
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        #endregion
        public RapportArticle()
        {
            InitializeComponent();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            AccesBD obj = new AccesBD();
            comboBox1.DataSource = obj.Visualiser("select NumArticle from Article ORDER BY NumArticle ASC");
            comboBox1.DisplayMember = "NumArticle";
            comboBox1.ValueMember = "NumArticle";
            val = (int)comboBox1.SelectedValue;

            label5.Text = "00";
            label6.Text = "00";
            label7.Text = "00";
            label10.Text = "00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "00";
            label6.Text = "00";
            label10.Text = "00";
            label7.Text = "00%";
            
            try
            {
            val = (int)comboBox1.SelectedValue;

            AccesBD obj2 = new AccesBD();
            object cont = obj2.Select("select Type from Chapitre,Article where Article.NumChapitre=Chapitre.NumChapitre and NumArticle=" + val);
            string type = (string)cont;
           // MessageBox.Show(type);

            string req = "select * from Payement where NumArticle=" + comboBox1.SelectedValue + "and Annee=" + "'" + comboBox2.Text + "'and  Date_Payement Between DateValue('" + dateTimePicker1.Value.Date + "') and DateValue('" + dateTimePicker2.Value.Date + "') ORDER BY Date_Payement";
            string req2 = "select * from Recette where NumArticle=" + comboBox1.SelectedValue + "and Annee=" + "'" + comboBox2.Text + "'and  Date_Recette  Between DateValue('" + dateTimePicker1.Value.Date + "') and DateValue('" + dateTimePicker2.Value.Date + "') ORDER BY Date_Recette"; ;

                       
            DataTable datatable=new DataTable();

            


                if (type == "Payement")
                {
                    datatable = obj2.Visualiser(req);
                    //Faire la somme des montant d'un article sur la table Payement
                    object Montant = obj2.Select("select sum(Montant) from Payement where NumArticle=" + comboBox1.SelectedValue + "and Annee= "+"'"+ comboBox2.Text +"'" + "and Date_Payement Between DateValue('" + dateTimePicker1.Value.Date + "') and DateValue('" + dateTimePicker2.Value.Date + "') Group by NumArticle");
                    if (Montant != null)
                    {
                        label5.Text = "00";
                        label5.Text = Montant.ToString(); 
                    }
                    

                    object Budget = obj2.Select("select Montant from Budget where NumArticle=" + comboBox1.SelectedValue + "and Annee=" + "'" + comboBox2.Text + "'");
                    if (Budget != null)
                    {
                        label6.Text = "00";
                        label6.Text = Budget.ToString(); 

                         label10.Text = Budget.ToString(); // ce label doit afficher le reste sur budget, ici il prend dabord le montant du budget avant d'etre ecrasé quand la soustraction sera effective juste en bas ds le code
                    }


                    if (Montant != null && Budget != null)
                    {

                        Double reste = (Convert.ToDouble(Budget)) - (Convert.ToDouble(Montant));
                        label10.Text = reste.ToString();
                    }
                    



                    if (Montant != null && Budget != null)
                    {
                        Double pourc = (Convert.ToDouble(Montant) * 100) / Convert.ToDouble(Budget);
                        //label7.Text = pourc.ToString(".##") + "" + "%";
                        label7.Text = Math.Round(pourc, 2).ToString() + "%";
                    }

                   

                }
                    //fin du if type=payement

                else
                {
                    datatable = obj2.Visualiser(req2);
                    //Faire la somme des montant d'un article sur la table Payement
                    object Montant = obj2.Select("select sum(Montant) from Recette where NumArticle=" + comboBox1.SelectedValue + "and Annee= " + "'" + comboBox2.Text + "'" + "and Date_Recette Between DateValue('" + dateTimePicker1.Value.Date + "') and DateValue('" + dateTimePicker2.Value.Date + "') Group by NumArticle");
                    if (Montant != null)
                    {
                        label5.Text = "00";
                        label5.Text = Montant.ToString();
                    }


                    object Budget = obj2.Select("select Montant from Budget where NumArticle=" + comboBox1.SelectedValue + "and Annee=" + "'" + comboBox2.Text + "'");
                    if (Budget != null)
                    {
                        label6.Text = "00";
                        label6.Text = Budget.ToString();
                        //

                        label10.Text = Budget.ToString();// pour afficher reste sur budget, prend par defaut la valeur du budget avant d'etre ecrasé par la reponse de la soustraction plus en bas
                    }

                    if (Montant != null && Budget != null)
                    {

                        Double reste = (Convert.ToDouble(Budget)) - (Convert.ToDouble(Montant));
                        label10.Text = reste.ToString();
                    }


                    if (Montant != null && Budget != null)
                    {
                        Double pourc = (Convert.ToDouble(Montant) * 100) / Convert.ToDouble(Budget);
                        //label7.Text = pourc.ToString(".##") + "" + "%";
                        label7.Text = Math.Round(pourc, 2).ToString() + "%";
                    }

                }

                //
                dataGridView1.DataSource = datatable;
            }


            catch
            {
                MessageBox.Show("Assurez vous d'avoir choisi un numero d'Article et une Année dans la liste");

            }

            
            /////-------------------

           


            //--------------------------
           // dataGridView2.Columns.Add("hy","");//("taux", "% Execution");


            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2]{new DataColumn("", typeof(string)),new DataColumn("", typeof(string))});
            dt.Rows.Add("total :", label5.Text);
            dt.Rows.Add("Budget :", label6.Text);
            dt.Rows.Add("Reste sur Budget :", label10.Text);
            dt.Rows.Add("% Execution", label7.Text);
            dataGridView2.DataSource = dt;

           

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RapportArticle_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;


            dataGridView2.Visible = false;
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            AccesBD obj = new AccesBD();
            comboBox2.DataSource = obj.Visualiser("select Distinct Annee from Budget ");
            comboBox2.DisplayMember = "Annee";
            comboBox2.ValueMember = "Annee";
            
        }

        Bitmap bitmap,bitmap2;
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0 && dataGridView1.ColumnCount != 0)
            {
                int height2 = dataGridView2.Height;
                dataGridView2.Height = dataGridView2.RowCount * dataGridView2.RowTemplate.Height;


                bitmap2 = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
                dataGridView2.DrawToBitmap(bitmap2, new Rectangle(0, 0, this.dataGridView2.Width, this.dataGridView2.Height));

                //Resize DataGridView back to original height.
                dataGridView2.Height = height2;

                //-----------------------------------------------

                //Show the Print Preview Dialog.
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;

                printDocument1.DefaultPageSettings.Landscape = true;

                try
                {
                    printPreviewDialog1.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Aucune Imprimante n'est installée.");
                };
            }
            else { MessageBox.Show("Aucune données à imprimer"); }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(bitmap, 100, 270);
            //e.Graphics.DrawImage(bitmap2, 100, 170);


            if (bFirstPage == true)
            {
                e.Graphics.DrawImage(bitmap2, 100, 170);

                string texte = "Mairie du 5e Arrondissement";
                Font fonttext = new Font("Aparajita", 25, FontStyle.Bold);
                e.Graphics.DrawString(texte, fonttext, Brushes.Black, new Point(350, 50));


                string texte1 = "Operations effectuées sur l'Article " + " " + comboBox1.Text + ", " + "Exercice :" + " " + comboBox2.Text + "  , " + " Periode du " + "  " + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy") + " " + "Au" + " " + dateTimePicker2.Value.Date.ToString("dd/MM/yyyy");
                Font fonttext1 = new Font("Verdana", 10, FontStyle.Bold);
                e.Graphics.DrawString(texte1, fonttext1, Brushes.Blue, new Point(80, 120));

                Pen pen = new Pen(Color.Gray);

                e.Graphics.DrawLine(pen, new Point(10, 100), new Point(1080, 100));
            }





            //-------------------------------------

            try
            {
                //Set the left margin
                int iLeftMargin = 80;          // e.MarginBounds.Left      DJAS;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }


                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            //e.Graphics.DrawString("Mairie du 5e Arrondissement",
                            //    new Font(dataGridView1.Font, FontStyle.Bold),Brushes.Black, e.MarginBounds.Left,
                            //    e.MarginBounds.Top - e.Graphics.MeasureString("Mairie du 5e Arrondissementy",
                            //    new Font(dataGridView1.Font, FontStyle.Bold),
                            //    e.MarginBounds.Width).Height - 13);
                            //



                            String strDate = DateTime.Now.ToLongDateString() + "  " +
                                DateTime.Now.ToShortTimeString();

                            //String strDate = "Recettes de la periode";


                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dataGridView1.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("Customer Summary",
                                new Font(new Font(dataGridView1.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            if (bFirstPage == true)
                            {
                                iTopMargin = 300;   //e.MarginBounds.Top;      DJAS
                            }
                            else iTopMargin = 90;



                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }


        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
