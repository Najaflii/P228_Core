using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
   public enum AdminOptions
    {
        Logout = 1,
        Menu = 0,
    }

    #region Owner
    public enum OwnerOptions
    {
        CreateOwner = 1,
        UpdateOwner,
        DeleteOwner,
        GetAllOwner,
        BackToMainMenu = 0,
    }
    #endregion


    #region Drug 
    public enum DrugOptions

    {
        CreateDrug = 1,
        UpdateDrug,
        DeleteDrug,
        GetAllDrug,
        GetAllDrugByStore,
        DrugFilter,
        BackMainMenu = 0,
    }
    #endregion


    #region Druggist
    public enum DruggistOptions
    {
        CreateDruggist = 1,
        UpdateDruggist,
        DeleteDruggist,
        GetAllDruggist,
        BackToMainMenu = 0,
    }
    #endregion


    #region DrugStore
    public enum DrugStoreOptions
    {
        CreateDrugStore = 1,
        UpdateDrugStore,
        DeleteDrugStore,
        GetAllDrugStore,
        GetAllDrugStoreByOwner,
        Sale,
        BackToMainMenu = 0,
    }
    #endregion
}

