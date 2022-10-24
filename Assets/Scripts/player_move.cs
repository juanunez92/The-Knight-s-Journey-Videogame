using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{

    private Rigidbody2D rig;
    private SpriteRenderer spritePersonaje;
    float fuerzaSalto = 3f;
    int numJump = 1;
    int useJump;

    [SerializeField] private float velocidadPersonaje;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        spritePersonaje = GetComponent<SpriteRenderer>();
        useJump = 0;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        if (obj.collider.tag == "ground") {
            useJump = 0;
        }
    }
    private void FixedUpdate()
    {
        Jump();
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
    }
}

