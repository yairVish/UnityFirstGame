using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public Rigidbody2D rigidbody2D;
    public Transform player;
    public Transform checking;
    public Transform sploit;
    public LayerMask layerMask;
    public bool isGround;
    public Transform effectPoint;
    public GameObject effect,effect2;
    public Animator animator;
    public Transform firePoint;
    public Transform fire;
    public Vector3 x1;
    void Start()
    {
                x1 = fire.position;
        animator = GetComponent<Animator>();
        Vector3 scale = player.localScale;
        if (scale.x > 0f)
        {
            Vector3 scale2 = transform.localScale;
            if (transform.localScale.x > 0) { scale2.x = transform.localScale.x; } else { scale2.x = -transform.localScale.x; }
            transform.localScale = scale2;
            rigidbody2D.velocity = transform.right * 20f;
        }
        else if (scale.x < 0f)
        {
            Vector3 scale2 = transform.localScale;
            if (transform.localScale.x < 0) { scale2.x = transform.localScale.x; } else { scale2.x = -transform.localScale.x; }
            transform.localScale = scale2;
            rigidbody2D.velocity = transform.right * -20f;
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D info)
    {
        Enemy enemy = info.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.damage();
        }
         Instantiate(effect, transform.position, transform.rotation);
      if(gameObject!=null)
        Destroy(gameObject);
    }
    void Update()
    {
        //Physics2D.IgnoreLayerCollision(14, 12);
        Vector3 x2;
        Physics2D.IgnoreLayerCollision(14, 13);
        Physics2D.IgnoreLayerCollision(14, 11);
        Physics2D.IgnoreLayerCollision(14, 15);
        bulletShoot bullet_shoot = GetComponent<bulletShoot>();
        if (Input.GetButtonDown("Fire1"))
        {
            //   bullet_shoot.destroyShoot();
            x1 = firePoint.position;
        }
        x2 = fire.position;
        if ((x2.x-x1.x>=13|| x2.x - x1.x <=-13) &&x2.y>-18.305)
        {
            if (gameObject != null)
                Destroy(gameObject);
        }
    }
    public void inputMouse()
    {
            var mouse_position = Input.mousePosition - UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(mouse_position.y, mouse_position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
   }
