using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codage.Classes
{
    public class BinaireClass
    {
        public static int calculBinaire(double a, double b)
        {
            int resultat = 0;
            double calcul = a + b;
            if (calcul%2 != 0)
            {
                resultat = 1;
            }
            return resultat;
        }
    }
}
