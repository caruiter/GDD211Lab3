using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthDrop : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("check");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().AddHealth();
            gameObject.SetActive(false);
        }
    }
}
