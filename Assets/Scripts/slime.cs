using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class slime : MonoBehaviour
{

    EnemyScript enemy;
    Animator animDeath;
    public bool setDeath;
    Rigidbody2D rb;
    public bool damaged;
    blink material;
    SpriteRenderer sprite;
    public Image healthBar;

    private void Awake()
    {
        enemy = GetComponent<EnemyScript>();
        animDeath = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<blink>();
        sprite = GetComponent<SpriteRenderer>();


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
            StartCoroutine(DamageSp());


            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);

            }
            else
            {
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
        sprite.material = material.blinks;
        yield return new WaitForSeconds(0.5f);
        damaged = false;
        sprite.material = material.original;


    }
}