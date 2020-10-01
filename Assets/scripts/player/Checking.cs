using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking : MonoBehaviour
{
    public Transform point;
    public Vector3 pos,pos2;
    public bool shootTheE = false;
    public bool isEnemy;
    public Transform checkGround;
    public Vector3 player_pos, enemy_pos;
    public LayerMask layerMask;
    public Rigidbody2D playerRigid;
    public Transform player, bar;
    public float remPlayerY, remPlayerY2;
    public GameObject effect;
    public Rigidbody2D rigidPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        pos = transform.position;
        pos2 = point.position;
        pos.x = pos2.x;
        pos.y = pos2.y;
        transform.position = pos;
        enemy_pos = transform.position;
        player_pos = player.position;

    }
    void OnTriggerEnter2D(Collider2D info)
    {
        Water water = info.GetComponent<Water>();
        Enemy enemyy = info.GetComponent<Enemy>();
        if (enemyy != null)
        {
            if (player_pos.y > enemy_pos.y)
            {
                if (rigidPlayer.velocity.y < -0.1)
                {
                    shootTheE = false;
               //     enemyy.damage();
               // rigidPlayer.AddForce(new Vector2(movePlayer.x, 50));
                 }
            }
        }
      
    }
    void OnTriggerStay2D(Collider2D info)
    {
        
        Enemy enemyy = info.GetComponent<Enemy>();
        if (enemyy != null)
        {
            remPlayerY2 = player_pos.y;
            if (player_pos.y > enemy_pos.y)
            {
                if (rigidPlayer.velocity.y < -0.1)
                {
                  
                shootTheE = true;
                }
            }
            remPlayerY = player_pos.y;
        }
      //  Debug.Log("OnTriggerEnter2DCheck: " + info);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
     //   if(collision.gameObject.tag=="water")
        Debug.Log("collision: " + collision.gameObject.tag);
    }
}
