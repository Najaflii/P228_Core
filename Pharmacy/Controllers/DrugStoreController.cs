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
    public class DrugStoreController
    {
        private DrugStoreRepository _drugStoreRepository;
        private OwnerRepository _ownerRepository;
        private DruggistRepository _druggistRepository;
        private DrugRepository _drugRepository;

        public DrugStoreController()
        {
            _drugStoreRepository = new DrugStoreRepository();
            _ownerRepository = new OwnerRepository();
            _druggistRepository = new DruggistRepository();
            _drugRepository = new DrugRepository();
        }

        #region CreateDrugStore
        public void CreateDrugStore()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Drugstore Name");
                string name = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Drugstore Adress");
                string adress = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Drugstore ContactNumber");
                string contactNumber = Console.ReadLine();





            allowner: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname} ");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner Id");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {

                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        var drugstore = new DrugStore()
                        {
                            Name = name,
                            Adresss = adress,
                            Owner = owner,
                        };
                        _drugStoreRepository.Create(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Adress:{drugstore.Adresss} ContactNumber:{drugstore.ContactNumber} Owner:{drugstore.Owner.Name} DrugStore successfully created");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Owner with this id doesn't exist");
                        goto allowner;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no any owner");
            }
        }
        #endregion

        #region UpdateDrugstore
        public void UpdateDrugstore()
        {
            var drugstores = _drugStoreRepository.GetAll();

            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All DrugStores");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} ContactNumber:{drugstore.ContactNumber} Owner:{drugstore.Owner}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore Id");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugStoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        string oldname = drugstore.Name;
                        string oldadress = drugstore.Adresss;


                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore name");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore adress");
                        string newAdress = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore contact number");
                        string newContactName = Console.ReadLine();
                    owid: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore owner Id");
                        string newOwnerId = Console.ReadLine();
                        int newId;
                        result = int.TryParse(newOwnerId, out newId);
                        if (result)
                        {
                            var owner = _ownerRepository.Get(o => o.Id == id);
                            if (owner != null)
                            {
                       
                                var newDrugstore = new DrugStore
                                {
                                    Id = drugstore.Id,
                                    Name = newName,
                                    Adresss = newAdress,
                                    Owner = owner,
                                };
                                _drugStoreRepository.Update(newDrugstore);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID:{drugstore.Id} Name:{newDrugstore.Name} Adress:{newDrugstore.Adresss} ContactNumber:{newDrugstore.ContactNumber} Owner:{owner} Drugstore successfully update");
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Id");
                            goto owid;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Id");
                        goto id;
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no DrugStore");
            }
        }

        #endregion

        #region DeleteDrugStore
        public void DeleteDrugStore()
        {
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All DrugStores");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} Owner:{drugstore.Owner}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore Id:");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugStoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        _drugStoreRepository.Delete(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drugstore.Id} Name:{drugstore.Name} was deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no Drugstore");
            }
        }


        #endregion

        #region GetAll
        public void GetAll()
        {
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
            alldrugstore: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All DrugStores");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore Id");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugStoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        _drugStoreRepository.Delete(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} was successfully deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Id");
                        goto alldrugstore;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no drugstore");
            }
        }

        #endregion

        #region GetAllDrugStoreByOwner
        public void GetAllDrugStoreByOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname} DrugStores:{owner.Drugstores}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner Id");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        var drugstores = _drugStoreRepository.GetAll(d => d.Owner != null ? d.Owner.Id == owner.Id : false);
                        if (drugstores.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Owners DrugStore");
                            foreach (var drugstore in drugstores)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Owner don't have Drugstore");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no owner");
            }
        }

        #endregion

        #region Sale
        public void Sale()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Drugs");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Drug Id");
                string drugId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug != null)
                    {
                    count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug count");
                        string drugCount = Console.ReadLine();
                        int count;
                        result = int.TryParse(drugCount, out count);
                        if (result)
                        {
                            int CurrentCount = drug.CurrentCount;
                            double SumPrice = drug.Price;
                            if (count > CurrentCount)
                            {
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drug.Id} Name:{drug.Name} SumPrice:{SumPrice}, DrugCount:{CurrentCount}");
                                }
                            }
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Drug");
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
    }
}
