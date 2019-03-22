using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    readonly float speed = 5;
    public GameObject attack;
    SpriteRenderer render;
    Rigidbody2D rigid;
    Animator anim;
    bool bTreadOnGround = true;
    float move = 0;
    bool bAttackMode =false;
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& bAttackMode)
        {
            anim.SetTrigger("Attack");
        }
        int animNum = 1;
        move = Input.GetAxis("Horizontal");
        if (move > 0)
        {
            attack.transform.localPosition = new Vector3(1.2f, attack.transform.localPosition.y, 0);
            render.flipX = true;
        }
        else if (move < 0)
        {
            attack.transform.localPosition = new Vector3(-1.2f, attack.transform.localPosition.y, 0);
            render.flipX = false;
        }
        else
        {
            animNum = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&& bTreadOnGround)
        {
            animNum = 2;
            rigid.velocity += new Vector2(0, 15);
            bTreadOnGround = false;
        }
        else
        {
            RaycastHit2D hit;
            if ((hit = Physics2D.Raycast(transform.position, -transform.up, 0.1f)) && rigid.velocity.y == 0)
            {
                if (hit.transform.tag == "Ground")
                {
                    bTreadOnGround = true;
                }
                else
                {
                    animNum = 2;
                }
                //Debug.Log(hit.collider.tag);
                //Debug.DrawRay(transform.position, -transform.up*0.1f, Color.red, 1);
            }
            else
            {
                animNum = 2;
            }
        }
        anim.SetInteger("Behavior", animNum);
        transform.Translate(new Vector3(move, 0, 0) * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Item")
        {
            bAttackMode = true;
            Destroy(col.gameObject);
            anim.SetBool("bAttackMode", bAttackMode);
            anim.SetTrigger("ModeChange");
        }
    }
}
