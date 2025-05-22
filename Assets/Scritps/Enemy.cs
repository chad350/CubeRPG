using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �÷��̾�� �浹�ϸ�
    // ���ʹ� ������Ʈ �ı�
    // �÷��̾� Hp �� ���ʹ��� Atk ��ŭ ����

    public float HP = 5;

    int Atk = 3;

    [SerializeField] private float moveDistanceMin = 2;
    [SerializeField] private float moveDistanceMax = 4;
    [SerializeField] private float moveDelay = 1;
    [SerializeField] private float moveSpeed = 1.5f;

    Vector3 pos;

    float spawnAreaHalfWidth; 
    float spawnAreaHalfHeight;
    
    // Start is called before the first frame update
    void Start()
    { 
        spawnAreaHalfWidth = GameManager.Instance.SpawnAreaHalfWidth;
        spawnAreaHalfHeight = GameManager.Instance.SpawnAreaHalfHeight;

        StartCoroutine(nameof(MoveEnemy));
    }

    void Update()
    {
        RotateEnemy();
    }

    IEnumerator MoveEnemy()
    {
        while (true)
        {
            float randomMoveDistance = Random.Range(moveDistanceMin, moveDistanceMax);
            Vector2 randomCircle = Random.insideUnitCircle * randomMoveDistance;
  
            pos = transform.position;
            pos.x += randomCircle.x;
            pos.z += randomCircle.y;

            //        number1, number2, number3
            //          10        0        20
            //          -5(0)     0        20
            //          35(20)    0        20
            // ���������� ũ��
            pos.x = Mathf.Clamp(pos.x, -spawnAreaHalfWidth, spawnAreaHalfWidth);
            pos.z = Mathf.Clamp(pos.z, -spawnAreaHalfHeight, spawnAreaHalfHeight);

            float duration = randomMoveDistance / moveSpeed;
            StartCoroutine(transform.Move(pos, duration));

            yield return new WaitForSeconds(duration + moveDelay);
        }
    }

    void RotateEnemy()
    {
        Vector3 dir = (pos - transform.position).normalized;
        if (dir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 70 * Time.deltaTime);
        }

    }

    public void TakeDamage(float damage)
    {
        HP -= damage;

        if (HP < 0)
        {
            GameManager.Instance.Score += 10;
            UIManager.Instance.uiMain.UpdateSocre(GameManager.Instance.Score);

            Destroy(gameObject);
        }
    }
}
