using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GesBudget
{
    public partial class Interface : Form
    {
        public Interface()
       {
           Thread t = new Thread(new ThreadStart(splash));
           t.Start();
           Thread.Sleep(3500);

            InitializeComponent();

            t.Abort();
        }

        private void ajouterUnArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterArticle aj = new AjouterArticle();
            aj.MdiParent = this;
            aj.Show();
        }

        private void ajouterUnPayeementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterPayement pay = new AjouterPayement();
            pay.MdiParent = this;
            pay.Show();
        }

        private void ajouterUneRecetteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterRecette rec = new AjouterRecette();
            rec.MdiParent = this;
            rec.Show();
        }

        private void ajouterUnChapitreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterChapitre chap = new AjouterChapitre();
            chap.MdiParent = this;
            chap.Show();
        }

        private void rapportParPeriodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RapportPeriodique rap = new RapportPeriodique();
            rap.MdiParent = this;
            rap.Show();

        }

        private void rapportParArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RapportArticle rap = new RapportArticle();
            rap.MdiParent = this;
            rap.Show();
        }

        private void rapportParChapitreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RapportChapitre rap = new RapportChapitre();
            rap.MdiParent = this;
            rap.Show();
        }

        private void listeDesChapitresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeChapitre lsc = new ListeChapitre();
            lsc.MdiParent = this;
            lsc.Show();
        }

        private void listeDesArticlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeArticle ls=new ListeArticle();
            ls.MdiParent = this;
            ls.Show();
        }

        private void listeDesPayementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListePayement lp = new ListePayement();
            lp.MdiParent = this;
            lp.Show();
        }

        private void listeDesRecettesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeRecette lr = new ListeRecette();
            lr.MdiParent = this;
            lr.Show();
        }

        private void voletDepenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RapportGlobalPayement rp = new RapportGlobalPayement();
            rp.MdiParent = this;
            rp.Show();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) this.Close(); //ActiveMdiChild.Close();
            else MessageBox.Show("Fermez dabord les fenetres actives"); 
        }

        private void rapportJournalierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RapportJournalier rj = new RapportJournalier();
            rj.MdiParent = this;
            rj.Show();
        }

        private void voletRecetteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RapportGlobalRecette rp = new RapportGlobalRecette();
            rp.MdiParent = this;
            rp.Show();
        }

        private void listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListePrevisionsBudgetaire lb = new ListePrevisionsBudgetaire();
            lb.MdiParent = this;
            lb.Show();
        }

        private void ajouterUnBudgetSuivantUnArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterBudget bd = new AjouterBudget();
            bd.MdiParent = this;
            bd.Show();
            
        }

     
        private void Interface_Load(object sender, EventArgs e)
        {

        }

        public void splash()  //
        {
        Application.Run(new Bienvenue());
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Apropos ap = new Apropos();
            ap.MdiParent = this;
            ap.Show();
        }

        
    }
}
