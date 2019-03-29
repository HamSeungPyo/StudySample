using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    float moveSpeed = 2;
    private void Update()
    {
        transform.Translate(new Vector3(1, 0, 0)*Time.deltaTime* moveSpeed);//transform.Translate(값) 매 프레임마다 값에 넣은 만큼 이동
    }
    private void OnTriggerEnter2D(Collider2D col)//충돌을 읽어 오는 기능 오브젝트와 충돌시 호출
    {
        if (col.transform.tag == "PlayerAttack")//충돌의 테그를 비교하는 기능
        {
            Destroy(gameObject);//Destroy(오브젝트) 이 기능을 사용기 오브젝트에 넣은 물체가 삭제됨
        }
    }
    private void OnCollisionEnter2D(Collision2D col)//충돌을 읽어 오는 기능 오브젝트와 충돌시 호출
    {
        Debug.Log("asd");//디버그
        if (col.transform.tag == "Wall")//충돌의 테그를 비교하는 기능
        {
            moveSpeed *= -1;// 물체의 방향을 바꾸기 위한 코드
        }
    }
}
