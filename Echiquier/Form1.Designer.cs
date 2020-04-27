namespace Echiquier
{
    partial class FrmMaSuperForme
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaSuperForme));
            this.txtBoxInputNbrCases = new System.Windows.Forms.TextBox();
            this.labNbrCases = new System.Windows.Forms.Label();
            this.btnValiderNbrCases = new System.Windows.Forms.Button();
            this.panInfoJoueur = new System.Windows.Forms.Panel();
            this.panInfoJoueur.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxInputNbrCases
            // 
            this.txtBoxInputNbrCases.Location = new System.Drawing.Point(118, 155);
            this.txtBoxInputNbrCases.Name = "txtBoxInputNbrCases";
            this.txtBoxInputNbrCases.Size = new System.Drawing.Size(77, 20);
            this.txtBoxInputNbrCases.TabIndex = 0;
            // 
            // labNbrCases
            // 
            this.labNbrCases.AutoSize = true;
            this.labNbrCases.Location = new System.Drawing.Point(94, 139);
            this.labNbrCases.Name = "labNbrCases";
            this.labNbrCases.Size = new System.Drawing.Size(132, 13);
            this.labNbrCases.TabIndex = 1;
            this.labNbrCases.Text = "Nombre de cases par côté";
            // 
            // btnValiderNbrCases
            // 
            this.btnValiderNbrCases.Location = new System.Drawing.Point(118, 179);
            this.btnValiderNbrCases.Name = "btnValiderNbrCases";
            this.btnValiderNbrCases.Size = new System.Drawing.Size(76, 20);
            this.btnValiderNbrCases.TabIndex = 2;
            this.btnValiderNbrCases.Text = "Ok";
            this.btnValiderNbrCases.UseVisualStyleBackColor = true;
            this.btnValiderNbrCases.Click += new System.EventHandler(this.btnValiderNbrCases_Click);
            // 
            // panInfoJoueur
            // 
            this.panInfoJoueur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panInfoJoueur.Controls.Add(this.btnValiderNbrCases);
            this.panInfoJoueur.Controls.Add(this.labNbrCases);
            this.panInfoJoueur.Controls.Add(this.txtBoxInputNbrCases);
            this.panInfoJoueur.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.panInfoJoueur.Location = new System.Drawing.Point(12, 12);
            this.panInfoJoueur.Name = "panInfoJoueur";
            this.panInfoJoueur.Size = new System.Drawing.Size(320, 320);
            this.panInfoJoueur.TabIndex = 0;
            // 
            // FrmMaSuperForme
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(344, 396);
            this.Controls.Add(this.panInfoJoueur);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(360, 435);
            this.MinimumSize = new System.Drawing.Size(360, 435);
            this.Name = "FrmMaSuperForme";
            this.Text = "Echiquer";
            this.panInfoJoueur.ResumeLayout(false);
            this.panInfoJoueur.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxInputNbrCases;
        private System.Windows.Forms.Label labNbrCases;
        private System.Windows.Forms.Button btnValiderNbrCases;
        private System.Windows.Forms.Panel panInfoJoueur;
    }

    partial class SecondForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region code fait par moi même, et c'était long

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondForm));
            this.btnReset = new System.Windows.Forms.Button();
            this.panInfo = new System.Windows.Forms.Panel();
            this.labInfoCases = new System.Windows.Forms.Label();
            this.panEchiquier = new System.Windows.Forms.Panel();
            // 
            // labInfoCases
            // 
            this.labInfoCases.AutoSize = true;
            this.labInfoCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoCases.Location = new System.Drawing.Point(17, 14);
            this.labInfoCases.Name = "labInfoCases";
            this.labInfoCases.Size = new System.Drawing.Size(75, 20);
            this.labInfoCases.TabIndex = 0;
            this.labInfoCases.Text = "Case : ?";
            this.labInfoCases.Visible = true;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(261, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 25);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panEchiquier
            // 
            this.panEchiquier.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.panEchiquier.Location = new System.Drawing.Point(12, 12);
            this.panEchiquier.Name = "panEchiquier";
            this.panEchiquier.Size = new System.Drawing.Size(320, 320);
            this.panEchiquier.TabIndex = 0;
            this.panEchiquier.Controls.Add(btnReset);
            this.panEchiquier.Controls.Add(labInfoCases);
            //
            // panInfo
            //
            this.panInfo.Size = new System.Drawing.Size(420, 69);
            this.panInfo.Location = new System.Drawing.Point(-10, 346);
            this.panInfo.Controls.Add(this.btnReset);
            this.panInfo.Controls.Add(this.labInfoCases);
            this.panInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //
            // SecondForm
            //
            this.Controls.Add(this.panEchiquier);
            this.Controls.Add(this.panInfo);
            this.ClientSize = new System.Drawing.Size(344, 396);
            this.MaximumSize = new System.Drawing.Size(360, 435);
            this.MinimumSize = new System.Drawing.Size(360, 435);
            this.Icon = Properties.Resources.cav64ico;
            this.Text = "Echiquier";
            this.Visible = true;
        }

        #endregion

        private System.Windows.Forms.Panel panInfo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label labInfoCases;
        private System.Windows.Forms.Panel panEchiquier;
    }
}

