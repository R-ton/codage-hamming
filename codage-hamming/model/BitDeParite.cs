using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codage.Classes
{
    public class BitDeParite : BitClass
    {
        List<int> positionControle;

        public List<int> PositionControle
        {
            get { return positionControle; }
            set { positionControle = value; }
        }

      
        public BitDeParite()
        {
            this.positionControle = new List<int>();
        }

        public void setPosition(int degree)
        {
            int puissance2 = this.genererPosition(degree);
            this.Position = puissance2-1;
        }

        public int genererPosition(int degree)
        {
            int puissance2 = (int)Math.Pow(2, degree);
            return puissance2;
        }
    }
}
