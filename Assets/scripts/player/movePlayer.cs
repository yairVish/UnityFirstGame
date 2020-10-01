using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class movePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public float maxVel=5f;
    public float speedPlayer=10f;
    public Transform player, enemy,bar,barPlayer;
    public bool isGround;
    public bool isEnemy;
    public Transform checkGround,effect2,effectPoint;
    public int MAXJUMP=400;
    public LayerMask layerMask, layerMask2;
    public Transform firePoint;
    public GameObject gun,hurt;
    public GameObject bullet,checkFirePlayer;
    public Transform bulletT,gunT;
    public float targetTime = 60.0f, targetTime2=60.0f, targetTime_gone=60.0f, targetTime_gone2 = 60.0f
        , targetTime_plus=60.0f, targetTime_fire = 60.0f, targetTime_colosion= 60.0f;
    public Vector3 player_pos, enemy_pos;
    public float remPlayerY,remPlayerY2;
    public Transform leg1, leg2;
    public bool shootTheE=false,enemyShoot=false,startActive=false;
    public static float x = 0f;
    public Vector2 whereToSwap;
    public float randPlus=55.5f;
   // public float n
    void Start()
    {
        hurt.SetActive(false);
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 scaleBar2 = barPlayer.localScale;
        if (scaleBar2.x < 0)
        {
            Debug.Log("died!!!!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        /////create enemy....
        targetTime_plus -= Time.deltaTime;
        if (targetTime_plus <= randPlus)
        {
            Vector3 scaleEnemy = enemy.localScale;
            randPlus = Random.Range(45.5f, 55.5f);
            float randX = Random.Range(transform.localPosition.x - 10f, transform.localPosition.x + 10f);
            if (randX < 0)
            {
                randX -= 5f;
                scaleEnemy.x = -0.5521771f;
                enemy.localScale = scaleEnemy;
            }
            else
            {
                randX += 6f;
                scaleEnemy.x = 0.5521771f;
                enemy.localScale = scaleEnemy;
            }
            targetTime_plus = 60f;
            whereToSwap = new Vector2(randX, transform.position.y+10);
            Instantiate(enemy, whereToSwap, checkGround.rotation);
        }
        ///create enemy...
        float inputX = Input.GetAxis("Horizontal");
        float currVel=Mathf.Abs(rigidbody2D.velocity.x);
        isGround = Physics2D.OverlapCircle(checkGround.position,0.5f, layerMask);
     Physics2D.IgnoreLayerCollision(11, 12);
         player_pos=player.position;
         enemy_pos=player.position;
        targetTime_colosion-=Time.deltaTime;
        if (enemy != null)
        {
            isEnemy = Physics2D.OverlapCircle(checkGround.position, 0.5f, layerMask2);
             player_pos = player.position;
             enemy_pos = enemy.position;

        }
        if (Physics2D.Linecast(player.position,player.position, 1 << LayerMask.NameToLayer("enemy"))&&!enemyShoot) {
            enemyShoot = true;
            targetTime2 = 60.0f;
            Vector3 scaleBar = barPlayer.localScale;
            scaleBar.x = scaleBar.x - 0.1f;
            barPlayer.localScale = scaleBar;
        }
        if (enemyShoot)
        {
            targetTime_gone -= Time.deltaTime;
            targetTime2 -= Time.deltaTime;
            if(targetTime_gone<= 59.8f)
            {
                startActive = true;
                ///animator.SetInteger("nothing",1);
                hurt.SetActive(false);
                targetTime_gone = 60.0f;
            }
            if (startActive)
            {
                targetTime_gone2 -= Time.deltaTime;
                if (targetTime_gone2 <= 59.9f)
                {
                
                    hurt.SetActive(true);
                    startActive = false;
                    targetTime_gone2 = 60.0f;
                }
            }
            if (targetTime2<=59.0f)
            {
              
                enemyShoot = false;
                hurt.SetActive(false);

            }
        }
        remPlayerY2 = player_pos.y;
        //Debug.Log("remPlayerY2: " + remPlayerY2);
        isShootEnemy(x);
        move_player(x,currVel,inputX);
        getButtonFire();
        remPlayerY = player_pos.y;
      //  Debug.Log("remPlayerY: " + remPlayerY);
    }
    public void creatBullet()
    {
        var mouse_position = Input.mousePosition - UnityEngine.Camera.main.WorldToScreenPoint(bulletT.position);
        var angle = Mathf.Atan2(mouse_position.y, mouse_position.x) * Mathf.Rad2Deg;
        bulletT.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 scale = transform.localScale;
        Vector3 rot = gunT.localScale;
        bulletT.rotation = gunT.rotation;
        if (scale.x < 0)
        {
            bulletT.up = bulletT.up * -1f;
        }
        Instantiate(bullet, firePoint.position, bulletT.rotation);
    }
    public void move_player(float x,float currVel,float inputX)
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {

            rigidbody2D.AddForce(new Vector2(x, MAXJUMP));
        }
        else
       if (inputX > 0)
        {
            if (maxVel > currVel)
            {
                x = speedPlayer;
            }
            rigidbody2D.AddForce(new Vector2(x, 0));
            //Vector3 scale = leg1.localScale;
            //if (leg1.localScale.x > 0) { scale.x = leg1.localScale.x; } else { scale.x = -leg1.localScale.x; }
            //leg1.localScale = scale;
            //Vector3 scale2 = leg2.localScale;
            //if (leg2.localScale.x > 0) { scale2.x = leg1.localScale.x; } else { scale2.x = -leg2.localScale.x; }
            //leg2.localScale = scale2;
        }
        else if (inputX < 0)
        {
            if (maxVel > currVel)
            {
                x = -speedPlayer;
            }
            rigidbody2D.AddForce(new Vector2(x, 0));
           //Vector3 scale = leg1.localScale;
           // if (leg1.localScale.x < 0) { scale.x = leg1.localScale.x; } else { scale.x = -leg1.localScale.x; }
           // leg1.localScale = scale;
           // Vector3 scale2 = leg2.localScale;
           // if (leg2.localScale.x < 0) { scale2.x = leg1.localScale.x; } else { scale2.x = -leg2.localScale.x; }
           // leg2.localScale = scale2;
        }
    }
    public void getButtonFire()
    {
        targetTime_fire -= Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (targetTime_fire <= 59.85f)
            {
                Instantiate(effect2, effectPoint.position, effectPoint.rotation);
                creatBullet();
                targetTime_fire = 60f;
            }
            targetTime = 60f;
       //     gun.SetActive(true);
        }
        else
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 59.0f)
            {
            //    gun.SetActive(false);
            }
        }
    }
    public void isShootEnemy(float x)
    {
        shootTheE = false;
        if (isEnemy && enemy != null)
        {
            if (player_pos.y > enemy_pos.y)
            {

                if (remPlayerY > remPlayerY2)
                {
                    shootTheE = false;

                  //  rigidbody2D.AddForce(new Vector2(x, 700));
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D info)
    {
        Debug.Log("inf2: " + info);
        coin co = info.GetComponent<coin>();
        Water water = info.GetComponent<Water>();
        if (co != null)
        {
            Debug.Log("inside");
            Destroy(info.gameObject);
        }
        if (water != null)
        {
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "water")
        {
            if (targetTime_colosion <= 59.9f)
            {
                Vector3 scaleBar = barPlayer.localScale;
                scaleBar.x = scaleBar.x - 0.1f;
                barPlayer.localScale = scaleBar;
                rigidbody2D.AddForce(new Vector2(x, 470));
                targetTime_colosion = 60f;
            }
        }
        Debug.Log("collision: " + collision.gameObject.tag);
    }

}
