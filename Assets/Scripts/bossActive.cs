using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossActive : MonoBehaviour
{
    public GameObject boss;

    private void Start()
    {


        boss.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))

        {
            boss.SetActive(true);

            BossUI.instance.bossActive();
        }
    }

    
}
