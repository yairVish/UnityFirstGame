using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public Transform bullet;
    public float targetTime = 60.0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 x1=firePoint.position;
        Vector3 x2 = bullet.position;
        if (Enemy.danger)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 59.5f)
            {
                //creatBullet();
                targetTime = 60.0f;
            }
        }
    }
    public void creatBullet()
    {
        //StartCoroutine(waiter());
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2000);
    }
}
