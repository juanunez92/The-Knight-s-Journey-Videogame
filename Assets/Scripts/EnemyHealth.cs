using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    EnemyScript enemy;
    Animator animDeath;
    public bool setDeath;
    Rigidbody2D rb;
    public bool damaged;
    private AudioSource audioSource;

    private void Awake()
    {
        enemy = GetComponent<EnemyScript>();
        animDeath = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        SetAnimDeath();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("weapon") && !damaged)
        {
            enemy.healthPoints -= 2f;
            audioSource.Play();
            StartCoroutine(DamageSp());


            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);

            }
            else {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);


            }

            if (enemy.healthPoints <= 0)
            {
                setDeath = true;
                Destroy(gameObject, 1);

            }
        }
    }
    void SetAnimDeath()
    {

        animDeath.SetBool("death", setDeath);
    }

    IEnumerator DamageSp()
    {
        damaged = true;
        yield return new WaitForSeconds(0.5f);
        damaged = false;


    }
}