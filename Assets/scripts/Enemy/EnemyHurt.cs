using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    public bool shootTheE = false;
    public bool isEnemy;
    public Transform checkGround;
    public Vector3 player_pos, enemy_pos;
    public LayerMask layerMask;
    public Transform player,bar;
    public float remPlayerY, remPlayerY2;
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isEnemy = Physics2D.OverlapCircle(checkGround.position, 0.5f, layerMask);
        enemy_pos = transform.position;
        player_pos = player.position;
        remPlayerY2 = player_pos.y;
        isShootEnemy();
        remPlayerY = player_pos.y;
    }
    public void isShootEnemy()
    {
        shootTheE = false;
        if (isEnemy)
        {
            if (player_pos.y > enemy_pos.y)
            {
                if (remPlayerY > remPlayerY2)
                {
                    shootTheE = false;
                     Vector3 scaleBar = bar.localScale;
                    scaleBar.x = scaleBar.x - 0.25f;
                  /*  if (scaleBar.x < 0)
                    {
                        Instantiate(effect, transform.position, transform.rotation);
                        Destroy(gameObject);
                    }*/
                    bar.localScale = scaleBar;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D info)
    {
    }
}
