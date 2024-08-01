using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("hit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package")) 
            UnityEngine.Debug.Log("Package picked up!");

        if (collision.CompareTag("Customer"))
            UnityEngine.Debug.Log("Package delivered!");
    }
}
