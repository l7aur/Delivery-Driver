using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private bool hasPackage = false;
    [SerializeField] float customerDestroyDelay = 0.3f;
    [SerializeField] float packageDestroyDelay = 0.1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("hit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            UnityEngine.Debug.Log("Package picked up!");
            Destroy(collision.gameObject, packageDestroyDelay);
        }
        if (collision.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            UnityEngine.Debug.Log("Package delivered!");
            Destroy(collision.gameObject, customerDestroyDelay);
        }
    }
}
