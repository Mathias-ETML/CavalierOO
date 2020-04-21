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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaSuperForme));
            this.panEchiquier = new System.Windows.Forms.Panel();
            this.btnValiderNbrCases = new System.Windows.Forms.Button();
            this.labNbrCases = new System.Windows.Forms.Label();
            this.txtBoxInputNbrCases = new System.Windows.Forms.TextBox();
            this.panInfo = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.labInfoCases = new System.Windows.Forms.Label();
            this.picBoxCavalier = new System.Windows.Forms.PictureBox();
            this.panEchiquier.SuspendLayout();
            this.panInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCavalier)).BeginInit();
            this.SuspendLayout();
            // 
            // panEchiquier
            // 
            this.panEchiquier.Controls.Add(this.btnValiderNbrCases);
            this.panEchiquier.Controls.Add(this.labNbrCases);
            this.panEchiquier.Controls.Add(this.txtBoxInputNbrCases);
            this.panEchiquier.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.panEchiquier.Location = new System.Drawing.Point(12, 12);
            this.panEchiquier.Name = "panEchiquier";
            this.panEchiquier.Size = new System.Drawing.Size(320, 320);
            this.panEchiquier.TabIndex = 0;
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
            // labNbrCases
            // 
            this.labNbrCases.AutoSize = true;
            this.labNbrCases.Location = new System.Drawing.Point(94, 139);
            this.labNbrCases.Name = "labNbrCases";
            this.labNbrCases.Size = new System.Drawing.Size(132, 13);
            this.labNbrCases.TabIndex = 1;
            this.labNbrCases.Text = "Nombre de cases par côté";
            // 
            // txtBoxInputNbrCases
            // 
            this.txtBoxInputNbrCases.Location = new System.Drawing.Point(118, 155);
            this.txtBoxInputNbrCases.Name = "txtBoxInputNbrCases";
            this.txtBoxInputNbrCases.Size = new System.Drawing.Size(77, 20);
            this.txtBoxInputNbrCases.TabIndex = 0;
            // 
            // panInfo
            // 
            this.panInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panInfo.Controls.Add(this.btnReset);
            this.panInfo.Controls.Add(this.labInfoCases);
            this.panInfo.Location = new System.Drawing.Point(-4, 343);
            this.panInfo.Name = "panInfo";
            this.panInfo.Size = new System.Drawing.Size(352, 57);
            this.panInfo.TabIndex = 1;
            this.panInfo.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(262, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(73, 24);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // labInfoCases
            // 
            this.labInfoCases.AutoSize = true;
            this.labInfoCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfoCases.Location = new System.Drawing.Point(15, 14);
            this.labInfoCases.Name = "labInfoCases";
            this.labInfoCases.Size = new System.Drawing.Size(75, 20);
            this.labInfoCases.TabIndex = 0;
            this.labInfoCases.Text = "Case : ?";
            this.labInfoCases.Visible = false;
            // 
            // picBoxCavalier
            // 
            this.picBoxCavalier.Location = new System.Drawing.Point(0, 0);
            this.picBoxCavalier.Name = "picBoxCavalier";
            this.picBoxCavalier.Size = new System.Drawing.Size(100, 50);
            this.picBoxCavalier.TabIndex = 0;
            this.picBoxCavalier.TabStop = false;
            // 
            // FrmMaSuperForme
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(344, 396);
            this.Controls.Add(this.panInfo);
            this.Controls.Add(this.panEchiquier);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMaSuperForme";
            this.Text = "Echiquer";
            this.panEchiquier.ResumeLayout(false);
            this.panEchiquier.PerformLayout();
            this.panInfo.ResumeLayout(false);
            this.panInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCavalier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panEchiquier;
        private System.Windows.Forms.Panel panInfo;
        private System.Windows.Forms.Label labInfoCases;
        private System.Windows.Forms.PictureBox picBoxCavalier;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label labNbrCases;
        private System.Windows.Forms.TextBox txtBoxInputNbrCases;
        private System.Windows.Forms.Button btnValiderNbrCases;
    }
}

