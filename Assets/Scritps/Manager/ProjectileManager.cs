using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : Singleton<ProjectileManager>
{
    private int initCount = 5;
    private string projectilePrefName = "Projectile_1";
    private List<Projectile> projectileList = new List<Projectile>();
    
    private Transform projectilePool;
    
    // Start is called before the first frame update
    public void SetProjecctile()
    {
        var pool = new GameObject("projectilePool");
        projectilePool = pool.transform;
        
        projectileList.Clear();
        for (int i = 0; i < initCount; i++)
        {
            Projectile pRes = Resources.Load<Projectile>(projectilePrefName);
            Projectile pObj = Instantiate(pRes, projectilePool);
            projectileList.Add(pObj);

            pObj.gameObject.SetActive(false);
        }
    }

    public Projectile GetProjectile()
    {
        // projectileList 체크
        if (projectileList.Count > 0)
        {
            //  5
            //  0   1   2   3   4   5
            // [1] [2] [3] [4] [5]

            // 있으면 projectileList 하나 꺼내서 사용
            int index = projectileList.Count - 1;
            Projectile p = projectileList[index];
            projectileList.RemoveAt(index);

            p.gameObject.SetActive(true);
            p.transform.SetParent(null);
            return p;
        }

        Projectile pRes = Resources.Load<Projectile>(projectilePrefName);
        return Instantiate(pRes);
    }

    public void ReturnProjectile(Projectile p)
    {
        // projectileList 저장
        projectileList.Add(p);
        p.transform.SetParent(projectilePool);
        p.gameObject.SetActive(false);
    }
}
