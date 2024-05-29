using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField] private ResourceBank resourceBank;
    [SerializeField] private MainClicker mainClicker;
    private static List<GameObject> _boughtBuildings;

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

    private void OnDestroy()
    {
        SaveData();
    }

    private void Awake()
    {
        LoadData();
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


        if (_boughtBuildings != null)
        {
            foreach (var building in _boughtBuildings)
            {
                building.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();

        #region Mainclicker set to 0

        var coins = mainClicker.GetCoins();
        mainClicker.SetCoins(-coins);
        
        var hitPower = mainClicker.GetHitPower();
        mainClicker.SetHitPower(-hitPower+1);
        
        var passiveIncome = mainClicker.GetPassiveIncome();
        mainClicker.SetPassiveIncome(-passiveIncome);
        
        #endregion

        
        #region ResourceBank set to 0

        var wood = resourceBank.GetWood();
        resourceBank.SetWood(-wood);
        
        var iron = resourceBank.GetIron();
        resourceBank.SetIron(-iron);
        
        var blueprints = resourceBank.GetBlueprints();
        resourceBank.SetBlueprints(-blueprints);

        #endregion

        if (_boughtBuildings != null)
        {
            _boughtBuildings.Clear();
        }
    }

    public void AddBuilding(GameObject buildingToAdd)
    {
        _boughtBuildings.Add(buildingToAdd);
    }

    public void RemoveBuilding(GameObject buildingToRemove) //Just for any case
    {
        _boughtBuildings.Remove(buildingToRemove);
    }
}