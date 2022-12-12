using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    float moveSpeed;
    Rigidbody2D rb;
    Vector2 mD;
    player_move target;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GetComponent<EnemyScript>().speed;
        rb = GetComponent<Rigidbody2D>();
        target = player_move.instance;
        mD = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(mD.x, mD.y);
    }

    
}
