using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject followMe;
    private Vector3 newPosition;
    private float space = 6f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(followMe.transform.position.x,transform.position.y,transform.position.z);
        if (followMe.transform.localScale.x > 0f)
        {
            newPosition = new Vector3(followMe.transform.position.x+space, transform.position.y, transform.position.z);
        }
        else if(followMe.transform.localScale.x < 0f)
        {
            newPosition = new Vector3(followMe.transform.position.x - space, transform.position.y, transform.position.z);
        }
     //   transform.position = Vector3.Lerp(transform.position, newPosition, 3f*Time.deltaTime);
    }
}
