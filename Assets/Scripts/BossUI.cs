using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{

    public GameObject bossLife;
    public GameObject wallBoss;

    public static BossUI instance;


    private void Awake()
    {

        if (instance == null) {

            instance = this;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bossLife.SetActive(false);
        wallBoss.SetActive(false);
    }

    public void bossActive() {

        bossLife.SetActive(true);
        wallBoss.SetActive(true);

    }

    public void bossNoActive()

    {
        bossLife.SetActive(false);
        wallBoss.SetActive(false);
    }
}
