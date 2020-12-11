using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codage.Classes
{
    public class Matrice
    {
        double[][] structure;

        public double[][] Structure
        {
            get { return structure; }
            set { structure = value; }
        }

        
        public Matrice produit(double[] colonne)
        {
            Matrice resultat = new Matrice();
            double[][] matriceA = this.Structure;
            double[][] matriceProduit = new double[matriceA.Length][];
            for (int i=0;i<matriceA.Length;i++)
            {
                double[] ligneA = matriceA[i];
                List<double> ligneResultat = new List<double>();
                for (int j=0; j<colonne.Length;j++)
                {
                    double calcul = ligneA[j] * colonne[j];
                    ligneResultat.Add(calcul);
                }
                matriceProduit[i] = ligneResultat.ToArray();
            }
            resultat.Structure = matriceProduit;
            return resultat;
        }

        public double[] code(double[] colonne)
        {
            double[][] matriceA = this.Structure;
            double[] resultat = new double[matriceA.Length];
            for (int i = 0; i < matriceA.Length; i++)
            {
                double[] ligneA = matriceA[i];
                double donnee = 0;
                for (int j = 0; j < colonne.Length; j++)
                {
                    double calcul = ligneA[j] * colonne[j];
                    donnee = BinaireClass.calculBinaire(donnee, calcul);
                }
                resultat[i] = donnee;
            }
            
            return resultat;
        }

    }
}
