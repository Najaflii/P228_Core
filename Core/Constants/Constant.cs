namespace Core.Constants
{
    public enum OwnerOptions
    {
        CreateOwner = 1,
        UpdateOwner,
        DeleteOwner,
        GetAllOwners,
        BackToMenu,
    }
    public enum DrugOptions
    {
        CreateDrug = 1,
        UpdateDrug,
        DeleteDrug,
        GetAllDrugByStore,
        GetDrugByStore,
        BackToMenu,
    }

    public enum DruggistOptions
    {
        CreateDruggist = 1,
        UpdateDruggist,
        DeleteDruggist,
        GetAllDruggist,
        GetAllDruggistByDrugStore,
        BackToMenu,
    }

    public enum DrugStoreOptions
    {
        CreateDrugStore = 1,
        UpdateDrugStore,
        DeleteDrugStore,
        GetAllDrugStore,
        SaleDrugStore,
        GetAllDrugStoreByOwner,
        BackToMenu,
    }
}

