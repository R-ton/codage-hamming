namespace codage_hamming
{
    partial class ResultatHamming
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.codecorrige = new System.Windows.Forms.Label();
            this.mot = new System.Windows.Forms.RichTextBox();
            this.binaire = new System.Windows.Forms.RichTextBox();
            this.codeerreur = new System.Windows.Forms.RichTextBox();
            this.resultat = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mot en binaire";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = " code erreur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "code corrige";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mot";
            // 
            // codecorrige
            // 
            this.codecorrige.AutoSize = true;
            this.codecorrige.Location = new System.Drawing.Point(183, 110);
            this.codecorrige.Name = "codecorrige";
            this.codecorrige.Size = new System.Drawing.Size(35, 13);
            this.codecorrige.TabIndex = 6;
            this.codecorrige.Text = "label5";
            // 
            // mot
            // 
            this.mot.Location = new System.Drawing.Point(133, 13);
            this.mot.Name = "mot";
            this.mot.Size = new System.Drawing.Size(474, 25);
            this.mot.TabIndex = 8;
            this.mot.Text = "";
            // 
            // binaire
            // 
            this.binaire.Location = new System.Drawing.Point(157, 58);
            this.binaire.Name = "binaire";
            this.binaire.Size = new System.Drawing.Size(457, 90);
            this.binaire.TabIndex = 9;
            this.binaire.Text = "";
            // 
            // codeerreur
            // 
            this.codeerreur.Location = new System.Drawing.Point(119, 180);
            this.codeerreur.Name = "codeerreur";
            this.codeerreur.Size = new System.Drawing.Size(488, 90);
            this.codeerreur.TabIndex = 10;
            this.codeerreur.Text = "";
            // 
            // resultat
            // 
            this.resultat.Location = new System.Drawing.Point(119, 292);
            this.resultat.Name = "resultat";
            this.resultat.Size = new System.Drawing.Size(488, 116);
            this.resultat.TabIndex = 11;
            this.resultat.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mot corrige";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(119, 429);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(488, 52);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // ResultatHamming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 509);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.resultat);
            this.Controls.Add(this.codeerreur);
            this.Controls.Add(this.binaire);
            this.Controls.Add(this.mot);
            this.Controls.Add(this.codecorrige);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ResultatHamming";
            this.Text = "ResultatHamming";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label codecorrige;
        private System.Windows.Forms.RichTextBox mot;
        private System.Windows.Forms.RichTextBox binaire;
        private System.Windows.Forms.RichTextBox codeerreur;
        private System.Windows.Forms.RichTextBox resultat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}