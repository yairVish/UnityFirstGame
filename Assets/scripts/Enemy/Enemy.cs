using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int HEAL = 100;
    int DAMAGE =20;
    public float RANGE = 10f;
    public float RANGE_TO_JUMP = 3f;
    public float RANGE_TO_STOP = 0.5f;
    public Animator animator;
    public Transform player,enemy,bar;
    public Rigidbody2D rigidbody2D;
    public static bool danger=false;
    public Transform checkGround;
    public float targetTime = 60.0f, targetTime2 = 60.0f, targetTime_gone = 60.0f, targetTime_gone2 = 60.0f, targetTime_colosion=60.0f;
    public int MAXJUMP = 400;
    public GameObject hurt;
    public int i = 0, i2 = -1;
    public LayerMask layerMask;
    public bool bulletIsShootEnemy = false;
    public bool isGround, startActive = false;
    public Vector3 player_pos;
    public Vector3 enemy_pos;
    public float outPut = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Vector3 enemy_poos = transform.localPosition;
        enemy = transform;

    }

    // Update is called once per frame
    void Update()
    {
        player_pos = player.position;
        enemy_pos = transform.position;
        outPut = enemy_pos.x - player_pos.x;
        Debug.Log("transform: " + transform);
        targetTime_colosion -= Time.deltaTime;
        Physics2D.IgnoreLayerCollision(12, 12);
        // i = 0;
        thePlayerClose();
        //if(danger)
        //animator.SetBool("attack", true);

    }
    public void damage()
    {
        HEAL = HEAL - DAMAGE;
        Vector3 scaleBar = bar.localScale;
        scaleBar.x = scaleBar.x - 0.2f;
        bar.localScale = scaleBar;
       
    }
    public void thePlayerClose() {
    
        float currVel = Mathf.Abs(rigidbody2D.velocity.x);
        isGround = Physics2D.OverlapCircle(checkGround.position, 0.000001f, layerMask);
        if (((enemy_pos.x - player_pos.x <= RANGE && enemy_pos.x - player_pos.x >= 0) || enemy_pos.x - player_pos.x >= -RANGE
            && enemy_pos.x - player_pos.x <= 0)
            ||bulletIsShootEnemy)
        {
            
            if (!Physics2D.Linecast(enemy.position, enemy.position, 1 << LayerMask.NameToLayer("player")))
            {
                if ((enemy_pos.x - player_pos.x >= RANGE_TO_STOP && enemy_pos.x - player_pos.x >= 0)
                            || (enemy_pos.x - player_pos.x <= RANGE_TO_STOP
                         && enemy_pos.x - player_pos.x <= 0))
                {
                    if (isGround)
                    {
                        i2 = i;
                        //Debug.Log("enemy_pos.x - player_pos.x: " + (enemy_pos.x - player_pos.x));
                        targetTime -= Time.deltaTime;
                        if (enemy_pos.y + 1 < player_pos.y && targetTime <= 59.8f &&
                            ((enemy_pos.x - player_pos.x <= RANGE_TO_JUMP && enemy_pos.x - player_pos.x >= 0) || enemy_pos.x - player_pos.x >= -RANGE_TO_JUMP
                             && enemy_pos.x - player_pos.x <= 0))
                        {
                            if ((enemy_pos.x - player_pos.x >= RANGE_TO_JUMP / 2 && enemy_pos.x - player_pos.x >= 0)
                                || (enemy_pos.x - player_pos.x <= -RANGE_TO_JUMP / 2
                             && enemy_pos.x - player_pos.x <= 0))
                            {
                               // Debug.Log("y2");
                                if (enemy_pos.x - player_pos.x < 0)
                                {
                                  //  Debug.Log("y3");
                                    if (i == i2)
                                        rigidbody2D.AddForce(new Vector2(4, 400));
                                }
                                else if (enemy_pos.x - player_pos.x > 0)
                                {
                                    //Debug.Log("y4");
                                    if (i == i2)
                                        rigidbody2D.AddForce(new Vector2(-4, 400));
                                }
                                i++;
                                targetTime = 60.0f;
                            }
                        }
                    }

                    Vector3 scalePlayer = player.localScale;
                    Vector3 scaleEnemy = transform.localScale;
                    if (enemy_pos.x - player_pos.x < 0)
                    {
                        scaleEnemy.x = 0.5521771f;
                        transform.localScale = scaleEnemy;
                    }
                    else if (enemy_pos.x - player_pos.x > 0)
                    {
                        scaleEnemy.x = -0.5521771f;
                        transform.localScale = scaleEnemy;

                    }
                    animator.SetBool("attack", true);
                    danger = true;
                }
                else
                {
                    danger = false;
                    animator.SetBool("attack", false);
                }
                float xm = 0f;
                if (enemy_pos.x - player_pos.x < 0)
                {
                    if (currVel < 3f)
                    {
                         xm = 6f;
                    }
                    rigidbody2D.AddForce(new Vector2(xm, 0));
                }
                else if (enemy_pos.x - player_pos.x > 0)
                {
                    if (currVel < 3f)
                    {
                        xm = -6f;
                    }
                    rigidbody2D.AddForce(new Vector2(xm, 0));
                }
            }
        }
        else
        {
           // animator.SetBool("attack", false);
            //danger = false;
        }
        if (danger)
        {
            
              
        }
    }
    void OnTriggerEnter2D(Collider2D info)
    {
        bulletShoot bullet_shoot = info.GetComponent<bulletShoot>();
        if (bullet_shoot != null)
        {
            bulletIsShootEnemy = true;

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "water")
        {
            if (targetTime_colosion <= 59.9f)
            {
                rigidbody2D.AddForce(new Vector2(0, 470));
                targetTime_colosion = 60f;
            }
        }
    }
}
