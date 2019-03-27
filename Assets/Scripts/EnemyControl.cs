using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    float moveSpeed = 2;
    private void Update()
    {
        transform.Translate(new Vector3(1, 0, 0)*Time.deltaTime* moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "PlayerAttack")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Wall")
        {
            Debug.Log("asd");
            moveSpeed *= -1;
        }
    }
}
