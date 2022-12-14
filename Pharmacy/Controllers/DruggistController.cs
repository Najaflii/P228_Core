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
    public class DruggistController
    {
        private DruggistRepository _druggistRepository;
        private DrugStoreRepository _drugstoreRepository;
        public DruggistController()
        {
            _druggistRepository = new DruggistRepository();
            _drugstoreRepository = new DrugStoreRepository();

        }
        #region CreateDruggist
        public void CreateDruggist()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Druggist Name");
                string druggistName = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Druggist Surname");
                string druggistSurname = Console.ReadLine();
            age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Druggist Age");
                string druggistAge = Console.ReadLine();
                byte age;
                bool result = byte.TryParse(druggistAge, out age);
                if (result)
                {
                experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Druggist Experience");
                    string druggistExperience = Console.ReadLine();
                    double experience;
                    result = double.TryParse(druggistExperience, out experience);
                    if (result)
                    {
                    allstore: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All DrugStores");
                        foreach (var drugstore in drugstores)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drugstore.Id} Name:{drugstore.Name} Owner:{drugstore.Owner.Name}");
                        }
                    id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore Id");
                        string drugstoreId = Console.ReadLine();
                        int id;
                        result = int.TryParse(drugstoreId, out id);
                        if (result)
                        {
                            var drugstore = _drugstoreRepository.Get(d => d.Id == id);
                            if (drugstore != null)
                            {
                                var druggist = new Druggist()
                                {
                                    Name = druggistName,
                                    Surname = druggistSurname,
                                    Age = age,
                                    DrugStore = drugstore,
                                };
                                _druggistRepository.Create(druggist);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{druggist.Id} Name:{druggist.Name} Age:{druggist.Age} Experience:{druggist.Experience}");
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Drugstore Id");
                                goto allstore;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Id");
                            goto id;
                        }
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no DrugStore");
            }
        }
        #endregion

        #region UpdateDruggist
        public void UpdateDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            var drugstores = _drugstoreRepository.GetAll();
            if (druggists.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Druggist");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{druggist.Id} Name:{druggist.Name} Age:{druggist.Age} Experience:{druggist.Experience} ");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Druggist Id");
                string druggistId = Console.ReadLine();
                int id;
                bool result = int.TryParse(druggistId, out id);
                if (result)
                {
                    var druggist = _druggistRepository.Get(d => d.Id == id);
                    if (druggist != null)
                    {
                        string oldname = druggist.Name;
                        string oldsurname = druggist.Surname;
                        byte oldage = druggist.Age;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Druggist Name");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Druggist Surname");
                        string newSurname = Console.ReadLine();
                    age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Druggist Age");
                        string newAge = Console.ReadLine();
                        byte age;
                        result = byte.TryParse(newAge, out age);
                        if (result)
                        {
                        experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Druggist Experience");
                            string newExperience = Console.ReadLine();
                            double experience;
                            result = double.TryParse(newExperience, out experience);
                            if (result)
                            {
                            alll: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Drugstore");
                                foreach (var drugstore in drugstores)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drugstore.Id} Name:{drugstore.Name}");
                                }
                            idd: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter DrugStore Id");
                                string drugstoreId = Console.ReadLine();
                                int storeid;
                                result = int.TryParse(drugstoreId, out storeid);
                                if (result)
                                {
                                    var drugstore = _drugstoreRepository.Get(d => d.Id == storeid);
                                    if (drugstore != null)
                                    {
                                        var newDruggist = new Druggist()
                                        {
                                            Id = drugstore.Id,
                                            Name = newName,
                                            Surname = newSurname,
                                            Age = age,
                                        };
                                        _druggistRepository.Update(newDruggist);
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Id:{newDruggist.Id} NewName:{newName} NewSurname:{newSurname} NewAge:{age} NewExperience:{experience} NewDrugstore:{drugstore} successfully update");
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore id doesn't exist");
                                        goto alll;
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                                    goto idd;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter correct format experience");
                                goto experience;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter correct format age");
                            goto age;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This druggist doesn't exist");
                        goto all;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any druggist");
            }
        }
        #endregion

        #region DeleteDruggist
        public void DeleteDruggist()
        {
            var druggists = _druggistRepository.GetAll();

            if (druggists.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Druggist");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{druggist.Id} Name:{druggist.Name} Surname:{druggist.Surname} Experience:{druggist.Experience}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Druggist Id:");
                string druggistId = Console.ReadLine();
                int id;
                bool result = int.TryParse(druggistId, out id);
                if (result)
                {
                    var druggist = _druggistRepository.Get(d => d.Id == id);
                    if (druggist != null)
                    {
                        _druggistRepository.Delete(druggist);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{druggist.Id} is deleted.");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This druggist id doesn't exist");
                        goto all;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any Druggist");
            }
        }
        #endregion

        #region  GetAllDruggist
        public void GetAllDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Druggist");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{druggist.Id} Name:{druggist.Name} Surname:{druggist.Surname} Age:{druggist.Age} Experience:{druggist.Experience} ");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no druggist");
            }
        }


        #endregion

        #region GetAllDruggistByDrugStore
        public void GetAllDruggistByDrugStore()
        {
             
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
              all:  ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All DrugStores");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adresss} ContactNumber:{drugstore.ContactNumber} ");
                }
              id:  ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Drugstore Id");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == id);
                    if (drugstore!=null)
                    {
                        var druggists = _druggistRepository.GetAll(d => d.DrugStore.Id == drugstore.Id);
                        if (druggists.Count!=0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Druggist");
                            foreach (var druggist in druggists)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{druggist.Id} Name:{druggist.Name} Surname:{druggist.Surname} Age:{druggist.Age}");
                            }
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter correct Id");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no Drugstore");
            }
        }
        #endregion
    }
}
