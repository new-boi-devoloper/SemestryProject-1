using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            var placeToSpawn = GetComponentInChildren<Transform>();
            hit.gameObject.transform.position = placeToSpawn.position;
        }
    }
}