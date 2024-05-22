using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MainClicker : MonoBehaviour
{
    [SerializeField] private int coins; // main game currency
    [SerializeField] private int hitPower; //Amount to add to coins per click (was made to upgrade through the game)  
    [SerializeField] private TextMeshProUGUI coinsText; // text to print amount off 
    
    public void MainButtonHit() 
    {
        coins+=hitPower;
        coinsText.text = $"Монет: {coins}";
        EventSystem.current.SetSelectedGameObject(null); // Only for making UI look unselected after selecting the button
    }

    public int GetCoins()
    {
        return coins;
    }

    public void SetCoins(int coinsToAdd) //Multipurpose
    {
        coins += coinsToAdd;
        coinsText.text = $"Монет: {coins}";
    }
}