using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager InputManagerInstance;

    public bool ClickerOpenCloseState { get; private set; }

    private PlayerInput _playerInput;
    private InputAction _clickerOpenCloseAction;

    private void Awake()
    {
        if (InputManagerInstance == null)
        {
            InputManagerInstance = this;
        }

        _playerInput = GetComponent<PlayerInput>();
        _clickerOpenCloseAction = _playerInput.actions["ClickerOpenClose"];
    }

    private void Update()
    {
        ClickerOpenCloseState = _clickerOpenCloseAction.WasPressedThisFrame();
    }
}