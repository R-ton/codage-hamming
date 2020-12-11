using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Codage.Classes
{
    public class HammingClass : CodeCorrecteur
    {
        string[] blocks;

        public string[] Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }
        string block;

        public string Block
        {
            get { return block; }
            set { block = value; }
        }
        string blockErreur;

        public string BlockErreur
        {
            get { return blockErreur; }
            set { blockErreur = value; }
        }
        BitDeParite[] bitsDeParite;

        public BitDeParite[] BitsDeParite
        {
            get { return bitsDeParite; }
            set { bitsDeParite = value; }
        }
        Matrice matriceGeneratrice;

        public Matrice MatriceGeneratrice
        {
            get { return matriceGeneratrice; }
            set { matriceGeneratrice = value; }
        }
        Matrice matriceControle;

        public Matrice MatriceControle
        {
            get { return matriceControle; }
            set { matriceControle = value; }
        }
        BitDeParite[] equationErreur;

        public BitDeParite[] EquationErreur
        {
            get { return equationErreur; }
            set { equationErreur = value; }
        }
        int n;

        public int N
        {
            get { return n; }
            set { n = value; }
        }
        int k;

       
        public HammingClass()
        {
            this.genererMatriceGeneratrice();
            this.genererMatriceDeControle();
            this.genererBitDeParite(7);
            this.bitControler(7);
        }

        public void separationEnblock(string binaire,int k)
        {
            List<string> blocks = new List<string>();
            for (int i=0;i<binaire.Length;i+=k)
            {
                Console.WriteLine(i);
                string block = binaire.Substring(i, k);
                blocks.Add(block);
            }
            Blocks = blocks.ToArray();
        }

        public double[] blockEnMatriceColonne(string block)
        {
            double[] matriceColonne = new double[block.Length];
            for (int i=0;i<block.Length;i++)
            {
                matriceColonne[i] = double.Parse(block[i].ToString());
            }
            return matriceColonne;
        }

        public void genererBitDeParite(int n)
        {
            List<BitDeParite> bitsDeParite = new List<BitDeParite>();
            int puissance = 0;
            int position = 0;
            while (position < n)
            {
                BitDeParite bitDeParite = new BitDeParite();
                bitDeParite.Designation = "p" + puissance;
                bitDeParite.setPosition(puissance);
                
                bitsDeParite.Add(bitDeParite);
                position = bitDeParite.genererPosition(puissance+1);
                Console.WriteLine(position);
                puissance++;
            }
            this.BitsDeParite = bitsDeParite.ToArray();
        }

        public void bitControler(int n)
        {
            BitDeParite[] bitDeParites = this.BitsDeParite;
            for (int i=1;i<=n;i++)
            {
                string binaire = Convert.ToString(i, 2);
                int reference = 0;
                for (int j=binaire.Length-1;j>=0;j--)
                {
                    if (binaire[j].Equals('1')) {
                        bitDeParites[reference].PositionControle.Add(i);
                    }
                    reference++;
                }
            }
        }

        public BitDeParite[] equationAvecErreur(double[] code)
        {
            List<BitDeParite> equationsErreur = new List<BitDeParite>();
            BitDeParite[] bitsDeParite = this.BitsDeParite;
            for (int i=0;i<bitsDeParite.Length;i++)
            {
                BitDeParite bitDeParite = bitsDeParite[i];
                List<int> equation = bitDeParite.PositionControle;
                int valeur = 0;
                for (int j=0;j<equation.Count();j++)
                {
                    Console.WriteLine(equation[j]);
                    int element = (int) code[equation[j]-1];
                    valeur = BinaireClass.calculBinaire(valeur, element);
                }
                if (valeur == 1)
                {
                    equationsErreur.Add(bitDeParite);
                }
            }
            this.EquationErreur = equationsErreur.ToArray();
            return this.EquationErreur;
        }

        public List<int> positionErreur()
        {
            BitDeParite[] erreurs = this.EquationErreur;
            List<int> positionTrouvee = new List<int>();
            if (erreurs.Length > 0)
            {
                positionTrouvee = erreurs[0].PositionControle;
                for (int i = 1; i < erreurs.Length; i++)
                {
                    BitDeParite equation = erreurs[i];
                    List<int> positions = equation.PositionControle;
                    for (int j = 0; j < positionTrouvee.Count; j++)
                    {
                        int position = positionTrouvee[j];
                        if (!positions.Contains(position))
                        {
                            positionTrouvee.RemoveAt(j);
                        }
                    }
                }
            }
            return positionTrouvee;
        }

        public void correctionErreur(double[] code)
        {
            List<int> positionsErreur = this.positionErreur();
            if (positionsErreur.Count > 0)
            {
                int position = positionsErreur[0] - 1;
                int erreur = (int)code[position];
                if (erreur == 0)
                {
                    code[position] = 1;
                }
                else
                {
                    code[position] = 0;
                }
            }
            
        }

        public List<int> positionBitDeParite()
        {
            BitDeParite[] bitDeParite = this.BitsDeParite;
            List<int> positions = new List<int>();
            for (int i=0;i<bitDeParite.Length;i++)
            {
                positions.Add(bitDeParite[i].Position);
            }
            return positions;
        }

        public string decodage(double[]code)
        {
            string resultatFinal = "";
            List<int> positions = this.positionBitDeParite();
            for (int i=0;i<code.Length;i++)
            {
                if (!positions.Contains(i))
                {
                    resultatFinal += code[i];
                }
            }
            return resultatFinal;
        }
        
        public string blockAvecErreur()
        {
            string resultatFinal = "";
            string[] blocks = this.Blocks;
            string[] blocksCode = new string[blocks.Length];
            Matrice matriceGeneratrice = this.MatriceGeneratrice;
            Matrice matriceControle = this.MatriceControle;
            BitDeParite[] bitDeParite = this.BitsDeParite;
            for (int i = 0; i < blocks.Length; i++)
            {
                string data = "";
                string block = blocks[i];
                double[] matriceColonne = this.blockEnMatriceColonne(block);
                double[] code = matriceGeneratrice.code(matriceColonne);
                for (int j=0; j<code.Length;j++)
                {
                    string donnee = code[j].ToString();
                    data+= donnee;
                }
                Console.WriteLine(data);
                resultatFinal += data;
                
            }
            this.BlockErreur = resultatFinal;
            return resultatFinal;
        }

        public List<double[]> blockCode(string message)
        {
            string resultat = "";
            List<double[]> code = new List<double[]>();
            string block = "";
            for (int i=0;i<message.Length;i++)
            {
                block += message[i];
                if (block.Length == 7)
                {
                    double[] donnee = new double[7];
                    for (int j=0;j<donnee.Length;j++)
                    {
                        donnee[j] = double.Parse(block[j].ToString());
                    }
                    code.Add(donnee);
                    block = "";
                }
                resultat += message[i];
            }
            this.Block = resultat;
            return code;
        }

        public string applicationCodageHamming(string message)
        {
            string resultatFinal = "";
            string[] blocks = this.Blocks;
            Matrice matriceGeneratrice = this.MatriceGeneratrice;
            Matrice matriceControle = this.MatriceControle;
            BitDeParite[] bitDeParite = this.BitsDeParite;
            List<double[]> codes = this.blockCode(message);
            for (int i=0;i<blocks.Length;i++)
            {
                string resultat = "";
                string block = blocks[i];
                double[] matriceColonne = this.blockEnMatriceColonne(block);
                double[] code = codes[i];
                double[] syndrome = matriceControle.code(code);
                if (!syndrome.Contains(1))
                {
                    resultat = this.decodage(code);
                }
                else
                {
                    BitDeParite[] equationAvecErreur = this.equationAvecErreur(code);
                    this.correctionErreur(code);
                    resultat = this.decodage(code);
                }
                resultatFinal += resultat;
            }
            
            return resultatFinal;
        }
        public Matrice genererMatriceGeneratrice()
        {
            Matrice matrice = new Matrice();
            double[][] donnees = new double[7][];
//ligne1            
            donnees[0] = new double[4];
            donnees[0][0] = 1;
            donnees[0][1] = 1;
            donnees[0][2] = 0;
            donnees[0][3] = 1;

//ligne2            
            donnees[1] = new double[4];
            donnees[1][0] = 1;
            donnees[1][1] = 0;
            donnees[1][2] = 1;
            donnees[1][3] = 1;

//ligne3            
            donnees[2] = new double[4];
            donnees[2][0] = 1;
            donnees[2][1] = 0;
            donnees[2][2] = 0;
            donnees[2][3] = 0;

//ligne4            
            donnees[3] = new double[4];
            donnees[3][0] = 0;
            donnees[3][1] = 1;
            donnees[3][2] = 1;
            donnees[3][3] = 1;

//ligne5            
            donnees[4] = new double[4];
            donnees[4][0] = 0;
            donnees[4][1] = 1;
            donnees[4][2] = 0;
            donnees[4][3] = 0;

//ligne6            
            donnees[5] = new double[4];
            donnees[5][0] = 0;
            donnees[5][1] = 0;
            donnees[5][2] = 1;
            donnees[5][3] = 0;

//ligne7            
            donnees[6] = new double[4];
            donnees[6][0] = 0;
            donnees[6][1] = 0;
            donnees[6][2] = 0;
            donnees[6][3] = 1;

            matrice.Structure = donnees;
            this.MatriceGeneratrice = matrice;
            return matrice;
        }

        public Matrice genererMatriceDeControle()
        {
            Matrice matrice = new Matrice();
            double[][] donnees = new double[3][];
            //ligne1            
            donnees[0] = new double[7];
            donnees[0][0] = 1;
            donnees[0][1] = 0;
            donnees[0][2] = 1;
            donnees[0][3] = 0;
            donnees[0][4] = 1;
            donnees[0][5] = 0;
            donnees[0][6] = 1;

            //ligne2            
            donnees[1] = new double[7];
            donnees[1][0] = 0;
            donnees[1][1] = 1;
            donnees[1][2] = 1;
            donnees[1][3] = 0;
            donnees[1][4] = 0;
            donnees[1][5] = 1;
            donnees[1][6] = 1;

            //ligne1            
            donnees[2] = new double[7];
            donnees[2][0] = 0;
            donnees[2][1] = 0;
            donnees[2][2] = 0;
            donnees[2][3] = 1;
            donnees[2][4] = 1;
            donnees[2][5] = 1;
            donnees[2][6] = 1;

            matrice.Structure = donnees;
            this.MatriceControle = matrice;
            return matrice;
        }
    }
}
