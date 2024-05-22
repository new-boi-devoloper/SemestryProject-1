using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExitEnterPlayMode : MonoBehaviour
{
    [SerializeField] private Button mainButton;
    private bool isInPlayMode;

    private void Start()
    {
        isInPlayMode = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && isInPlayMode)
        {
            mainButton.gameObject.SetActive(true);
            isInPlayMode = false;
        }
        else
        {
            mainButton.gameObject.SetActive(false);
            isInPlayMode = true;
        }
    }
}