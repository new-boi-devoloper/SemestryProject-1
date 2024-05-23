using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ResourceBank : MonoBehaviour
{
    private int woodAmount;
    [SerializeField] private TextMeshProUGUI woodAmountText;

    private int ironAmount;
    [SerializeField] private TextMeshProUGUI ironAmountText;

    private int blueprintsAmount;
    [SerializeField] private TextMeshProUGUI blueprintsAmountText;

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
    public int GetBlueprints()
    {
        return blueprintsAmount;
    }

    public void SetBlueprints(int blueprintsToAdd)
    {
        blueprintsAmount += blueprintsToAdd;
        blueprintsAmountText.text = $"{blueprintsAmount}";
    }
}