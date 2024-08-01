using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1); //no filter above base model
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1); 
    [SerializeField] float customerDestroyDelay = 0.3f;
    [SerializeField] float packageDestroyDelay = 0.1f;
    private bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

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
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, packageDestroyDelay);
        }
        if (collision.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            UnityEngine.Debug.Log("Package delivered!");
            spriteRenderer.color = noPackageColor;
            Destroy(collision.gameObject, customerDestroyDelay);
        }
    }
}
