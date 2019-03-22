using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "PlayerAttack")
        {
            Destroy(gameObject);
        }
    }
}
