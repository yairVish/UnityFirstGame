using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Transform player;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if (!Enemy.danger)
        {
            float x = 0f;
            float currVel = Mathf.Abs(rigidbody2D.velocity.x);
            if (currVel < 3f)
            {
                //  x = 8f;
                count++;

                if (count <= 90)
                {
                    x = 6f;
                    rigidbody2D.AddForce(new Vector2(x, 0));
                    Vector3 scale = transform.localScale;
                    scale.x = 0.5521771f;
                    transform.localScale = scale;
                }
                else if (count <= 180)
                {
                    x = -6f;
                    rigidbody2D.AddForce(new Vector2(x, 0));
                    Vector3 scale = transform.localScale;
                    scale.x = -0.5521771f;
                    transform.localScale = scale;
                }
                else
                {
                    count = 0;
                    Vector3 player_pos = player.position;
                    Vector3 enemy_pos= transform.position;

            
                }
            }
        }*/
    }
}
