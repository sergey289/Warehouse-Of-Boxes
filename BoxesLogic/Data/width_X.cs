using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesLogic.Data
{
    class width_X
    {

        public double x { get; set; }

        public LinkedList<height_Y> y_dataList = new LinkedList<height_Y>();

        public width_X(double x, double y, int quantity)
        {

            this.x = x;

            height_Y height = new height_Y(y, quantity);

            y_dataList.AddFirst(height);


        }






    }
}
