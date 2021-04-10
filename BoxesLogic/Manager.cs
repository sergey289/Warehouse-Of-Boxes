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

        List<width_X> Alloptions = new List<width_X>(); //all options on request, focusing on the quantity

        List<height_Y> ListOf_heights = new List<height_Y>();

        static double originalValueOF_Y;

        static double originalValueOF_X;

        static int flag = 0;

        public void FindBestMatchForGift_lavel_B(double x, double y, double quan)

        {
            flag++;

            if (flag == 1)
            {
                originalValueOF_Y = y;
                originalValueOF_X = x;

            }

            width_X Xdata = new width_X(x, y, default);

            width_X FoundMatch_of_X;

            Tree.FindBestMatch(Xdata, Tree.Root, out FoundMatch_of_X);


            if (FoundMatch_of_X == null || FoundMatch_of_X.x > originalValueOF_X + (originalValueOF_X * 0.4)) // if not founnd Xdata
            {


                if (Alloptions.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("THE Best match that has been found !\n");
                    Console.ResetColor();
                    Console.WriteLine("--------------------------------------");
                    ShowOptions();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not found match");
                    Console.ReadLine();
                }


            }
            else // if Xdata exist
            {


                height_Y newYdata = new height_Y(y, default);

                height_Y FoundMatch_of_Y;

                FoundMatch_of_X.FindBestMatch_of_Y(newYdata, out FoundMatch_of_Y);


                if (FoundMatch_of_Y != null) // if Y_data exist
                {


                    if (FoundMatch_of_Y.quantity >= quan)//checking  if the best match contains the required quantity
                    {
                        width_X newda = new width_X(FoundMatch_of_X.x, FoundMatch_of_Y.y, FoundMatch_of_Y.quantity);

                        Alloptions.Add(newda);

                        ListOf_heights.Add(FoundMatch_of_Y);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("THE Best match that has been found !\n");
                        Console.ResetColor();
                        Console.WriteLine("--------------------------------------");

                        ShowOptions();

                        return;

                    }


                    if (FoundMatch_of_Y.quantity >= quan * 0.4) //checking if  quantity bigger than 40% of request
                    {

                        width_X newda = new width_X(FoundMatch_of_X.x, FoundMatch_of_Y.y, FoundMatch_of_Y.quantity);

                        Alloptions.Add(newda);

                        ListOf_heights.Add(FoundMatch_of_Y);

                        FindBestMatchForGift_lavel_B(x, FoundMatch_of_Y.y + 0.1, quan);

                    }
                    else
                    {
                        FindBestMatchForGift_lavel_B(x, FoundMatch_of_Y.y + 0.1, quan);

                    }


                }
                else // if Y_data not found
                {


                    FindBestMatchForGift_lavel_B(FoundMatch_of_X.x + 0.01, originalValueOF_Y, quan);

                }


            }

        }

        public void ShowOptions()
        {
            int counter = 1;

            foreach (var i in Alloptions)
            {

                Console.WriteLine($"{counter++}) " + i, 10);



            }



        }    //output of all options on request, focusing on the quantity

        public bool UpdateQuantity(int id, int quantity)
        {
            id = id - 1;

            bool id_validation = false;

            if (Alloptions.Count >= id)
            {
                id_validation = true;

                try
                {

                    height_Y objYbyId = ListOf_heights.ElementAt(id);

                    width_X objXbyId = Alloptions.ElementAt(id);

                    if (objYbyId.quantity >= quantity)
                    {
                        objYbyId.quantity = objYbyId.quantity - quantity;

                        Alloptions.RemoveAt(id);

                        width_X obj_with_updatedquantity = new width_X(objXbyId.x, objYbyId.y, objYbyId.quantity);

                        Alloptions.Insert(id, obj_with_updatedquantity);



                        if (objYbyId.CheckAllowable_Quantity())
                        {
                            objXbyId.y_dataList.Remove(objYbyId);

                            if (objXbyId.y_dataList == null)
                            {
                                Tree.Remove(objXbyId);
                            }



                        }



                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("ERROR:Entered quantity is invalid!");
                        Console.ReadLine();


                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    id_validation = false;
                    Console.Clear();
                    Console.WriteLine("ERROR:The Option number entered is incorrect! Press Enter and try again");
                    Console.ReadLine();

                }


            }
            else
            {
                id_validation = false;
                Console.Clear();
                Console.WriteLine("ERROR:incorrect item number entered!");
                Console.ReadLine();
            }


            return id_validation;


        }  //update quantity by input from users


        public void ClearListOf_Options()
        {
            Alloptions.Clear();
        }

    }
}
