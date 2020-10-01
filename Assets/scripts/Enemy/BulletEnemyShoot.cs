using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyShoot : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 scaleEnemy = transform.localScale;
        if (scaleEnemy.x < 0)
        {
            rigidbody2D.velocity = transform.right * -10f;
        }
        else
        {
            rigidbody2D.velocity = transform.right * 10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
