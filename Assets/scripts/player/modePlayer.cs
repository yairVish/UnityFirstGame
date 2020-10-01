using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class modePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public float maxVel = 5f;
    public float speedPlayer = 10f;
    public bool isGround;
    public Transform checkGround;
    public int MAXJUMP = 400;
    public LayerMask layerMask;
    public Transform firePoint;
    public float targetTime = 60.0f;
    public float legTime = 60.0f;
    public float legTime2 = 60.0f;
    public GameObject bullet;
    public Transform leg1, leg2;
    public float iLeg1 = -50f;
    public float iLeg2 = -50f;
    public Transform[] handRight;//size :2
    public Transform[] handLeft;//size :2
    public Transform leftH,rightH,pointRightH;
    public bool bLeg1 = true;
    public bool bLeg2 = true;
    public bool hwoLeg = true;
    public bool start = true;
    public Transform gun,fullBF;
    public float m = 0f;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        float inputX = Input.GetAxis("Horizontal");
        float x = 0f;
        float currVel = Mathf.Abs(rigidbody2D.velocity.x);
        isGround = Physics2D.OverlapCircle(checkGround.position, 0.5f, layerMask);
        if (Input.GetButtonDown("Fire1"))
        {
            targetTime = 60f;
           // animator.SetBool("shootToIdle", false);
        }
        else
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 59.5f)
            {
             //   animator.SetBool("shootToIdle", true);
            }
        }
        theMode2();
        inputMouse();
        }
    public void inputMouse()
    {
        var mouse_position = Input.mousePosition-UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(mouse_position.y, mouse_position.x) * Mathf.Rad2Deg;
        for (int i = 1; i < 2; i++)
        {
          //  handLeft[i].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
          //  handRight[i].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //Debug.Log("angle: " + angle);
        rightH.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       // handRight[1].position=pointRightH.position;
        if (angle >-40)
        {
            leftH.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
             // handLeft[1].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
             // handRight[1].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        fullBF.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        if (mouse_position.x > 0)
        {
            Vector3 scale = transform.localScale;
            if (transform.localScale.x > 0) { scale.x = transform.localScale.x; } else { scale.x = -transform.localScale.x; }
            transform.localScale = scale;
            Vector3 scale2 = fullBF.localScale;
            if (fullBF.localScale.x > 0) {scale2.x = fullBF.localScale.x; } else { scale2.x = -fullBF.localScale.x; }
            if (fullBF.localScale.y > 0) { scale2.y = fullBF.localScale.y; } else { scale2.y = -fullBF.localScale.y; }
            fullBF.localScale = scale2;
       //     Vector3 scale2 = gun.localScale;
            /*    Vector3 scale3 = rightH.localScale;
                scale3.x = 0.5247958f;
                scale3.y = 0.5245971f;
                rightH.localScale = scale3;*/
        }
        if (mouse_position.x < 0)
        {
            Vector3 scale = transform.localScale;
            if (transform.localScale.x < 0) { scale.x = transform.localScale.x; } else { scale.x = -transform.localScale.x; }
            transform.localScale = scale;
            Vector3 scale2 = fullBF.localScale;
            if (fullBF.localScale.x < 0) { scale2.x = fullBF.localScale.x; } else { scale2.x = -fullBF.localScale.x; }
            if (fullBF.localScale.y < 0) { scale2.y = fullBF.localScale.y; } else { scale2.y = -fullBF.localScale.y; }
            fullBF.localScale = scale2;
        }
    }
    /* if (mouse_position.x > 0)
        {
            Vector3 scale = transform.localScale;
            if (transform.localScale.x > 0) { scale.x = transform.localScale.x; } else { scale.x = -transform.localScale.x; }
            transform.localScale = scale;
            Vector3 scale2 = gun.localScale;
            if (gun.localScale.x > 0) { scale2.x = gun.localScale.x; } else { scale2.x = -gun.localScale.x; }
            if (gun.localScale.y > 0) { scale2.y = gun.localScale.y; } else { scale2.y = -gun.localScale.y; }
            gun.localScale = scale2;
            for (int i = 0; i < 2; i++)
            {
                Vector3 scale3 = handRight[i].localScale;
                if (handRight[i].localScale.x > 0) { scale3.x = handRight[i].localScale.x; } else { scale3.x = -handRight[i].localScale.x; }
                if (handRight[i].localScale.y > 0) { scale3.y = handRight[i].localScale.y; } else { scale3.y = -handRight[i].localScale.y; }
                handRight[i].localScale = scale3;
                Vector3 scale4 = handLeft[i].localScale;
                if (handLeft[i].localScale.x > 0) { scale4.x = handLeft[i].localScale.x; }
                else
                {
                    scale4.x = -handLeft[i].localScale.x;
                    if (handLeft[i].localScale.y > 0) { scale4.y = handLeft[i].localScale.y; } else { scale4.y = -handLeft[i].localScale.y; }
                    handLeft[i].localScale = scale4;
                }
            }
            if (mouse_position.x < 0)
            {
                Vector3 scale_ = transform.localScale;
                if (transform.localScale.x < 0) { scale_.x = transform.localScale.x; } else { scale_.x = -transform.localScale.x; }
                transform.localScale = scale_;
                Vector3 scale2_ = gun.localScale;
                if (gun.localScale.x < 0) { scale2_.x = gun.localScale.x; } else { scale2_.x = -gun.localScale.x; }
                if (gun.localScale.y < 0) { scale2_.y = gun.localScale.y; } else { scale2_.y = -gun.localScale.y; }
                gun.localScale = scale2_;
                for (int i = 0; i < 2; i++)
                {
                    Vector3 scale3 = handRight[i].localScale;
                    if (handRight[i].localScale.x < 0) { scale3.x = handRight[i].localScale.x; } else { scale3.x = -handRight[i].localScale.x; }
                    if (handRight[i].localScale.y < 0) { scale3.y = handRight[i].localScale.y; } else { scale3.y = -handRight[i].localScale.y; }
                    handRight[i].localScale = scale3;
                    Vector3 scale4 = handLeft[i].localScale;
                    if (handLeft[i].localScale.x < 0) { scale4.x = handLeft[i].localScale.x; } else { scale4.x = -handLeft[i].localScale.x; }
                    if (handLeft[i].localScale.y < 0) { scale4.y = handLeft[i].localScale.y; } else { scale4.y = -handLeft[i].localScale.y; }
                    handLeft[i].localScale = scale4;
                }
            }*/
    public void theMode()
    {
        Vector3 scale = transform.localScale;
        float inputX = Input.GetAxis("Horizontal");
        float x = 0f;
        float currVel = Mathf.Abs(rigidbody2D.velocity.x);
        if (isGround)
        {
            if (inputX != 0)
            {
                if (start)
                {
                    iLeg1 = 0f;
                    iLeg2 = 0f;
                    bLeg1 = true;
                    bLeg2 = true;
                    start = false;
                    hwoLeg = false;
                }
                if (scale.x > 0)
                {
                    if (hwoLeg)
                    {
                        if (bLeg1)
                        {
                            iLeg1 -= 10;
                        }
                        else
                        {
                            iLeg1 += 10;
                        }
                        if (iLeg1 >= 0)
                        {
                            hwoLeg = false;
                            bLeg1 = true;
                        }
                        if (iLeg1 <= -30)
                        {
                            hwoLeg = false;
                            bLeg1 = false;
                        }
                    }
                    if (!hwoLeg)
                    {
                        if (bLeg2)
                        {
                            iLeg2 += 10;
                        }
                        else
                        {
                            iLeg2 -= 10;
                        }
                        if (iLeg2 >= 0f)
                        {
                            hwoLeg = true;
                            bLeg2 = false;
                        }
                        if (iLeg2 <= -30f)
                        {
                            hwoLeg = true;
                            bLeg2 = true;
                        }
                    }
                }
                else
                {
                    if (hwoLeg)
                    {
                        if (bLeg1)
                        {
                            iLeg1 -= 10;
                        }
                        else
                        {
                            iLeg1 += 10;
                        }
                        if (iLeg1 >= 30)
                        {
                            hwoLeg = false;
                            bLeg1 = true;
                        }
                        if (iLeg1 <= 0)
                        {
                            hwoLeg = false;
                            bLeg1 = false;
                        }
                    }
                    if (!hwoLeg)
                    {
                        if (bLeg2)
                        {
                            iLeg2 += 10;
                        }
                        else
                        {
                            iLeg2 -= 10;
                        }
                        if (iLeg2 >= 30f)
                        {
                            hwoLeg = true;
                            bLeg2 = false;
                        }
                        if (iLeg2 <= 0f)
                        {
                            hwoLeg = true;
                            bLeg2 = true;
                        }
                    }
                }
                leg1.rotation = Quaternion.Euler(0f, 0f, iLeg1);
                leg2.rotation = Quaternion.Euler(0f, 0f, iLeg2);
                //         animator.SetBool("jumpToWalk", true);
                //       animator.SetBool("walk", true);

            }
            else
            {
                start = true;
                leg1.rotation = Quaternion.Euler(0f, 0f, 0f);
                leg2.rotation = Quaternion.Euler(0f, 0f, 0f);
                // animator.SetBool("jumping", false);
                // animator.SetBool("walk", false);
            }
        }
        else
        {
            if (inputX != 0)
            {
                if (scale.x > 0)
                {
                    leg1.rotation = Quaternion.Euler(0f, 0f, 20f);
                    leg2.rotation = Quaternion.Euler(0f, 0f, -20f);
                }
                else
                {
                    leg1.rotation = Quaternion.Euler(0f, 0f, -20f);
                    leg2.rotation = Quaternion.Euler(0f, 0f, 20f);
                }
                // animator.SetBool("jumpToWalk", false);
                //animator.SetBool("jumping", true);
                //animator.SetBool("walk", false);
            }
            else
            {
                if (scale.x > 0)
                {
                    leg1.rotation = Quaternion.Euler(0f, 0f, 20f);
                    leg2.rotation = Quaternion.Euler(0f, 0f, -20f);
                }
                else
                {
                    leg1.rotation = Quaternion.Euler(0f, 0f, -20f);
                    leg2.rotation = Quaternion.Euler(0f, 0f, 20f);
                }
                //  animator.SetBool("jumpToWalk", false);
                //  animator.SetBool("jumping", true);
                // animator.SetBool("walk", false);
            }
        }
    }
    public void theMode2()
    {
        Vector3 scale = transform.localScale;
        float inputX = Input.GetAxis("Horizontal");
        float x = 0f;
        float num = 0.016f;
        float currVel = Mathf.Abs(rigidbody2D.velocity.x);
        Vector3 leg1_pos = leg1.localPosition;
        Vector3 leg2_pos = leg2.localPosition;

        if (isGround)
        {
            if (inputX != 0)
            {
                if (start)
                {
                    iLeg1 = 0f;
                    iLeg2 = 0f;
                    bLeg1 = true;
                    bLeg2 = false;
                    start = false;
                    hwoLeg = true;
                }
                // if (scale.x > 0){}

                if (leg1_pos.y < -0.225f&&bLeg1)
                {
                    leg1_pos.y += num;
                    leg1.localPosition = leg1_pos;
                }
                else
                {
                    bLeg1 = false;
                    if (leg1_pos.x < 0.09f&&hwoLeg)
                    {
                        leg1_pos.x += num;
                        leg1.localPosition = leg1_pos;
                    }
                    else
                    {
                        leg1_pos.y = -0.262f;
                        leg1.localPosition = leg1_pos;
                   //     bLeg1 = true;
                    }

                        if (leg1_pos.y > -0.262f &&!bLeg1)
                        {
                            leg1_pos.y -= num;
                            leg1.localPosition = leg1_pos;
                        //bLeg2 = true;
                    }
                    else
                    {
                        bLeg2 = true;
                    }
                }
                if (bLeg2)
                {
                    if (leg2_pos.y < -0.225f&&hwoLeg)
                    {
                        leg2_pos.y += num;
                        leg2.localPosition = leg2_pos;
                    }
                    else
                    {
                        hwoLeg = false;
                        if (leg1_pos.x > 0.068f)
                        {
                            leg1_pos.x = leg1_pos.x-num;
                            leg1.localPosition = leg1_pos;
                        }
                         if (leg2_pos.y > -0.262f)
                        {
                            leg2_pos.y -= num;
                            leg2.localPosition = leg2_pos;
                        }
                        else if (leg1_pos.x >= 0.068f)
                        {
                            hwoLeg = true;
                            bLeg2 = false;
                            bLeg1 = true;
                        }
                    }
                }
                leg1.rotation = Quaternion.Euler(0f, 0f, iLeg1);
                leg2.rotation = Quaternion.Euler(0f, 0f, iLeg2);
                //         animator.SetBool("jumpToWalk", true);
                //       animator.SetBool("walk", true);

            }
            else
            {
                start = true;
                leg1_pos.y = -0.262f;
                leg1_pos.x = 0.068f;
                leg2_pos.y = -0.262f;
                leg1.localPosition = leg1_pos;
                leg2.localPosition = leg2_pos;
                leg1.rotation = Quaternion.Euler(0f, 0f, 0f);
                leg2.rotation = Quaternion.Euler(0f, 0f, 0f);
                // animator.SetBool("jumping", false);
                // animator.SetBool("walk", false);
            }
        }
        else
        {
            if (inputX != 0)
            {
                if (scale.x > 0)
                {
                    leg1_pos.y = -0.262f;
                    leg1_pos.x = 0.068f;
                    leg2_pos.y = -0.262f;
                    leg1.localPosition = leg1_pos;
                    leg2.localPosition = leg2_pos;
                    leg1.rotation = Quaternion.Euler(0f, 0f, 20f);
                    leg2.rotation = Quaternion.Euler(0f, 0f, -20f);
                }
                else
                {
                    leg1_pos.y = -0.262f;
                    leg1_pos.x = 0.068f;
                    leg2_pos.y = -0.262f;
                    leg1.localPosition = leg1_pos;
                    leg2.localPosition = leg2_pos;
                    leg1.rotation = Quaternion.Euler(0f, 0f, -20f);
                    leg2.rotation = Quaternion.Euler(0f, 0f, 20f);
                }
                // animator.SetBool("jumpToWalk", false);
                //animator.SetBool("jumping", true);
                //animator.SetBool("walk", false);
            }
            else
            {
                if (scale.x > 0)
                {
                    leg1_pos.y = -0.262f;
                    leg1_pos.x = 0.068f;
                    leg2_pos.y = -0.262f;
                    leg1.localPosition = leg1_pos;
                    leg2.localPosition = leg2_pos;
                    leg1.rotation = Quaternion.Euler(0f, 0f, 20f);
                    leg2.rotation = Quaternion.Euler(0f, 0f, -20f);
                }
                else
                {
                    leg1_pos.y = -0.262f;
                    leg1_pos.x = 0.068f;
                    leg2_pos.y = -0.262f;
                    leg1.localPosition = leg1_pos;
                    leg2.localPosition = leg2_pos;
                    leg1.rotation = Quaternion.Euler(0f, 0f, -20f);
                    leg2.rotation = Quaternion.Euler(0f, 0f, 20f);
                }
                //  animator.SetBool("jumpToWalk", false);
                //  animator.SetBool("jumping", true);
                // animator.SetBool("walk", false);
            }
        }
    }
}
