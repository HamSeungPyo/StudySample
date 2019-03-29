using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public GameObject player;
    float speed = 3;

    private void Update()
    {
        if (player)
        {
            float targetPosX = player.transform.position.x;
            targetPosX = Mathf.Clamp(player.transform.position.x, -4, 100);//Mathf.Clamp(값,최소,최대) 값이 최소,최대값 제한
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosX, Time.deltaTime * speed), 0, -10);
            //Mathf.Lerp(값,타겟,시간)값이 타겟으로 다가가는 기능
            //값과 타겟이 거리가 멀수록 속도가 빠르고 가까울수록 속도가 느림

            //Mathf.Lerp 이 기능과 비슷한 다른 기능> Mathf.MoveTowards(값,타겟,시간)
            //값이 타겟에 일정한 속도로 이동함
        }
    }
}
