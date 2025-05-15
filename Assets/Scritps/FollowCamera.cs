using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Transform target; // null
    Vector3 targetDistance;

    // Update is called once per frame
    void LateUpdate()
    {
        // 플레이어 접근
        if (target == null)
        {
            if (GameManager.Instance.Player)
            {
                // 초기화
                // 플레이어와 카메라의 위치 차이구하기
                target = GameManager.Instance.Player.transform;
                targetDistance = transform.position - target.position;
            }
        }

        if (target == null)
            return;
        
        // 플레이어 위치에따라 카메라 이동
        transform.position = target.position + targetDistance;
    }
}
