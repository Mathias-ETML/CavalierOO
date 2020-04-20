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
            this.panInfo = new System.Windows.Forms.Panel();
            this.labInfoCases = new System.Windows.Forms.Label();
            this.picBoxCavalier = new System.Windows.Forms.PictureBox();
            this.panInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCavalier)).BeginInit();
            this.SuspendLayout();
            // 
            // panEchiquier
            // 
            this.panEchiquier.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.panEchiquier.Location = new System.Drawing.Point(12, 12);
            this.panEchiquier.Name = "panEchiquier";
            this.panEchiquier.Size = new System.Drawing.Size(320, 320);
            this.panEchiquier.TabIndex = 0;
            // 
            // panInfo
            // 
            this.panInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panInfo.Controls.Add(this.labInfoCases);
            this.panInfo.Location = new System.Drawing.Point(-4, 343);
            this.panInfo.Name = "panInfo";
            this.panInfo.Size = new System.Drawing.Size(352, 57);
            this.panInfo.TabIndex = 1;
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
    }
}

