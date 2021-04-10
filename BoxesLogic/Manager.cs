using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoxesLogic.Data;
using BoxesLogic.Data_Structures;

namespace BoxesLogic
{
    public class Manager
    {
        BST<width_X> Tree = new BST<width_X>();

        public void Add(double x, double y, int count)
        {
            width_X Xdata = new width_X(x, y, count);

            width_X existing = Tree.Find(Xdata);


            if (existing == null) // if not founnd Xdata
            {

                Tree.Add(Xdata); // add new Xdata

            }
            else // if Xdata exist
            {
                height_Y newYdata = new height_Y(y, count);

                height_Y yRoot;

                existing.IFexistY(newYdata, out yRoot);

                if (yRoot != null) // if Y_data exist
                {

                    yRoot.quantity = AddNewQuantity(yRoot.quantity, count, yRoot.MaxQuantity);

                }
                else // if Y_data not exist
                {

                    existing.y_dataList.AddLast(newYdata);

                }


            }




        }


        public void ShowDatabyCriteriarians(double x, double y)
        {
            width_X Xdata = new width_X(x, y, default);

            width_X existing = Tree.Find(Xdata);


            if (existing == null) // if not founnd Xdata
            {

                try
                {

                    throw new Exception("ERROR:Box with such parameters does not exist");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
            else // if Xdata exist
            {
                height_Y newYdata = new height_Y(y, default);

                height_Y yRoot;

                existing.IFexistY(newYdata, out yRoot);

                try
                {

                    if (yRoot != null) // if Y_data exist
                    {
                        Console.Write("\n");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"width={existing.x}" + "" + yRoot);
                        Console.ResetColor();

                    }
                    else // if Y_data not exist
                    {

                        throw new Exception("ERROR:Box with such parameters does not exist");

                    }


                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);

                }

            }

        }


        public int AddNewQuantity(int currenntQuantity, int newQuantity, int maxQuantity)
        {

            return Math.Min(currenntQuantity + newQuantity, maxQuantity);



        }

    }
}
