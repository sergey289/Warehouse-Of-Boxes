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

        public void ShowAllData()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Tree.displayTree(Tree.Root);
            Console.ResetColor();

        }

        public int AddNewQuantity(int currenntQuantity, int newQuantity, int maxQuantity)
        {

            return Math.Min(currenntQuantity + newQuantity, maxQuantity);



        }

        ///////////////////
        ///

        static int counter = 0;
        public void FindBestMatchForGift_lavel_A(double x, double y)
        {

            width_X Xdata = new width_X(x, y, default);

            width_X FoundMatch_of_X;

            Tree.FindBestMatch(Xdata, Tree.Root, out FoundMatch_of_X);


            if (FoundMatch_of_X == null) // if not founnd Xdata
            {

                try
                {

                    throw new Exception("Not found match");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }

            }
            else // if Xdata exist
            {
                height_Y newYdata = new height_Y(y, default);

                height_Y FoundMatch_of_Y;

                FoundMatch_of_X.FindBestMatch_of_Y(newYdata, out FoundMatch_of_Y);

                try
                {

                    if (FoundMatch_of_Y != null) // if Y_data exist
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("THE Best match that has been found !\n");
                        Console.ResetColor();
                        Console.WriteLine("--------------------------------------");

                        Console.WriteLine($"width={FoundMatch_of_X.x}" + "" + FoundMatch_of_Y + "\n");

                        FoundMatch_of_Y.quantity = FoundMatch_of_Y.quantity - 1;

                        if (FoundMatch_of_Y.CheckAllowable_Quantity()) // checking the quantity if it is acceptable
                        {
                            Console.WriteLine("the current number of boxes has reached zero!");

                            FoundMatch_of_X.y_dataList.Remove(FoundMatch_of_Y);

                            if (FoundMatch_of_X.y_dataList == null)
                            {

                                Tree.Remove(FoundMatch_of_X);

                            }

                            Console.WriteLine("this object has been removed from the system!");

                        }

                    }

                    else // if Y_data not exist
                    {
                        width_X Xdata2 = new width_X(x + 0.01, y, default);

                        counter++;

                        if (counter > 100)
                        {
                            counter = 0;

                            throw new Exception("Not found match");

                        }

                        FindBestMatchForGift_lavel_A(Xdata2.x, y);

                    }


                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);

                }

            }


        }

    }
}
