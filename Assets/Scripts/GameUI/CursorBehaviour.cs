using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    public void LockFunction()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnLockFunction()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
