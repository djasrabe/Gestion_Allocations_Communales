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
    public partial class RapportJournalier : Form
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
        
        public RapportJournalier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccesBD obj1 = new AccesBD();
            string requete = "select * from Recette where Date_Recette = DateValue('" + dateTimePicker1.Value.Date + "')";
            DataTable datatable = obj1.Visualiser(requete);
            dataGridView1.DataSource = datatable;

            //----

            AccesBD obj2 = new AccesBD();
            string req = "select * from Payement where Date_Payement= DateValue('" + dateTimePicker1.Value.Date + "')";

            DataTable datatable2 = obj2.Visualiser(req);
            dataGridView2.DataSource = datatable2;
            //----

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            //formater chifffre apres la virgule

            label3.Text = (dateTimePicker1.Value.Date).ToString("dd/MM/yyyy");
            label1.Text = (dateTimePicker1.Value.Date).ToString("dd/MM/yyyy");

            // le total

            AccesBD obj3 = new AccesBD();
            string req2 = "select sum(Montant) from Recette where Date_Recette= DateValue('" + dateTimePicker1.Value.Date + "')";

            label7.Text = obj3.Select(req2).ToString(); 
            if (label7.Text=="" ) label7.Text = "00";

            string req3 = "select sum(Montant) from Payement where Date_Payement= DateValue('" + dateTimePicker1.Value.Date + "')";
             label8.Text = obj3.Select(req3).ToString(); 

            if(label8.Text =="") label8.Text="00";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RapportJournalier_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
        }

        Bitmap bitmapLabel, bitmapLabel2;
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0 && dataGridView1.ColumnCount != 0)
            {            
                bitmapLabel = new Bitmap(this.label7.Width, this.label7.Height);
                label7.DrawToBitmap(bitmapLabel, new Rectangle(0, 0, this.label7.Width, this.label7.Height));
                
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
                    MessageBox.Show("Aucune Imprimante n'est installé.");
                };
            }
            else { MessageBox.Show("Aucune donnée à imprimer"); }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {          
            //e.Graphics.DrawImage(bitmap, 100, 200);
            //e.Graphics.DrawImage(bitmapLabel, 180, 170);

            if (bFirstPage == true)
            {
                e.Graphics.DrawImage(bitmapLabel, 180, 170);

                string texte = "Mairie du 5e Arrondissement";
                Font fonttext = new Font("Aparajita", 25, FontStyle.Bold);
                e.Graphics.DrawString(texte, fonttext, Brushes.Black, new Point(350, 50));


                string texte1 = "Recettes effectuées dans la journée du" + " " + label3.Text;
                Font fonttext1 = new Font("Verdana", 10, FontStyle.Bold);
                e.Graphics.DrawString(texte1, fonttext1, Brushes.Blue, new Point(80, 120));

                string texte2 = "TOTAL : " + " ";
                Font fonttext2 = new Font("Verdana", 12, FontStyle.Bold);
                e.Graphics.DrawString(texte2, fonttext2, Brushes.Black, new Point(100, 170));

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
                                iTopMargin = 200;   //e.MarginBounds.Top;      DJAS
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

        //----------------------------------------------------------------------        

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount != 0 && dataGridView2.ColumnCount != 0)
            {               
                //-------------------------------------------dessinner aussi le label
                bitmapLabel2 = new Bitmap(this.label8.Width, this.label8.Height);
                label8.DrawToBitmap(bitmapLabel2, new Rectangle(0, 0, this.label8.Width, this.label8.Height));                           


                //Show the Print Preview Dialog.
                printPreviewDialog2.Document = printDocument2;
                printPreviewDialog2.PrintPreviewControl.Zoom = 1;

                printDocument2.DefaultPageSettings.Landscape = true;

                try
                {
                    printPreviewDialog2.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Aucune Imprimante n'est installé.");
                };
            }
            else { MessageBox.Show("Aucune donnée à imprimer"); }
        }
        
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           if (bFirstPage == true)
            {
                e.Graphics.DrawImage(bitmapLabel2, 180, 170);

                string texte = "Mairie du 5e Arrondissement";
                Font fonttext = new Font("Aparajita", 25, FontStyle.Bold);
                e.Graphics.DrawString(texte, fonttext, Brushes.Black, new Point(350, 50));


                string texte1 = "Depenses effectuées dans la journée du" + " " + label3.Text;
                Font fonttext1 = new Font("Verdana", 10, FontStyle.Bold);
                e.Graphics.DrawString(texte1, fonttext1, Brushes.Blue, new Point(80, 120));

                string texte2 = "TOTAL : " + " ";
                Font fonttext2 = new Font("Verdana", 12, FontStyle.Bold);
                e.Graphics.DrawString(texte2, fonttext2, Brushes.Black, new Point(100, 170));

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
                    foreach (DataGridViewColumn GridCol in dataGridView2.Columns)
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
                while (iRow <= dataGridView2.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView2.Rows[iRow];
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
                                String strDate = DateTime.Now.ToLongDateString() + "  " +
                                DateTime.Now.ToShortTimeString();

                            //String strDate = "Recettes de la periode";

                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dataGridView1.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dataGridView2.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("Customer Summary",
                                new Font(new Font(dataGridView2.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            if (bFirstPage == true)
                            {
                                iTopMargin = 200;   //e.MarginBounds.Top;      DJAS
                            }
                            else iTopMargin = 90;



                            foreach (DataGridViewColumn GridCol in dataGridView2.Columns)
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

        private void printDocument2_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                foreach (DataGridViewColumn dgvGridCol in dataGridView2.Columns)
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
