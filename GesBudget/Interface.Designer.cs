namespace GesBudget
{
    partial class Interface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executionDuBudgetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voletDepenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voletRecetteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesPayementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesRecettesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesChapitresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesArticlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnPayeementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUneRecetteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnChapitreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnBudgetSuivantUnArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rapportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rapportParPeriodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rapportParChapitreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rapportParArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rapportJournalierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.vueToolStripMenuItem,
            this.operationsToolStripMenuItem,
            this.rapportsToolStripMenuItem,
            this.aProposToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(819, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executionDuBudgetToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // executionDuBudgetToolStripMenuItem
            // 
            this.executionDuBudgetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voletDepenseToolStripMenuItem,
            this.voletRecetteToolStripMenuItem});
            this.executionDuBudgetToolStripMenuItem.Name = "executionDuBudgetToolStripMenuItem";
            this.executionDuBudgetToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.executionDuBudgetToolStripMenuItem.Text = "Execution du Budget";
            // 
            // voletDepenseToolStripMenuItem
            // 
            this.voletDepenseToolStripMenuItem.Name = "voletDepenseToolStripMenuItem";
            this.voletDepenseToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.voletDepenseToolStripMenuItem.Text = "Volet Depenses";
            this.voletDepenseToolStripMenuItem.Click += new System.EventHandler(this.voletDepenseToolStripMenuItem_Click);
            // 
            // voletRecetteToolStripMenuItem
            // 
            this.voletRecetteToolStripMenuItem.Name = "voletRecetteToolStripMenuItem";
            this.voletRecetteToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.voletRecetteToolStripMenuItem.Text = "Volet Recettes";
            this.voletRecetteToolStripMenuItem.Click += new System.EventHandler(this.voletRecetteToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // vueToolStripMenuItem
            // 
            this.vueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesPayementsToolStripMenuItem,
            this.listeDesRecettesToolStripMenuItem,
            this.listeDesChapitresToolStripMenuItem,
            this.listeDesArticlesToolStripMenuItem,
            this.listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem});
            this.vueToolStripMenuItem.Name = "vueToolStripMenuItem";
            this.vueToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.vueToolStripMenuItem.Text = "Vue";
            // 
            // listeDesPayementsToolStripMenuItem
            // 
            this.listeDesPayementsToolStripMenuItem.Name = "listeDesPayementsToolStripMenuItem";
            this.listeDesPayementsToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.listeDesPayementsToolStripMenuItem.Text = "Liste des Payements";
            this.listeDesPayementsToolStripMenuItem.Click += new System.EventHandler(this.listeDesPayementsToolStripMenuItem_Click);
            // 
            // listeDesRecettesToolStripMenuItem
            // 
            this.listeDesRecettesToolStripMenuItem.Name = "listeDesRecettesToolStripMenuItem";
            this.listeDesRecettesToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.listeDesRecettesToolStripMenuItem.Text = "Liste des Recettes";
            this.listeDesRecettesToolStripMenuItem.Click += new System.EventHandler(this.listeDesRecettesToolStripMenuItem_Click);
            // 
            // listeDesChapitresToolStripMenuItem
            // 
            this.listeDesChapitresToolStripMenuItem.Name = "listeDesChapitresToolStripMenuItem";
            this.listeDesChapitresToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.listeDesChapitresToolStripMenuItem.Text = "Liste des Chapitres";
            this.listeDesChapitresToolStripMenuItem.Click += new System.EventHandler(this.listeDesChapitresToolStripMenuItem_Click);
            // 
            // listeDesArticlesToolStripMenuItem
            // 
            this.listeDesArticlesToolStripMenuItem.Name = "listeDesArticlesToolStripMenuItem";
            this.listeDesArticlesToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.listeDesArticlesToolStripMenuItem.Text = "Liste des Articles";
            this.listeDesArticlesToolStripMenuItem.Click += new System.EventHandler(this.listeDesArticlesToolStripMenuItem_Click);
            // 
            // listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem
            // 
            this.listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem.Name = "listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem";
            this.listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem.Size = new System.Drawing.Size(327, 22);
            this.listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem.Text = "Liste des Previsions budgetaires par Article";
            this.listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem.Click += new System.EventHandler(this.listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem_Click);
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnPayeementToolStripMenuItem,
            this.ajouterUneRecetteToolStripMenuItem,
            this.ajouterUnChapitreToolStripMenuItem,
            this.ajouterUnArticleToolStripMenuItem,
            this.ajouterUnBudgetSuivantUnArticleToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(85, 21);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // ajouterUnPayeementToolStripMenuItem
            // 
            this.ajouterUnPayeementToolStripMenuItem.Name = "ajouterUnPayeementToolStripMenuItem";
            this.ajouterUnPayeementToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.ajouterUnPayeementToolStripMenuItem.Text = "Ajouter un Payement";
            this.ajouterUnPayeementToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnPayeementToolStripMenuItem_Click);
            // 
            // ajouterUneRecetteToolStripMenuItem
            // 
            this.ajouterUneRecetteToolStripMenuItem.Name = "ajouterUneRecetteToolStripMenuItem";
            this.ajouterUneRecetteToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.ajouterUneRecetteToolStripMenuItem.Text = "Ajouter une Recette";
            this.ajouterUneRecetteToolStripMenuItem.Click += new System.EventHandler(this.ajouterUneRecetteToolStripMenuItem_Click);
            // 
            // ajouterUnChapitreToolStripMenuItem
            // 
            this.ajouterUnChapitreToolStripMenuItem.Name = "ajouterUnChapitreToolStripMenuItem";
            this.ajouterUnChapitreToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.ajouterUnChapitreToolStripMenuItem.Text = "Ajouter un Chapitre";
            this.ajouterUnChapitreToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnChapitreToolStripMenuItem_Click);
            // 
            // ajouterUnArticleToolStripMenuItem
            // 
            this.ajouterUnArticleToolStripMenuItem.Name = "ajouterUnArticleToolStripMenuItem";
            this.ajouterUnArticleToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.ajouterUnArticleToolStripMenuItem.Text = "Ajouter un Article";
            this.ajouterUnArticleToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnArticleToolStripMenuItem_Click);
            // 
            // ajouterUnBudgetSuivantUnArticleToolStripMenuItem
            // 
            this.ajouterUnBudgetSuivantUnArticleToolStripMenuItem.Name = "ajouterUnBudgetSuivantUnArticleToolStripMenuItem";
            this.ajouterUnBudgetSuivantUnArticleToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.ajouterUnBudgetSuivantUnArticleToolStripMenuItem.Text = "Ajouter un Budget suivant un Article";
            this.ajouterUnBudgetSuivantUnArticleToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnBudgetSuivantUnArticleToolStripMenuItem_Click);
            // 
            // rapportsToolStripMenuItem
            // 
            this.rapportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rapportParPeriodeToolStripMenuItem,
            this.rapportParChapitreToolStripMenuItem,
            this.rapportParArticleToolStripMenuItem,
            this.rapportJournalierToolStripMenuItem});
            this.rapportsToolStripMenuItem.Name = "rapportsToolStripMenuItem";
            this.rapportsToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.rapportsToolStripMenuItem.Text = "Rapports";
            // 
            // rapportParPeriodeToolStripMenuItem
            // 
            this.rapportParPeriodeToolStripMenuItem.Name = "rapportParPeriodeToolStripMenuItem";
            this.rapportParPeriodeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.rapportParPeriodeToolStripMenuItem.Text = "Par Periode";
            this.rapportParPeriodeToolStripMenuItem.Click += new System.EventHandler(this.rapportParPeriodeToolStripMenuItem_Click);
            // 
            // rapportParChapitreToolStripMenuItem
            // 
            this.rapportParChapitreToolStripMenuItem.Name = "rapportParChapitreToolStripMenuItem";
            this.rapportParChapitreToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.rapportParChapitreToolStripMenuItem.Text = "Par Chapitre";
            this.rapportParChapitreToolStripMenuItem.Click += new System.EventHandler(this.rapportParChapitreToolStripMenuItem_Click);
            // 
            // rapportParArticleToolStripMenuItem
            // 
            this.rapportParArticleToolStripMenuItem.Name = "rapportParArticleToolStripMenuItem";
            this.rapportParArticleToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.rapportParArticleToolStripMenuItem.Text = "Par Article";
            this.rapportParArticleToolStripMenuItem.Click += new System.EventHandler(this.rapportParArticleToolStripMenuItem_Click);
            // 
            // rapportJournalierToolStripMenuItem
            // 
            this.rapportJournalierToolStripMenuItem.Name = "rapportJournalierToolStripMenuItem";
            this.rapportJournalierToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.rapportJournalierToolStripMenuItem.Text = "Journalier";
            this.rapportJournalierToolStripMenuItem.Click += new System.EventHandler(this.rapportJournalierToolStripMenuItem_Click);
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.aProposToolStripMenuItem.Text = "A Propos";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(819, 463);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Interface";
            this.Text = "ExecBudget_5e Arrondissement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Interface_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnPayeementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneRecetteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rapportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rapportParPeriodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rapportParChapitreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rapportParArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rapportJournalierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDesPayementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDesRecettesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnChapitreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDesChapitresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDesArticlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executionDuBudgetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voletDepenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voletRecetteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDesPrevisionsBudgetairesParArticlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnBudgetSuivantUnArticleToolStripMenuItem;
    }
}