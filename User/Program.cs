using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoxesLogic;


namespace User
{
    class Program
    {

       static Manager manager = new Manager();

        static void Main(string[] args)
        {

            AddingNewBoxes_by_Default();
            welcome: Console.ForegroundColor = ConsoleColor.Green;
            manager.ClearListOf_Options();
            Console.WriteLine("Welcome to the  box Warehouse Management System\n");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("what do you want to do ?\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1) Add New item \n\n2) Show all items\n\n3) Search items by Criterions\n\n4) Buy items\n\n");
            Console.ResetColor();
            Console.Write("Yours choice :");


            int choice;

            bool verification = int.TryParse(Console.ReadLine(), out choice);
            if (choice > 4)
            {
                verification = false;
            }


            if (verification)
            {

                double Width;
                double Height;
                int Quantity;
                int flag = 0;

                switch (choice)
                {
                    case 1:
                        #region
                        try
                        {

                            Console.Clear();
                        optin1: Console.WriteLine("1)Option Add New item \n");
                            Console.WriteLine("To add a new box to the system, enter the Width, Height and Quantity of the box\n");
                            Console.Write("Width:=");
                            Width = double.Parse(Console.ReadLine());
                            Console.Write("\n");
                            Console.Write("Height:=");
                            Height = double.Parse(Console.ReadLine());
                            Console.Write("\n");
                            Console.Write("Quantity:=");
                            Quantity = int.Parse(Console.ReadLine());
                            manager.Add(Width, Height, Quantity);
                            Console.WriteLine("item was added successfully!");
                            Console.WriteLine("press 1 to continue ,2 to return to the main menu\n");
                            choice = int.Parse(Console.ReadLine());
                            Console.Clear();
                            if (choice == 1) goto optin1;
                            else if (choice == 2) goto welcome;




                        }
                        catch (FormatException)
                        {

                            Console.WriteLine("Error:One or more parameters were entered incorrectly Press Enter and try  again!");
                            Console.ReadLine();
                            goto case 1;


                        }

                        break;
                    #endregion

                    case 2:
                        #region
                        Console.Clear();
                        Console.WriteLine("---------------------------------------------------");
                        manager.ShowAllData();
                        Console.WriteLine("Press enter to return to the main menu");
                        Console.ReadLine();
                        Console.Clear();
                        goto welcome;
                    #endregion

                    case 3:
                        #region
                        try
                        {

                            Console.Clear();
                            Console.WriteLine("3) Search items by Criterions \n");
                            Console.WriteLine("to Search for a box, enter the size of the box, its Width and Height of the box:\n");
                            Console.Write("Width :");
                            Width = double.Parse(Console.ReadLine());
                            Console.Write("Height :");
                            Height = double.Parse(Console.ReadLine());
                            Console.Clear();
                            manager.ShowDatabyCriteriarians(Width, Height);
                            Console.WriteLine("\n");
                            Console.WriteLine("Press Enter to the return to main  menu !");
                            Console.ReadLine();
                            Console.Clear();
                            goto welcome;




                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine("Error:One or more parameters were entered incorrectly Press Enter and try  again!");
                            Console.ReadLine();
                            goto case 3;

                        }
                    #endregion

                    case 4:

                        #region
                        Console.Clear();
                        Console.WriteLine("4) Buy items \n");
                        Console.WriteLine("search for a box to buy by size only press 1,\nsearch for a box to buy by size and by a specific quantity press 2:\n");
                        Console.Write("Choice :");
                        verification = int.TryParse(Console.ReadLine(), out choice);
                        Console.Clear();

                        if (verification != false && choice == 1)
                        {
                            try
                            {
                                Console.Write("\n");
                                Console.Write("Width :");
                                Width = double.Parse(Console.ReadLine());
                                Console.Write("Height :");
                                Height = double.Parse(Console.ReadLine());
                                Console.Clear();
                                manager.FindBestMatchForGift_lavel_A(Width, Height);
                                Console.WriteLine("Press enter to the return to main menu !");
                                Console.ReadLine();
                                Console.Clear();
                                goto welcome;

                            }
                            catch (FormatException)
                            {
                                Console.Clear();
                                Console.WriteLine("Error:One or more parameters were entered incorrectly Press Enter and try  again!");
                                Console.ReadLine();
                                goto case 4;

                            }


                        }
                        else if (verification != false && choice == 2)
                        {

                        choise2_Start:
                            try
                            {

                                Console.Write("\n");
                                Console.Write("Width :");
                                Width = double.Parse(Console.ReadLine());
                                Console.Write("Height :");
                                Height = double.Parse(Console.ReadLine());
                                Console.Write("Quantity :");
                                Quantity = int.Parse(Console.ReadLine());
                                Console.Clear();
                                flag++;
                                if (flag == 1)
                                {
                                    manager.FindBestMatchForGift_lavel_B(Width, Height, Quantity);
                                }
                                else
                                {
                                    manager.ShowOptions();
                                }

                                Console.WriteLine("To continue purchasing click 1  or Press zero to return to the main menu");
                                Console.Write("Choice:");
                                choice = int.Parse(Console.ReadLine());


                            }
                            catch (FormatException)
                            {
                                Console.Clear();
                                Console.WriteLine("Error:One or more parameters were entered incorrectly Press Enter and try  again!");
                                Console.ReadLine();
                                Console.Clear();
                                goto choise2_Start;

                            }




                            if (choice == 1)
                            {
                            choice2_end:
                                try
                                {


                                    int optionNumber;
                                    Console.Clear();
                                    manager.ShowOptions();
                                    Console.WriteLine($"Select the option and the quantity you want to purchase !\n");
                                    Console.Write("Option number :");
                                    optionNumber = int.Parse(Console.ReadLine());
                                    Console.Write("Quantity :");
                                    Quantity = int.Parse(Console.ReadLine());
                                    if (manager.UpdateQuantity(optionNumber, Quantity))
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Operation completed successfully ! Press 1 to contine or 0 to return to the main menu ");
                                        Console.ResetColor();

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto choice2_end;
                                    }






                                    choice = int.Parse(Console.ReadLine());
                                    if (choice == 1)
                                    {
                                        Console.Clear(); goto choice2_end;

                                    }
                                    else if (choice == 0) Console.Clear(); goto welcome;

                                }
                                catch (FormatException)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Error:One or more parameters were entered incorrectly Press Enter and try  again!");
                                    Console.ReadLine();
                                    Console.Clear();
                                    goto choice2_end;


                                }



                            }
                            else if ((choice == 0))
                            {


                                Console.Clear(); goto welcome;

                            }
                            else
                            {
                                Console.Clear();
                                goto case 4;
                            }



                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error:You entered an invalid value ! Press Enter and try Again");
                            Console.ReadLine();
                            Console.Clear();
                            goto case 4;

                        }

                        #endregion


                }



            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error:You entered an invalid value ! Press Enter and try Again");
                Console.ReadLine();
                Console.Clear();
                goto welcome;

            }


            Console.ReadLine();


        }

        static public void AddingNewBoxes_by_Default()
        {
            manager.Add(11, 6, 2);

            manager.Add(6.3, 5, 8);

            manager.Add(6.3, 7, 9);

            manager.Add(6.3, 6, 2);

            manager.Add(6.4, 6, 8);

            manager.Add(7, 6, 8);

            manager.Add(6, 4, 12);



        }
    }
}
