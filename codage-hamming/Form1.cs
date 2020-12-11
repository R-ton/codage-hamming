using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Codage.Classes;

namespace codage_hamming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mot.Text = string.Empty;
            this.binaire.Text = string.Empty;
            this.codeerreur.Text = string.Empty;
            this.richTextBox1.Text = string.Empty;
            this.resultat.Text = string.Empty;

            HammingClass hamming = new HammingClass();
            String mot = textBox1.Text;
            String erreur = textBox4.Text;
            int nombre = int.Parse(erreur);

            Console.WriteLine(mot);
            String binaire = CodeCorrecteur.stringEnBinaire(mot, Encoding.UTF8);


            Console.WriteLine(binaire);
            String Resultat = CodeCorrecteur.binaireEnString(binaire, Encoding.UTF8);
            hamming.separationEnblock(binaire, 4);

            Console.WriteLine(hamming.Blocks);

            string resultat = hamming.blockAvecErreur();
            resultat = CodeCorrecteur.genererErreur(resultat, nombre);
            string data = hamming.applicationCodageHamming(resultat);
            Resultat = CodeCorrecteur.binaireEnString(data, Encoding.UTF8);
            String blockerreur = hamming.BlockErreur;
            String CodeCorrige = hamming.Block;

            ResultatHamming h = new ResultatHamming(mot, erreur, binaire, hamming.blockAvecErreur(), CodeCorrige,Resultat);
            h.Show();

            this.mot.Text = mot;
            this.binaire.Text = binaire;
            this.codeerreur.Text = hamming.blockAvecErreur();
            this.richTextBox1.Text = Resultat;
            this.resultat.Text = CodeCorrige;
            
        }
    }
}
