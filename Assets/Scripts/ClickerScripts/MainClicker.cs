using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainClicker : MonoBehaviour
{
    [Header("Player's stats")]
    [SerializeField] private int coins; // main game currency
    [SerializeField] private int hitPower; //Amount to add to coins per click (was made to upgrade through the game)
    private int _passiveIncome = 0;
    
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI coinsText; // text to print amount off 

    private void Start()
    {
        InvokeRepeating(nameof(PassiveIncome), 1f, 1f);
    }

    public void MainButtonHit()
    {
        coins += hitPower;
        coinsText.text = $"Монет: {coins}";
        EventSystem.current
            .SetSelectedGameObject(null); // Only for making UI look unselected after selecting the button
    }

    #region Coins

    public int GetCoins()
    {
        return coins;
    }

    public void SetCoins(int coinsToAdd) //Multipurpose
    {
        coins += coinsToAdd;
        
        coinsText.text = $"Монет: {coins}";
    }
    public int GetHitPower()
    {
        return hitPower;
    }

    public void SetHitPower(int count)
    {
        hitPower += count;
    }

    #endregion

    #region PassvieIncome

    private void PassiveIncome()
    {
        coins += _passiveIncome;
        
        coinsText.text = $"Монет: {coins}";
    }

    public int GetPassiveIncome()
    {
        return _passiveIncome;
    }

    public void SetPassiveIncome(int count)
    {
        _passiveIncome += count;
    }

    #endregion
}