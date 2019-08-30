using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent onEter, onStay, onExit;

    private void OnTriggerEnter2D(Collider2D col)
    {
        
    }
}
