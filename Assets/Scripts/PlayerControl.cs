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
        anim = GetComponent<Animator>();//현재 이 스크립트를 가지고 있는 오브젝트의 Animator를 가져오는 기능
        rigid = GetComponent<Rigidbody2D>();//현재 이 스크립트를 가지고 있는 오브젝트의 Rigidbody2D를 가져오는 기능
        render = GetComponent<SpriteRenderer>();//현재 이 스크립트를 가지고 있는 오브젝트의 SpriteRenderer를 가져오는 기능
    }
    private void Update()
    {
        //점프
        if (Input.GetKeyDown(KeyCode.Space)&& bAttackMode)
        {
            anim.SetTrigger("Attack");//애니메이터의 트리거를 실행하는 기능
        }
        int animNum = 1;//애니넘버

        //이동
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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
