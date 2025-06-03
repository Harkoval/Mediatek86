namespace Mediatek86.view
{
    partial class FormMediatheque
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
            this.tabPersoAbs = new System.Windows.Forms.TabControl();
            this.tabPerso = new System.Windows.Forms.TabPage();
            this.btnValider = new System.Windows.Forms.Button();
            this.comboService = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.btnSupprimerPerso = new System.Windows.Forms.Button();
            this.btnModifierPerso = new System.Windows.Forms.Button();
            this.btnAjouterPerso = new System.Windows.Forms.Button();
            this.tabAbsence = new System.Windows.Forms.TabPage();
            this.cbMotif = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkNonDef = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateDebut = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbNomAbsent = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModifierAbs = new System.Windows.Forms.Button();
            this.btnSupprimerAbs = new System.Windows.Forms.Button();
            this.bntAjouterAbs = new System.Windows.Forms.Button();
            this.dgvPersonnel = new System.Windows.Forms.DataGridView();
            this.btnValiderAbs = new System.Windows.Forms.Button();
            this.tabPersoAbs.SuspendLayout();
            this.tabPerso.SuspendLayout();
            this.tabAbsence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPersoAbs
            // 
            this.tabPersoAbs.Controls.Add(this.tabPerso);
            this.tabPersoAbs.Controls.Add(this.tabAbsence);
            this.tabPersoAbs.Location = new System.Drawing.Point(603, 13);
            this.tabPersoAbs.Multiline = true;
            this.tabPersoAbs.Name = "tabPersoAbs";
            this.tabPersoAbs.SelectedIndex = 0;
            this.tabPersoAbs.Size = new System.Drawing.Size(258, 301);
            this.tabPersoAbs.TabIndex = 1;
            this.tabPersoAbs.SelectedIndexChanged += new System.EventHandler(this.tabPersoAbs_SelectedIndexChanged);
            // 
            // tabPerso
            // 
            this.tabPerso.Controls.Add(this.btnValider);
            this.tabPerso.Controls.Add(this.comboService);
            this.tabPerso.Controls.Add(this.label5);
            this.tabPerso.Controls.Add(this.label4);
            this.tabPerso.Controls.Add(this.label3);
            this.tabPerso.Controls.Add(this.txtTel);
            this.tabPerso.Controls.Add(this.txtMail);
            this.tabPerso.Controls.Add(this.label2);
            this.tabPerso.Controls.Add(this.label1);
            this.tabPerso.Controls.Add(this.txtPrenom);
            this.tabPerso.Controls.Add(this.txtNom);
            this.tabPerso.Controls.Add(this.btnSupprimerPerso);
            this.tabPerso.Controls.Add(this.btnModifierPerso);
            this.tabPerso.Controls.Add(this.btnAjouterPerso);
            this.tabPerso.Location = new System.Drawing.Point(4, 22);
            this.tabPerso.Name = "tabPerso";
            this.tabPerso.Padding = new System.Windows.Forms.Padding(3);
            this.tabPerso.Size = new System.Drawing.Size(250, 275);
            this.tabPerso.TabIndex = 0;
            this.tabPerso.Text = "personnel";
            this.tabPerso.UseVisualStyleBackColor = true;
            this.tabPerso.Click += new System.EventHandler(this.tabPerso_Click);
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(168, 246);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 14;
            this.btnValider.Text = "valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // comboService
            // 
            this.comboService.AutoCompleteCustomSource.AddRange(new string[] {
            "administratif",
            "médiation culturelle",
            "prêt"});
            this.comboService.FormattingEnabled = true;
            this.comboService.Location = new System.Drawing.Point(87, 209);
            this.comboService.Name = "comboService";
            this.comboService.Size = new System.Drawing.Size(157, 21);
            this.comboService.TabIndex = 13;
            this.comboService.SelectedIndexChanged += new System.EventHandler(this.comboService_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "service:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Téléphone:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "mail:";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(87, 165);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(156, 20);
            this.txtTel.TabIndex = 8;
            this.txtTel.TextChanged += new System.EventHandler(this.txtTel_TextChanged);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(87, 126);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(157, 20);
            this.txtMail.TabIndex = 7;
            this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "prénom:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "nom:";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(87, 83);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(156, 20);
            this.txtPrenom.TabIndex = 4;
            this.txtPrenom.TextChanged += new System.EventHandler(this.txtPrenom_TextChanged);
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(87, 45);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(156, 20);
            this.txtNom.TabIndex = 3;
            this.txtNom.TextChanged += new System.EventHandler(this.txtNom_TextChanged);
            // 
            // btnSupprimerPerso
            // 
            this.btnSupprimerPerso.Location = new System.Drawing.Point(168, 6);
            this.btnSupprimerPerso.Name = "btnSupprimerPerso";
            this.btnSupprimerPerso.Size = new System.Drawing.Size(75, 23);
            this.btnSupprimerPerso.TabIndex = 2;
            this.btnSupprimerPerso.Text = "supprimer";
            this.btnSupprimerPerso.UseVisualStyleBackColor = true;
            this.btnSupprimerPerso.Click += new System.EventHandler(this.btnSupprimerPerso_Click);
            // 
            // btnModifierPerso
            // 
            this.btnModifierPerso.Location = new System.Drawing.Point(87, 6);
            this.btnModifierPerso.Name = "btnModifierPerso";
            this.btnModifierPerso.Size = new System.Drawing.Size(75, 23);
            this.btnModifierPerso.TabIndex = 1;
            this.btnModifierPerso.Text = "modifier";
            this.btnModifierPerso.UseVisualStyleBackColor = true;
            this.btnModifierPerso.Click += new System.EventHandler(this.btnModifierPerso_Click);
            // 
            // btnAjouterPerso
            // 
            this.btnAjouterPerso.Location = new System.Drawing.Point(6, 6);
            this.btnAjouterPerso.Name = "btnAjouterPerso";
            this.btnAjouterPerso.Size = new System.Drawing.Size(75, 23);
            this.btnAjouterPerso.TabIndex = 0;
            this.btnAjouterPerso.Text = "ajouter";
            this.btnAjouterPerso.UseVisualStyleBackColor = true;
            this.btnAjouterPerso.Click += new System.EventHandler(this.btnAjouterPerso_Click);
            // 
            // tabAbsence
            // 
            this.tabAbsence.Controls.Add(this.btnValiderAbs);
            this.tabAbsence.Controls.Add(this.cbMotif);
            this.tabAbsence.Controls.Add(this.label10);
            this.tabAbsence.Controls.Add(this.checkNonDef);
            this.tabAbsence.Controls.Add(this.label9);
            this.tabAbsence.Controls.Add(this.dateFin);
            this.tabAbsence.Controls.Add(this.label8);
            this.tabAbsence.Controls.Add(this.dateDebut);
            this.tabAbsence.Controls.Add(this.label7);
            this.tabAbsence.Controls.Add(this.cbNomAbsent);
            this.tabAbsence.Controls.Add(this.label6);
            this.tabAbsence.Controls.Add(this.btnModifierAbs);
            this.tabAbsence.Controls.Add(this.btnSupprimerAbs);
            this.tabAbsence.Controls.Add(this.bntAjouterAbs);
            this.tabAbsence.Location = new System.Drawing.Point(4, 22);
            this.tabAbsence.Name = "tabAbsence";
            this.tabAbsence.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbsence.Size = new System.Drawing.Size(250, 275);
            this.tabAbsence.TabIndex = 1;
            this.tabAbsence.Text = "absence";
            this.tabAbsence.UseVisualStyleBackColor = true;
            // 
            // cbMotif
            // 
            this.cbMotif.AutoCompleteCustomSource.AddRange(new string[] {
            "vacances",
            "maladie",
            "motif familial",
            "congé parental"});
            this.cbMotif.FormattingEnabled = true;
            this.cbMotif.Location = new System.Drawing.Point(9, 191);
            this.cbMotif.Name = "cbMotif";
            this.cbMotif.Size = new System.Drawing.Size(181, 21);
            this.cbMotif.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "motif:";
            // 
            // checkNonDef
            // 
            this.checkNonDef.AutoSize = true;
            this.checkNonDef.Location = new System.Drawing.Point(208, 147);
            this.checkNonDef.Name = "checkNonDef";
            this.checkNonDef.Size = new System.Drawing.Size(15, 14);
            this.checkNonDef.TabIndex = 10;
            this.checkNonDef.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(191, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "non défini:";
            // 
            // dateFin
            // 
            this.dateFin.Location = new System.Drawing.Point(9, 141);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(181, 20);
            this.dateFin.TabIndex = 8;
            this.dateFin.Value = new System.DateTime(2025, 5, 1, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "date de fin:";
            // 
            // dateDebut
            // 
            this.dateDebut.Location = new System.Drawing.Point(9, 88);
            this.dateDebut.Name = "dateDebut";
            this.dateDebut.Size = new System.Drawing.Size(181, 20);
            this.dateDebut.TabIndex = 6;
            this.dateDebut.Value = new System.DateTime(2025, 5, 1, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "date de début:";
            // 
            // cbNomAbsent
            // 
            this.cbNomAbsent.FormattingEnabled = true;
            this.cbNomAbsent.Location = new System.Drawing.Point(67, 39);
            this.cbNomAbsent.Name = "cbNomAbsent";
            this.cbNomAbsent.Size = new System.Drawing.Size(156, 21);
            this.cbNomAbsent.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "personnel";
            // 
            // btnModifierAbs
            // 
            this.btnModifierAbs.Location = new System.Drawing.Point(87, 6);
            this.btnModifierAbs.Name = "btnModifierAbs";
            this.btnModifierAbs.Size = new System.Drawing.Size(75, 23);
            this.btnModifierAbs.TabIndex = 2;
            this.btnModifierAbs.Text = "modifier";
            this.btnModifierAbs.UseVisualStyleBackColor = true;
            this.btnModifierAbs.Click += new System.EventHandler(this.btnModifierAbs_Click);
            // 
            // btnSupprimerAbs
            // 
            this.btnSupprimerAbs.Location = new System.Drawing.Point(168, 6);
            this.btnSupprimerAbs.Name = "btnSupprimerAbs";
            this.btnSupprimerAbs.Size = new System.Drawing.Size(75, 23);
            this.btnSupprimerAbs.TabIndex = 1;
            this.btnSupprimerAbs.Text = "supprimer";
            this.btnSupprimerAbs.UseVisualStyleBackColor = true;
            this.btnSupprimerAbs.Click += new System.EventHandler(this.btnSupprimerAbs_Click);
            // 
            // bntAjouterAbs
            // 
            this.bntAjouterAbs.Location = new System.Drawing.Point(6, 6);
            this.bntAjouterAbs.Name = "bntAjouterAbs";
            this.bntAjouterAbs.Size = new System.Drawing.Size(75, 23);
            this.bntAjouterAbs.TabIndex = 0;
            this.bntAjouterAbs.Text = "ajouter";
            this.bntAjouterAbs.UseVisualStyleBackColor = true;
            this.bntAjouterAbs.Click += new System.EventHandler(this.bntAjouterAbs_Click);
            // 
            // dgvPersonnel
            // 
            this.dgvPersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonnel.Location = new System.Drawing.Point(12, 13);
            this.dgvPersonnel.Name = "dgvPersonnel";
            this.dgvPersonnel.ReadOnly = true;
            this.dgvPersonnel.Size = new System.Drawing.Size(585, 301);
            this.dgvPersonnel.StandardTab = true;
            this.dgvPersonnel.TabIndex = 2;
            this.dgvPersonnel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonnel_CellClick);
            this.dgvPersonnel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonnel_CellContentClick);
            this.dgvPersonnel.Click += new System.EventHandler(this.dgvPersonnel_Click);
            this.dgvPersonnel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvPersonnel_MouseClick);
            // 
            // btnValiderAbs
            // 
            this.btnValiderAbs.Location = new System.Drawing.Point(169, 246);
            this.btnValiderAbs.Name = "btnValiderAbs";
            this.btnValiderAbs.Size = new System.Drawing.Size(75, 23);
            this.btnValiderAbs.TabIndex = 13;
            this.btnValiderAbs.Text = "valider";
            this.btnValiderAbs.UseVisualStyleBackColor = true;
            // 
            // FormMediatheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 326);
            this.Controls.Add(this.dgvPersonnel);
            this.Controls.Add(this.tabPersoAbs);
            this.Name = "FormMediatheque";
            this.Text = "FormMediatheque";
            this.Load += new System.EventHandler(this.FormMediatheque_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormMediatheque_MouseClick);
            this.tabPersoAbs.ResumeLayout(false);
            this.tabPerso.ResumeLayout(false);
            this.tabPerso.PerformLayout();
            this.tabAbsence.ResumeLayout(false);
            this.tabAbsence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabPersoAbs;
        private System.Windows.Forms.TabPage tabPerso;
        private System.Windows.Forms.TabPage tabAbsence;
        private System.Windows.Forms.Button btnAjouterPerso;
        private System.Windows.Forms.Button btnSupprimerPerso;
        private System.Windows.Forms.Button btnModifierPerso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.ComboBox comboService;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnModifierAbs;
        private System.Windows.Forms.Button btnSupprimerAbs;
        private System.Windows.Forms.Button bntAjouterAbs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbNomAbsent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateDebut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkNonDef;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateFin;
        private System.Windows.Forms.ComboBox cbMotif;
        private System.Windows.Forms.DataGridView dgvPersonnel;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnValiderAbs;
    }
}