using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MakeButtonUnselected : MonoBehaviour
{
    // Only for making UI look unselected after selecting the button
    
    public void MakeButtonUnselectedFunction()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}