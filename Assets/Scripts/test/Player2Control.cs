using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour
{
    public Vector3 setMovePos;
    public Vector3 SetMovePos
    {
        set
        {
            setMovePos = value;
        }
    }
    readonly float speed = 5;
    SpriteRenderer enemyRender;
    Animator enemyAnim;
    bool bTreadOnGround = true;
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRender = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        int animNum = 1;
        if (setMovePos.x > transform.position.x)
        {
            enemyRender.flipX = true;
        }
        else if (setMovePos.x < transform.position.x)
        {
            enemyRender.flipX = false;
        }
        else
        {
            animNum = 0;
        }
        RaycastHit2D hit;
        if ((hit = Physics2D.Raycast(transform.position, -transform.up, 0.1f)))
        {
            if (hit.transform.tag == "Ground")
            {
                bTreadOnGround = true;
            }
            else
            {
                animNum = 2;
            }
        }
        else
        {
            animNum = 2;
        }
        enemyAnim.SetInteger("Behavior", animNum);
        transform.position = Vector3.MoveTowards(transform.position, setMovePos, Time.deltaTime * speed);
    }
}
