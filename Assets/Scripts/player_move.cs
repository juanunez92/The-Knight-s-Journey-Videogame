using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{

    private Rigidbody2D rig;
    private SpriteRenderer spritePersonaje;
    float fuerzaSalto = 4f;
    int numJump = 1;
    int useJump;
    Animator anim;

    [SerializeField] private float velocidadPersonaje;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        spritePersonaje = GetComponent<SpriteRenderer>();
        useJump = 0;
        anim = GetComponent<Animator>();
    }

    public void Jump()
    {
        if (Input.GetKey("k"))
        {
            if (useJump < numJump)
            {
                rig.AddForce(new Vector3(0f, fuerzaSalto), ForceMode2D.Impulse);
                useJump++;
            }
    
        }
        
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.collider.tag == "ground")
        {
            useJump = 0;
        }
        
    }
    private void FixedUpdate()
    {
        Jump();
        Attack();

        float velocidadInput = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(velocidadInput * velocidadPersonaje, rig.velocity.y);
        if (velocidadInput < 0)
        {
            spritePersonaje.flipX = true;
        }
        if (velocidadInput > 0)
        {
            spritePersonaje.flipX = false;
        }
        if (rig.velocity.x !=0)
        {
            anim.SetBool("walk", true);
        }
        else {
            anim.SetBool("walk",false);
        }

    }
    public void Attack()
    {
        if (Input.GetKey("l"))
        {

            anim.SetBool("atack", true);

        }
        else
        {

            anim.SetBool("atack", false);
        }


    }

}

