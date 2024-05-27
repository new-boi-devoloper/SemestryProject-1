using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField] private ResourceBank resourceBank;
    [SerializeField] private MainClicker mainClicker;
    [SerializeField] private List<GameObject> boughtBuildings;

    public static SaveLoadSystem Instance;

    public void Awake() //??? Нужно ли
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void SaveData()
    {
        #region MainClicker Save Data

        PlayerPrefs.SetInt("Coins", mainClicker.GetCoins());
        PlayerPrefs.SetInt("PassiveIncome", mainClicker.GetPassiveIncome());
        PlayerPrefs.SetInt("HitPower", mainClicker.GetHitPower());

        #endregion


        #region ResourceBank Save Data

        PlayerPrefs.SetInt("Wood", resourceBank.GetWood());
        PlayerPrefs.SetInt("Iron", resourceBank.GetIron());
        PlayerPrefs.SetInt("Blueprints", resourceBank.GetBlueprints());

        #endregion
    }

    public void LoadData()
    {
        #region MainClicker Load Data

        mainClicker.SetCoins(PlayerPrefs.GetInt("Coins"));
        mainClicker.SetPassiveIncome(PlayerPrefs.GetInt("PassiveIncome"));
        mainClicker.SetHitPower(PlayerPrefs.GetInt("HitPower"));

        #endregion


        #region ResourceBank Load Data

        resourceBank.SetWood(PlayerPrefs.GetInt("Wood"));
        resourceBank.SetIron(PlayerPrefs.GetInt("Iron"));
        resourceBank.SetBlueprints(PlayerPrefs.GetInt("Blueprints"));

        #endregion

        foreach (var building in boughtBuildings)
        {
            building.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        boughtBuildings.Clear();
    }

    public void AddBuilding(GameObject buildingToAdd)
    {
        boughtBuildings.Add(buildingToAdd);
    }

    public void RemoveBuilding(GameObject buildingToRemove) //Just for any case
    {
        boughtBuildings.Remove(buildingToRemove);
    }
}