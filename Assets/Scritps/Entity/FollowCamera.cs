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
        // �÷��̾� ����
        if (target == null)
        {
            if (GameManager.Instance.Player)
            {
                // �ʱ�ȭ
                // �÷��̾�� ī�޶��� ��ġ ���̱��ϱ�
                target = GameManager.Instance.Player.transform;
                targetDistance = transform.position - target.position;
            }
        }

        if (target == null)
            return;
        
        // �÷��̾� ��ġ������ ī�޶� �̵�
        transform.position = target.position + targetDistance;
    }
}
