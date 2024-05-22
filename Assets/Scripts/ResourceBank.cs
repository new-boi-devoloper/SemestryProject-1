using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceBank : MonoBehaviour
{
    private int woodAmount;
    [SerializeField] private TextMeshProUGUI woodAmountText;

    private int ironAmount;
    [SerializeField] private TextMeshProUGUI ironAmountText;

    private int instrumentsAmount;
    [SerializeField] private TextMeshProUGUI instrumentsAmountText;

    //WOOD
    public int GetWood()
    {
        return woodAmount;
    }
    public void SetWood(int woodToAdd)
    {
        woodAmount += woodToAdd;
        woodAmountText.text = $"{woodAmount}";
    }
    
    //IRON
    public int GetIron()
    {
        return ironAmount;
    }
    public void SetIron(int ironToAdd)
    {
        ironAmount += ironToAdd;
        ironAmountText.text = $"{ironAmount}";
    }
    
    //INSTRUMENTS
    public int GetInstruments()
    {
        return instrumentsAmount;
    }
    public void SetInstruments(int instrumentsToAdd)
    {
        instrumentsAmount += instrumentsToAdd;
        instrumentsAmountText.text = $"{instrumentsAmount}";
    }
}
