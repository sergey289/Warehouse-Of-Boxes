using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesLogic.Data
{
    class width_X:IComparable<width_X>
    {

        public double x { get; set; }

        public LinkedList<height_Y> y_dataList = new LinkedList<height_Y>();

        public width_X(double x, double y, int quantity)
        {

            this.x = x;

            height_Y height = new height_Y(y, quantity);

            y_dataList.AddFirst(height);


        }

        public int CompareTo(width_X other)
        {
            return x.CompareTo(other.x);
        }

        public override string ToString()
        {
            StringBuilder Alldata = new StringBuilder();


            foreach (var ydata in y_dataList)
            {
                if (ydata.quantity != 0)
                {
                    Alldata.Append($"width={x,3} " + $"{ydata,5} " + "\n");

                }

            }

            return Alldata.ToString();
        }

        public void IFexistY(height_Y data, out height_Y foundData)
        {

            foundData = default;

            foreach (var vr in y_dataList)
            {

                if (vr.y == data.y)
                {
                    foundData = vr;


                }


            }


        }

        public void FindBestMatch_of_Y(height_Y searchValue, out height_Y cloossetBigger)
        {

            cloossetBigger = default;

            height_Y temp = y_dataList.OrderBy(i => i.y)

            .Where(i => i.y >= searchValue.y).FirstOrDefault();

            cloossetBigger = temp;

        }




    }
}
