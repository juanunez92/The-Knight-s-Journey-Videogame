using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodRecover : MonoBehaviour
{

    public float healthRecover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            collision.GetComponent<PlayerHealth>().health += healthRecover;
            Destroy(gameObject);
            }
    }
}
