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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug name");
                string drugName = Console.ReadLine();
            drugPrice: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug price");
                string priceDrug = Console.ReadLine();
                double price;
                bool result = double.TryParse(priceDrug, out price);
            drugCount: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug count");
                string countDrug = Console.ReadLine();
                int count;
                bool result1 = int.TryParse(countDrug, out count);
                if (result)
                {
                    if (result1)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All DrugStores");
                        foreach (var drugstore in drugStories)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id:{drugstore.Id}, Name:{drugstore.Name}, Adress:{drugstore.Adresss}, ContactNumber:{drugstore.ContactNumber}");
                        }
                        DrugStoreID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore Id");
                        string storeId=Console.ReadLine();
                        int id;
                        result = int.TryParse(storeId, out id);
                        if (result)
                        {
                            var drugStore = _drugStoreRepository.Get(d=> d.Id==id);
                            if (drugStore!=null)
                            {
                                var drug = new Drug
                                {
                                    Name = drugName,
                                    Price = price,
                                    Count = (byte)count
                                };
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Name:{drugName}, Price:{priceDrug}, Count:{countDrug} is successfully created drug ");

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "DrugStore with this Id is empty");
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct format count");
                        goto drugCount;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct format price");
                    goto drugPrice;
                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no DrougStore");
            }
        }


        #endregion

        #region UpdateDrug

        public void UpadateDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugs");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count} DrugStore:{drug.drugStores.Name}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug Id");
                string drugId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug != null)
                    {
                        string oldname = drug.Name;
                        double oldprice = drug.Price;
                        byte oldcount = drug.Count;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug name");
                        string newName = Console.ReadLine();
                    price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug price");
                        string newPrice = Console.ReadLine();
                        double price;
                        result = double.TryParse(newPrice, out price);
                        if (result)
                        {
                        count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug count");
                            string newCount = Console.ReadLine();
                            int count;
                            result = int.TryParse(newCount, out count);
                            if (result)
                            {
                                var newDrug = new Drug
                                {
                                    Id = drug.Id,
                                    Name = newName,
                                    Price = price,
                                    Count = (byte)count,
                                };
                                _drugRepository.Update(newDrug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"OldName:{oldname} OldPrice:{oldprice} OldCount:{oldcount} drug successfully update: " +
                                                                                                   $"Name:{newName} Price:{newPrice} Count:{newCount}");
                            }
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct count");
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
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no any drug");
            }
        }
    }
}
#endregion