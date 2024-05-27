using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private TextMeshProUGUI interactionText;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) )
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interactionUI.SetActive(true);

        IInteractableObject interactableBuilding = other.GetComponentInParent<IInteractableObject>();
        
        interactionText.text = interactableBuilding.GetDescription();
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactableBuilding.Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactionUI.SetActive(false);
    }
}