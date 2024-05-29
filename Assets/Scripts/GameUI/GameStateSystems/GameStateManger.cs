using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Serialization;

public class GameStateManger : MonoBehaviour
{
    [SerializeField] private GameObject clickerContainer;
    [SerializeField] private CursorBehaviour _cursorBehaviour;
    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeField] private Animator stateAnim;

    private bool isInClicker;

    private void Start()
    {
        clickerContainer.SetActive(false);
        _cursorBehaviour.LockFunction();
        thirdPersonController.GetComponentInChildren<ThirdPersonController>();
        thirdPersonController.enabled = true; //Just for any case better to make true apriori
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isInClicker)
            {
                OpenClicker();
            }
            else
            {
                CloseClicker();
            }
        }
    }

    private void OpenClicker()
    {
        isInClicker = true;

        clickerContainer.SetActive(true);
        _cursorBehaviour.UnLockFunction();
        stateAnim.SetFloat("Speed", 0);
        thirdPersonController.enabled = false;
    }

    private void CloseClicker()
    {
        isInClicker = false;

        clickerContainer.SetActive(false);
        _cursorBehaviour.LockFunction();
        thirdPersonController.enabled = true;
    }
}