using Core.Entities;
using Core.Helpers;
using DataAccess.Impelementations;

namespace Pharmacy.Controllers
{
    public class OwnerController
    {

        private OwnerRepository _ownerRepository;

        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();
        }


        #region CreateOwner
        public void CreateOwner()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Owner Name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Owner Surname");
            string surname = Console.ReadLine();

            var owner = new Owner
            {
                Name = name,
                Surname = surname
            };
            var createdOwner = _ownerRepository.Create(owner);
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname} Owner was successfully create");
        }
        #endregion

        #region UpdateOwner
        public void UpdateOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
              all:  ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
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
                        string oldName = owner.Name;
                        string oldSurname = owner.Surname;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "Enter new owner name");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "Enter new owner surname");
                        string newSurname = Console.ReadLine();

                        var newOwner = new Owner
                        {
                            Id=owner.Id,    
                            Name = newName,
                            Surname = newSurname,
                        };
                        _ownerRepository.Update(newOwner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $" Owner update:Id:{newOwner.Id}  NewName:{newOwner.Name} NewSurname:{newOwner.Surname}");
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

        #region DeleteOwner
        public void DeleteOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner Id:");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        _ownerRepository.Delete(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{id} Name:{owner.Name} Surname:{owner.Surname} - owner was delete");
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

        #region GetAll
        public void GetAll()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All owner");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There's no owner");
            }
        }
        #endregion
    }
}