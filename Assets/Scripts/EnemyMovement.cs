using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    float speed;
    Rigidbody2D rb;
    Animator anim;
    public bool isStatic;
    public bool isWalker;
    public bool walksRight;
    public Transform wallCheck, pitCheck, groundCheck;
    public bool wallDetectec, pitDetected, isGround;
    public float detectionRadious;
    public LayerMask whatIsGround;
    public Transform pointA, pointB;
     public bool goToA, goToB;
    public bool isPatrol;

    // Start is called before the first frame update
    void Start()
    {
        goToA = true;
        speed = GetComponent<EnemyScript>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadious, whatIsGround);
        wallDetectec = Physics2D.OverlapCircle(wallCheck.position, detectionRadious, whatIsGround);
        isGround = Physics2D.OverlapCircle(groundCheck.position, detectionRadious, whatIsGround);

        if (pitDetected || wallDetectec && isGround)
        {

            Flip();

        }
    }

    private void FixedUpdate()
    {
        if (isStatic)
        {
            anim.SetBool("idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (isWalker)
        {

            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (!walksRight)
            {

                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);

            }
            else
            {

                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);

            }
            
            }
        if (isPatrol)

        {
            anim.SetBool("idle", false);
            if (goToA)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);

                Debug.Log("hola2");


                if ((transform.position.x-pointA.position.x)< 0.2f)
                {
                    Debug.Log("hola");
                    Flip();
                    goToA = false;
                    goToB = true;
                }
            }
            if (goToB)
            {

                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                if ((transform.position.x - pointB.position.x) > 0.2f)

                {
                    Flip();
                    goToA = true;
                    goToB = false;
                }
            }

        }
    }

    public void Flip()

    {

        walksRight = !walksRight;
        transform.localScale *= new Vector2(-1, transform.localScale.y);

    }
}
    