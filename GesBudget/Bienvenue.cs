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
    public partial class Bienvenue : Form
    {
        public Bienvenue()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Interface maf = new Interface();
            maf.Show();

            this.Visible = false;
        }

        private void Bienvenue_Load(object sender, EventArgs e)
        {
            //splitContainer1.Panel2.Controls.Clear();
            //splitContainer1.Panel2.Controls.Add(new UserControl_Bienvenue());

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);

            if
                (progressBar1.Value == 100) timer1.Stop();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
