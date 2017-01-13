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
    public partial class RapportGlobalPayement : Form
    {
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


        public RapportGlobalPayement()
        {
            InitializeComponent();
        }

        public void Rapport(string exercice)
        {
            label8.Text = "00";
            label7.Text = "00";
            label10.Text = "00";

            AccesBD obj = new AccesBD();
            // DataTable datatable = obj.Visualiser("select Chapitre.NumChapitre,Article.NumArticle,Article.Libelle,Budget.Montant as Budget,sum(Payement.Montant) as Total_Payement    FROM Chapitre,Article,Payement,Budget         WHERE     Chapitre.Type='Payement'  AND Budget.Annee='" + exercice + "' AND Payement.Annee='" + exercice + "' AND    Payement.NumArticle= Budget.NumArticle and Budget.NumArticle=Article.NumArticle and Article.NumChapitre=Chapitre.NumChapitre Group by Chapitre.NumChapitre,Article.NumArticle,Budget.NumArticle,Article.Libelle,Budget.Montant");

            DataTable datatable = obj.Visualiser("select Chapitre.NumChapitre,Article.NumArticle,Article.Libelle,Budget.Montant as Budget,sum(Payement.Montant) as Total_Payement, (Budget.Montant-Total_Payement) as Reste , Round(((Total_Payement * 100)/Budget.Montant),2) as Taux_Realisation    FROM Chapitre,Article,Payement,Budget       WHERE     Chapitre.Type='Payement'  AND Budget.Annee='" + exercice + "' AND Payement.Annee='" + exercice + "' AND    Payement.NumArticle= Budget.NumArticle and Budget.NumArticle=Article.NumArticle and Article.NumChapitre=Chapitre.NumChapitre Group by Chapitre.NumChapitre,Article.NumArticle,Budget.NumArticle,Article.Libelle,Budget.Montant");
            dataGridView1.DataSource = datatable;



            //AccesBD obj = new AccesBD();
            //DataTable datatable = obj.Visualiser("select Chapitre.NumChapitre,Article.NumArticle,Article.Libelle,Budget.Montant as Budget,sum(Recette.Montant) as Total_Recette,Round(((Total_Recette * 100)/Budget.Montant),2) as Taux_Realisation   FROM Chapitre,Article,Recette,Budget         WHERE     Chapitre.Type='Recette'  AND Budget.Annee='" + exercice + "' AND Recette.Annee='" + exercice + "' AND    Recette.NumArticle= Budget.NumArticle and Budget.NumArticle=Article.NumArticle and Article.NumChapitre=Chapitre.NumChapitre Group by Chapitre.NumChapitre,Article.NumArticle,Budget.NumArticle,Article.Libelle,Budget.Montant");
            //dataGridView1.DataSource = datatable;


           // ---------------- gerer l'affichage budget annuel
            AccesBD obj2 = new AccesBD();
            object budget=obj2.Select("select sum(Budget.Montant) from Budget,Article,Chapitre Where Annee='"+comboBox1.Text + "'" + "and Budget.NumArticle=Article.NumArticle and Article.NumChapitre=Chapitre.NumChapitre and Chapitre.Type='Payement'");
            object payement=obj2.Select("select sum(Montant) from Payement where Annee='"+comboBox1.Text +"'");

            if (budget != null)
            {
                label7.Text = "00";
                label7.Text = budget.ToString();


                label11.Text = budget.ToString(); //doit afficher le reste sur budget,mais prend dabord la valeur du budget
               
            }
            


            if (payement != null)
            {
                label8.Text = "00";
                label8.Text = payement.ToString();
            }


            try
            {
                if (payement != null && budget != null)
                {
                    Double pourc = (Convert.ToDouble(payement) * 100) / Convert.ToDouble(budget);
                    label10.Text = Math.Round(pourc, 2).ToString() + "%";
                }


                if (payement != null && budget != null)
                {

                    Double reste = (Convert.ToDouble(budget)) - (Convert.ToDouble(payement));
                    label11.Text = reste.ToString();
                }


            }
            catch
            {
                label2.Text = comboBox1.Text;
                label8.Text = "00";
                label7.Text = "00";
                label10.Text = "00";
                MessageBox.Show("Cet Exercice Budgetaire n'a pas encore de Payement declaré ou de budget Inscrit"); 
            }
          



            //

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("", typeof(string)), new DataColumn("", typeof(string)) });
            dt.Rows.Add("Budget Annuel:", label7.Text);
            dt.Rows.Add("Total Payements:", label8.Text);
            dt.Rows.Add("% Execution:", label10.Text);
            dataGridView2.DataSource = dt;

                    

        }
        private void RapportGlobalPayement_Load(object sender, EventArgs e)
        {
            
            comboBox1.SelectedIndex = 5;   //par defaut annee 2015
            label2.Text = comboBox1.Text;
            
            Rapport(comboBox1.Text);


       

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            Rapport(comboBox1.Text);
            label2.Text = comboBox1.Text;
            
        }



        Bitmap bitmap,bitmap2;
        private void button1_Click(object sender, EventArgs e)
        {


 if (dataGridView1.RowCount!=0  && dataGridView1.ColumnCount != 0)
            {
               
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;

                printDocument1.DefaultPageSettings.Landscape = true;


                //----------------------------------------------second dtgrvw

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

                try
                { 
                    printPreviewDialog1.ShowDialog(); 
                }
                catch 
                {  
                    MessageBox.Show("Aucune Imprimante n'est installé."); 
                };

                
            }
            else { MessageBox.Show("Aucune données à imprimer");}
               
            
            
        }
        //int printrow;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
                    
                
            if (bFirstPage == true)
            {
                //
                e.Graphics.DrawImage(bitmap2, 90, 170);


                string texte = "Mairie du 5e Arrondissement";
                Font fonttext = new Font("Aparajita", 25, FontStyle.Bold);
                e.Graphics.DrawString(texte, fonttext, Brushes.Black, new Point(350, 50));


                string texte1 = "EXECUTION BUDGETAIRE - VOLET DEPENSES, " + " Execice " + " " + comboBox1.Text;
                Font fonttext1 = new Font("Verdana", 16, FontStyle.Regular);
                e.Graphics.DrawString(texte1, fonttext1, Brushes.Blue, new Point(190, 120));

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
                                iTopMargin = 240;   //e.MarginBounds.Top;      DJAS
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

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            //label5.Text = "00";
           
        }

       


    }
}
