using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDied : MonoBehaviour
{
    public Transform bar;
    public GameObject effect;
    public Transform effectT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scaleBar = bar.localScale;
        if (scaleBar.x < 0)
        {
            effectT.localScale = transform.localScale;
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
