using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangePlayer : MonoBehaviour
{
    public Transform firePoint;
    public Transform fire;
    public Vector3 x1;
    // Start is called before the first frame update
    void Start()
    {
        x1 = fire.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 x2;
        bulletShoot bullet_shoot = GetComponent<bulletShoot>();
        if (Input.GetButtonDown("Fire1"))
        {
         //   bullet_shoot.destroyShoot();
             x1 = firePoint.position;
        }
        x2 = fire.position;
        if (x2.x-x1.x>=40){
            if(gameObject!=null)
            Destroy(gameObject);
        }
    }
}
