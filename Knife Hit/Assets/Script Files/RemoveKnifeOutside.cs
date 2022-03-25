using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveKnifeOutside : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Knife")
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
