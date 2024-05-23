using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour
{
    private int _woodPrice = 3;
    private int _woodToAdd = 1; // An Access for adding extra resources
    [SerializeField] private TextMeshProUGUI woodPriceText;

    private int _ironPrice = 5;
    private int _ironToAdd = 1; // An Access for adding extra resources
    [SerializeField] private TextMeshProUGUI ironPriceText;

    private int _blueprintsPrice = 7;
    private int _blueprintsToAdd = 1; // An Access for adding extra resources
    [SerializeField] private TextMeshProUGUI blueprintsPriceText;

    [SerializeField] private MainClicker mainClicker;
    [SerializeField] private ResourceBank resourceBank;

    public void BuyWood()
    {
        BuyItem(_woodPrice, _woodToAdd, ResourceType.Wood, woodPriceText);
    }

    public void BuyIron()
    {
        BuyItem(_ironPrice, _ironToAdd, ResourceType.Iron, ironPriceText);
    }

    public void BuyBlueprint()
    {
        BuyItem(_blueprintsPrice, _blueprintsToAdd, ResourceType.Blueprints, blueprintsPriceText);
    }

    private void BuyItem(int price, int quantity, ResourceType resourceType, TextMeshProUGUI priceText)
    {
        if (mainClicker.GetCoins() >= price)
        {
            mainClicker.SetCoins(-price);
            switch (resourceType)
            {
                case ResourceType.Wood:
                    resourceBank.SetWood(quantity);
                    break;
                case ResourceType.Iron:
                    resourceBank.SetIron(quantity);
                    break;
                case ResourceType.Blueprints:
                    resourceBank.SetBlueprints(quantity);
                    break;
            }

            priceText.text = $"{price}";
        }
    }
}

public enum ResourceType
{
    Wood,
    Iron,
    Blueprints
}