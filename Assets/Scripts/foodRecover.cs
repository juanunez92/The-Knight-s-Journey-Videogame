using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodRecover : MonoBehaviour
{
    [SerializeField] private AudioClip sound1;

    public float healthRecover;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            collision.GetComponent<PlayerHealth>().health += healthRecover;
            ControlSound.Instance.ejectSound(sound1);
            Destroy(gameObject);
        }
    }


}
