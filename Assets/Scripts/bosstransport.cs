using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bosstransport : MonoBehaviour
{
    public Transform[] transforms;

    public GameObject flame;
    public float timeshooting, count;
    public float tmtp;
    public float countTP;

    public float heatlhBoss;
    public float currentlife;
    public Image bar;

    private void Start()
    {
        var IPos = Random.Range(0, transforms.Length);
        transform.position = transforms[IPos].position;
        count = timeshooting;
        countTP = tmtp;

    }

    private void Update()
    {
        Damage();
        counts();
        seePlayer();
    }

    public void Shootplayer()
    {

        GameObject spell = Instantiate(flame, transform.position, Quaternion.identity);
    }

    public void teleport() {
        var IPos = Random.Range(0, transforms.Length);
        transform.position = transforms[IPos].position;


    }

    private void OnDestroy()
    {
        BossUI.instance.bossNoActive();
    }

    public void Damage() {

        currentlife = GetComponent<EnemyScript>().healthPoints;
        bar.fillAmount = currentlife / heatlhBoss;

    }
    public void counts()
    {

        count -= Time.deltaTime;
        countTP -= Time.deltaTime;

        if (count <= 0f)
        {

            Shootplayer();
            count = timeshooting;
            teleport();

        }
        if (countTP <= 0)
        {

            countTP = tmtp;
            teleport();
        }
    }
    public void seePlayer() {

        if (transform.position.x > player_move.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);

        }

    } }
    

