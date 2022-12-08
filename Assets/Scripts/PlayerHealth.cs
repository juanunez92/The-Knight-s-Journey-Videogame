    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
    {


        public float health;
        public float maxh;
        bool inmun;
        public float inmunityTime;
        blink material;
        SpriteRenderer sprite;
        public float goBackHitX;
        public float goBackHitY;
        public Image healthBar;
        Rigidbody2D rg;


        // Start is called before the first frame update
        void Start()
        {
            health = maxh;
            material = GetComponent<blink>();
            sprite = GetComponent<SpriteRenderer>();
            rg = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
        healthBar.fillAmount = health / 100;
            if (health > maxh) {

                health = maxh;

            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("enemy")&& !inmun) {

                health -= collision.GetComponent<EnemyScript>().damage;
                StartCoroutine(Inmunnity());

                if (collision.transform.position.x > transform.position.x)
                {

                    rg.AddForce(new Vector2(-goBackHitX, goBackHitY), ForceMode2D.Force);
                }
                else
                {

                    rg.AddForce(new Vector2(goBackHitX, goBackHitY), ForceMode2D.Force);

                }


                if (health <= 0) {


                    //PONER REINICIO O PANTALLA MUERTE
                    print("jugador muerto");
                }
            }
        }
        IEnumerator Inmunnity() {

            inmun = true;
            sprite.material = material.blinks;
            yield return new WaitForSeconds(inmunityTime);
            inmun = false;
            sprite.material = material.original;

        }
    }
