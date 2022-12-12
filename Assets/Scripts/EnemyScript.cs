using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public static EnemyScript instance;



    public string enemyname;
    public float healthPoints;
    public float speed;
    public float knockbackForceX;
    public float knockbackForceY;
    public float damage;
}
