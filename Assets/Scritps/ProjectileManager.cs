using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager Instance;

    public Projectile projectile;
    public List<Projectile> projectileList;

    public int initCount;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initCount; i++)
        {
            Projectile p = Instantiate(projectile, transform);
            projectileList.Add(p);

            p.gameObject.SetActive(false);
        }
    }

    public Projectile GetProjectile()
    {
        // projectileList üũ
        if (projectileList.Count > 0)
        {
            //  5
            //  0   1   2   3   4   5
            // [1] [2] [3] [4] [5]

            // ������ projectileList �ϳ� ������ ���
            int index = projectileList.Count - 1;
            Projectile p = projectileList[index];
            projectileList.RemoveAt(index);

            p.gameObject.SetActive(true);
            p.transform.SetParent(null);
            return p;
        }

        return Instantiate(projectile);
    }

    public void ReturnProjectile(Projectile p)
    {
        // projectileList ����
        projectileList.Add(p);
        p.transform.SetParent(transform);
        p.gameObject.SetActive(false);
    }
}
