using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float power; // 데미지
    public float speed; // 속도
    public float duration; // 지속시간

    public int pierce; // 관통

    Player player;

    void OnEnable()
    {
        // 파괴
        Invoke(nameof(ProjectileReturn), duration);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.forward;
        Vector3 targetMove = dir * Time.deltaTime * speed;
        transform.Translate(targetMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if (enemy == null)
            return;

        float damage = power;
        enemy.TakeDamage(damage);

        pierce--;
        if (pierce <= 0)
        {
            ProjectileReturn();
        }
    }

    public void ProjectileReturn()
    {
        CancelInvoke();
        ProjectileManager.Instance.ReturnProjectile(this);
    }
}
