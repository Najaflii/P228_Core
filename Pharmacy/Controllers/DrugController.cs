using Core.Entities;
using Core.Helpers;
using DataAccess.Impelementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class DrugController
    {
        private DrugRepository _drugRepository;
        private DrugStoreRepository _drugStoreRepository;
        public DrugController()
        {
            _drugStoreRepository = new DrugStoreRepository();
            _drugRepository = new DrugRepository();
        }

        #region CreateDrug
        public void CreateDrug()
        {
            var drugStories = _drugStoreRepository.GetAll();

            if (drugStories.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Drug Name");
                string drugName = Console.ReadLine();
            drugPrice: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Drug Price");
                string priceDrug = Console.ReadLine();
                double price;
                bool result = double.TryParse(priceDrug, out price);
                if (result)
                {
                drugCount: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Drug Count");
                    string countDrug = Console.ReadLine();
                    int count;
                    result = int.TryParse(countDrug, out count);

                    if (result)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All DrugStores");
                        foreach (var drugstore in drugStories)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID:{drugstore.Id}, Name:{drugstore.Name}, Adress:{drugstore.Adresss}, ContactNumber:{drugstore.ContactNumber} ");
                        }
                    DrugStoreID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore I");
                        string storeId = Console.ReadLine();
                        int id;
                        result = int.TryParse(storeId, out id);
                        if (result)
                        {
                            var drugStore = _drugStoreRepository.Get(d => d.Id == id);
                            if (drugStore != null)
                            {
                                var drug = new Drug
                                {
                                    Name = drugName,
                                    Count = count,
                                    DrugStores = drugStore,
                                };
                                _drugRepository.Create(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{drugName}, Price:{priceDrug}, Count:{countDrug} DrugStore:{drug.DrugStores.Name}was successfully created");
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Incorrect Drugstore Id");
                                goto DrugStoreID;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Id");
                            goto DrugStoreID;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct count");
                        goto drugCount;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct price");
                    goto drugPrice;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no DrugStore");
            }
        }


        #endregion

        #region UpdateDrug
        public void UpadateDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Drugs");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count} DrugStore:{drug.DrugStores.Name}");
                }
            idd: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug Id");
                int chosenId;
                string Id = Console.ReadLine();
                int id;
                bool result = int.TryParse(Id, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug != null)
                    {
                        string oldname = drug.Name;
                        double oldprice = drug.Price;
                        int oldcount = drug.Count;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug name");
                        string newName = Console.ReadLine();
                    price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug price");
                        string newPrice = Console.ReadLine();
                        double price;
                        result = double.TryParse(newPrice, out price);
                        if (result)
                        {
                        count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter new drug count");
                            string newCount = Console.ReadLine();
                            int count;
                            result = int.TryParse(newCount, out count);
                            if (result)
                            {
                                var newDrug = new Drug
                                {
                                    Id = drug.Id,
                                    Name = newName,
                                    Count = count,
                                };
                                _drugRepository.Update(newDrug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"OldName:{oldname} OldPrice:{oldprice} OldCount:{oldcount} drug successfully update: Name:{newName} Price:{newPrice} Count:{newCount}");

                            }
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Eenter correct count");
                            goto count;
                        }
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct price");
                        goto price;
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Id");
                    goto idd;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no drug");
            }
        }

        #endregion

        #region DeleteDrug
        public void DeleteDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Drugs:");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count} DrugStore:{drug.DrugStores.Name}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Id:");
                string drugId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug != null)
                    {
                        _drugRepository.Delete(drug);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id{drug.Id} Name:{drug.Name} Drug was successfully deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
                        goto all;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Id");
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no drug");
            }
        }

        #endregion

        #region GetAllDrug
        public void GetAllDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Drugs");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count} Drugstore:{drug.DrugStores.Name} ");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no drug");
            }
        }
        #endregion

        #region Filter
        public void DrugFilter()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0) ;
            {
            Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter filter price");
                string filterprice = Console.ReadLine();
                double price;
                bool result = double.TryParse(filterprice, out price);
                if (result)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drug list");
                    foreach (var drug in drugs)
                    {
                        if (drug.Price <= price) 
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"id : {drug.Id}, name : {drug.Name}, price : {drug.Price}, count : {drug.Count}");
                        }
                          else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct price");
                        }
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no drug");
                }
            }

        }
    }
}
#endregion
