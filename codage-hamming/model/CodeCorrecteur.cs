using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codage.Classes
{
    public class CodeCorrecteur
    {
        static Encoding encoding;
//conversion string en binaire(forme string)
        public static string stringEnBinaire(string donnee,Encoding encodage)
        {
            StringBuilder resultat = new StringBuilder();

            foreach (char element in donnee.ToCharArray())
            {
                resultat.Append(Convert.ToString(element, 2).PadLeft(8, '0'));
            }
            return resultat.ToString();
        }

//conversion d'un code binaire(forme string) en string 
        public static string binaireEnString(string donnee, Encoding encodage)
        {
            List<Byte> bits = new List<Byte>();

            for (int i = 0; i < donnee.Length; i += 8)
            {
                bits.Add(Convert.ToByte(donnee.Substring(i, 8), 2));
            }
            return encodage.GetString(bits.ToArray());
        }

//generer une erreur aleatoire dans le code
        public static string genererErreur(string binaire,int maxErreur)
        {
            Random random = new Random();
            //if (maxErreur == 1)
            //{
            //    maxErreur = 0;
            //}
            int longueurCode = binaire.Length;
            for (int i=0;i<maxErreur;i++)
            {
                if (i<binaire.Length)
                {
                    int positionErreur = random.Next(0, longueurCode);
                    char element = binaire[positionErreur];
                    if (element.Equals('0'))
                    {
                        StringBuilder stringBuilder = new StringBuilder(binaire);
                        stringBuilder[positionErreur] = '1';
                        binaire = stringBuilder.ToString();
                        Console.WriteLine(element);
                        Console.WriteLine(binaire[positionErreur]);
                    }
                    else
                    {
                        StringBuilder stringBuilder = new StringBuilder(binaire);
                        stringBuilder[positionErreur] = '0';
                        binaire = stringBuilder.ToString();
                        Console.WriteLine(binaire);
                        Console.WriteLine(binaire[positionErreur]);
                    }
                }
            }

            return binaire;
        }
    }
}
