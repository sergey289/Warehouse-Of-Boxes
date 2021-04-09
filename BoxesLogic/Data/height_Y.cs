using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesLogic.Data
{
    class height_Y:IComparable<height_Y>
    {

        public double y;

        public int quantity = 0;

        public int MaxQuantity = 20;

        public height_Y(double y, int quantity)
        {

            this.y = y;

            this.quantity = quantity;

        }

        public int CompareTo(height_Y other)
        {
            return y.CompareTo(other.y);
        }

        public override string ToString()
        {

            return $" height={y}, quantity={quantity}\n";
        }

        public bool CheckAllowable_Quantity()
        {

            if (quantity <= 0)
            {
                return true;

            }

            return false;


        }


    }
}
