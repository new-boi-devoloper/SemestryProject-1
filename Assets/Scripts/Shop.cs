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
    private int  instrumentsToAdd = 1; // An Access for adding extra resources
    [SerializeField] private TextMeshProUGUI  instrumentsPriceText;

    [SerializeField] private MainClicker _mainClicker;
    [SerializeField] private ResourceBank _resourceBank;

    public void BuyWood()
    {
        if (_mainClicker.GetCoins() >= woodPrice)
        {
            _mainClicker.SetCoins(-woodPrice);
            _resourceBank.SetWood(woodToAdd);
            woodPriceText.text = $"{woodPrice}";
        }
    }

    public void BuyIron()
    {
        if (_mainClicker.GetCoins() >= ironPrice)
        {
            _mainClicker.SetCoins(-ironPrice);
            _resourceBank.SetIron(ironToAdd);
            ironPriceText.text = $"{ironPrice}";
        }
    }

    public void BuyInstruments()
    {
        if (_mainClicker.GetCoins() >= instrumentsPrice)
        {
            _mainClicker.SetCoins(-instrumentsPrice);
            _resourceBank.SetInstruments(instrumentsToAdd);
            instrumentsPriceText.text = $"{instrumentsPrice}";
        }
    }
}