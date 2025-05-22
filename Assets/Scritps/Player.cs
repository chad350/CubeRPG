using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int HP = 10;

    public LayerMask checkLayer;

    public float speed = 0.2f;
    private float speedFactor = 0.5f;

    public float delay;

    private float prevShootTime;
    
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale < 1)
            return;

        MovePlayer();
        RotatePlayer();
        CheckAttack();
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal"); // -1 ~ 1
        float y = Input.GetAxis("Vertical"); // -1 ~ 1

        Vector3 dir = new Vector3(x, 0, y) * speed * speedFactor * Time.deltaTime;

        transform.Translate(dir, Space.World);
    }

    void RotatePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, checkLayer))
        {
            Vector3 mousePositionInWorld = hitInfo.point;
            mousePositionInWorld.y = transform.position.y;

            Vector3 dir = mousePositionInWorld - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = targetRotation;
        }
    }

    void CheckAttack()
    {
        prevShootTime += Time.deltaTime;

        if (prevShootTime > delay)
        {
            // »ý¼º
            Projectile p = ProjectileManager.Instance.GetProjectile();
            p.transform.position = transform.position;
            p.transform.rotation = transform.rotation;
            prevShootTime = 0;
        }
    }
}
