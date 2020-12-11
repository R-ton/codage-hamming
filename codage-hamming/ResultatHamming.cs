using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace codage_hamming
{
    public partial class ResultatHamming : Form
    {
        //String mot;
        //String erreur;
        //String binaire;
        //String codeerreur;
        //String codecorrige;
        public ResultatHamming()
        {
            InitializeComponent();
        }
        
        public ResultatHamming(String m, String e, String b, String cderr, String codcorr,String res)
        {
            //this.mot = new RichTextBox();
            //this.binaire = new RichTextBox();
            //this.codeerreur = new RichTextBox();
            //this.richTextBox1 = new RichTextBox();
            //this.resultat = new RichTextBox();
            InitializeComponent();
            this.mot.Text = m;
            this.binaire.Text = b;
            this.codeerreur.Text = cderr;
            this.richTextBox1.Text = res;
            this.resultat.Text = codcorr;
            
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            this.mot.Text = null;
            this.binaire.Text = null;
            this.codeerreur.Text = null;
            this.richTextBox1.Text = null;
            this.resultat.Text = null;
            
        }
    }
}
