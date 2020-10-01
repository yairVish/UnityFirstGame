using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptToBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float remPlayerY, remPlayerY2;
    public Transform checkGround,player;
    public Vector3 player_pos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*player_pos = player.position;
        remPlayerY2 = player_pos.y;
        Debug.Log("(1)");
        if (Physics2D.Linecast(checkGround.position,checkGround.position, 1 << LayerMask.NameToLayer("enemy")))
        {
            Debug.Log("(2)");
            if (remPlayerY > remPlayerY2)
            {
                Debug.Log("(3)");
                //  Debug.Log("(4)");
                Vector3 scaleBar = transform.localScale;
                scaleBar.x = scaleBar.x - 0.25f;
                /*  if (scaleBar.x <= 0)
                  {
                      Destroy(gameObject);
                  }
                transform.localScale = scaleBar;
            }
        }
        remPlayerY = player_pos.y;*/
    }
}
