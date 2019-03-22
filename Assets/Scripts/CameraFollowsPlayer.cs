using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public GameObject player;
    float speed = 3;
    private void Start()
    {
        StartCoroutine(FollowPlayer());
    }
    IEnumerator FollowPlayer()
    {
        float targetPosX= player.transform.position.x;
        while (true)
        {
            targetPosX = Mathf.Clamp(player.transform.position.x, -4, 100);

            transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosX, Time.deltaTime * speed), 0, -10);
            yield return null;
        }
    }
}
