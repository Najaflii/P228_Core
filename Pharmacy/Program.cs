using Core.Constants;
using Core.Helpers;
using Pharmacy.Controllers;
namespace Final;

public class Pharmacy
{
    public static void Main()
    {
        AdminController _adminController = new AdminController();
        DrugController _drugController = new DrugController();
        DruggistController _druggistController = new DruggistController();
        DrugStoreController _drugStoreController = new DrugStoreController();
        OwnerController _ownerController = new OwnerController();






    adminUserName: var admin = _adminController.Authenticate();
        if (admin != null)
        {

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome :) {admin.Login}");

            Console.WriteLine("***");
            while (true)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "1 - Admin Menu");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "2 - Drug Menu");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "3 - Druggist Menu");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "4 - DrugStore Menu");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "5 - Owner Menu");
               mainMenu: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "0 - Menu");

                Console.WriteLine("***");

            selectNumber: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter number");
                string number = Console.ReadLine();
                int selectedNumber;
                bool result = int.TryParse(number, out selectedNumber);

                if (result)
                {
                    if (selectedNumber == 1)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "1 - Logout");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "0 - Menu");

                    selectOp: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select option");
                        number = Console.ReadLine();
                        result = int.TryParse(number, out selectedNumber);

                        if (selectedNumber >= 0 && selectedNumber <= 1)
                        {

                            switch (selectedNumber)
                            {
                                case (int)AdminOptions.Logout:
                                    goto adminUserName;
                                    break;
                                case (int)AdminOptions.Menu:
                                    goto mainMenu;
                            }
                        }

                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct number");
                            goto selectOp;
                        }
                    }

                    else if (selectedNumber == 2)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "1 - Creat Drug");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "2 - Update Drug");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "3 - Delete Drug");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "4 - Get All");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "5 - Get All Drug By Store");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "6 - Filter Drugs");

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "0 - Menu");

                        Console.WriteLine("***");


                    selectopp: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select option");
                        number = Console.ReadLine();

                        result = int.TryParse(number, out selectedNumber);

                        if (selectedNumber >= 0 && selectedNumber <= 5)
                        {
                            switch (selectedNumber)
                            {
                                case (int)DrugOptions.CreateDrug:
                                    _drugController.CreateDrug();
                                    break;
                                case (int)DrugOptions.UpdateDrug:
                                    _drugController.UpadateDrug();
                                    break;
                                case (int)DrugOptions.DeleteDrug:
                                    _drugController.DeleteDrug();
                                    break;
                                case (int)DrugOptions.GetAllDrug:
                                    _drugController.GetAllDrug();
                                    break;
                                case (int)DrugOptions.BackMainMenu:
                                    goto mainMenu;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct number");
                            goto selectopp;
                        }
                    }
                    else if (selectedNumber == 3)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "1 - Creat Druggist");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "2 - Update Druggist");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "3 - Delete Druggist");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "4 - Get All Druggist");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "5 - Get Drugist By Store");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "0 - Menu");

                        Console.WriteLine("***");

                    opp: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Select Options:");
                        number = Console.ReadLine();

                        result = int.TryParse(number, out selectedNumber);

                        if (selectedNumber >= 0 && selectedNumber <= 5)
                        {
                            switch (selectedNumber)
                            {
                                case (int)DruggistOptions.CreateDruggist:
                                    _druggistController.CreateDruggist();
                                    break;
                                case (int)DruggistOptions.UpdateDruggist:
                                    _druggistController.UpdateDruggist();
                                    break;
                                case (int)DruggistOptions.DeleteDruggist:
                                    _druggistController.DeleteDruggist();
                                    break;
                                case (int)DruggistOptions.GetAllDruggist:
                                    _druggistController.GetAllDruggist();
                                        break;
                                case (int)DruggistOptions.BackToMainMenu:
                                    goto mainMenu;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct number");
                            goto opp;
                        }

                    }
                    else if (selectedNumber == 4)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Creat DrugStore");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update DrugStore");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete DrugStore");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Get All DrugStore");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get All DrugStore By Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "6 - Sale");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Menu");

                        Console.WriteLine("***");

                    oppp: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select option");
                        number = Console.ReadLine();

                        result = int.TryParse(number, out selectedNumber);
                        if (selectedNumber >= 0 && selectedNumber <= 6)
                        {
                            switch (selectedNumber)
                            {
                                case (int)DrugStoreOptions.CreateDrugStore:
                                    _drugStoreController.CreateDrugStore();
                                    break;
                                case (int)DrugStoreOptions.UpdateDrugStore:
                                    _drugStoreController.UpdateDrugstore();
                                    break;
                                case (int)DrugStoreOptions.DeleteDrugStore:
                                    _drugStoreController.DeleteDrugStore();
                                    break;
                                case (int)DrugStoreOptions.GetAllDrugStore:
                                    _drugStoreController.GetAll();
                                    break;
                                case (int)DrugStoreOptions.GetAllDrugStoreByOwner:
                                    _drugStoreController.GetAllDrugStoreByOwner();
                                    break;
                                case (int)DrugStoreOptions.Sale:
                                    _drugStoreController.Sale();
                                    break;
                                case (int)DrugStoreOptions.BackToMainMenu:
                                    goto mainMenu;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct number");
                            goto oppp;
                        }
                    }
                    else if (selectedNumber == 5)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "1 - Creat Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "2 - Update Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "3 - Delete Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "4 - Get All Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "0 - Menu");

                        Console.WriteLine("***");

                    oppppp: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select option");
                        number = Console.ReadLine();

                        result = int.TryParse(number, out selectedNumber);

                        if (selectedNumber >= 0 && selectedNumber <= 4)
                        {
                            switch (selectedNumber)
                            {
                                case (int)OwnerOptions.CreateOwner:
                                    _ownerController.CreateOwner();
                                    break;
                                case (int)OwnerOptions.UpdateOwner:
                                    _ownerController.UpdateOwner();
                                    break;
                                case (int)OwnerOptions.DeleteOwner:
                                    _ownerController.DeleteOwner();
                                    break;
                                case (int)OwnerOptions.GetAllOwner:
                                    _ownerController.GetAll();
                                    break;
                                case (int)OwnerOptions.BackToMainMenu:
                                    goto mainMenu;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct number");
                            goto oppppp;
                        }
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct number");
                    goto selectNumber;
                }
            }
        }
        else
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct username and password");
            goto adminUserName;
        }
    }
}