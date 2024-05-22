using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private int woodPrice = 3;
    private int woodToAdd = 1; // An Access for adding extra resources
    [SerializeField] private TextMeshProUGUI woodPriceText;

    private int ironPrice = 5;
    private int ironToAdd = 1; // An Access for adding extra resources
    [SerializeField] private TextMeshProUGUI ironPriceText;

    private int instrumentsPrice = 7;
    private int instrumentsToAdd = 1; // An Access for adding extra resources
    [SerializeField] private TextMeshProUGUI instrumentsPriceText;

    [SerializeField] private MainClicker _mainClicker;
    [SerializeField] private ResourceBank _resourceBank;

    public void BuyWood()
    {
        BuyItem(woodPrice, woodToAdd, ResourceType.Wood, woodPriceText);
    }

    public void BuyIron()
    {
        BuyItem(ironPrice, ironToAdd, ResourceType.Iron, ironPriceText);
    }

    public void BuyInstruments()
    {
        BuyItem(instrumentsPrice, instrumentsToAdd, ResourceType.Instruments, instrumentsPriceText);
    }

    private void BuyItem(int price, int quantity, ResourceType resourceType, TextMeshProUGUI priceText)
    {
        if (_mainClicker.GetCoins() >= price)
        {
            _mainClicker.SetCoins(-price);
            switch (resourceType)
            {
                case ResourceType.Wood:
                    _resourceBank.SetWood(quantity);
                    break;
                case ResourceType.Iron:
                    _resourceBank.SetIron(quantity);
                    break;
                case ResourceType.Instruments:
                    _resourceBank.SetInstruments(quantity);
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
    Instruments
}
