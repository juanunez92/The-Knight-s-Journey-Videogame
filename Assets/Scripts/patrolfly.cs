using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolfly : MonoBehaviour
{
    [SerializeField] private float vMovement;
    [SerializeField] private Transform[] pMovement;
    [SerializeField] private float dMinim;

    private SpriteRenderer sr;
    private int numberorder = 0;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pMovement[numberorder].position, vMovement * Time.deltaTime);

        if (Vector2.Distance(transform.position, pMovement[numberorder].position) < dMinim)

        {
            numberorder += 1;
            if (numberorder >= pMovement.Length)
            {
                numberorder = 0;
            }

        }
       
    }
}
