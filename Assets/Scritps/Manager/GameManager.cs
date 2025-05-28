using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int Score;

    // 플레이어 정보
    [Header("플레이어")]
    private string PlayerPrefName = "Player";

    // 몬스터 정보
    [Header("몬스터")]
    private string EnemyPrefName = "Enemy";
    private int MonsterSpawnCount = 10;
    private float spawnAreaWidth = 40;
    private float spawnAreaHeight = 40;
    private float spawnAreaMargin = 2;

    private float spawnAreaHalfWidth;
    private float spawnAreaHalfHeight;

    // 프로퍼티 - 객체지향 
    public float SpawnAreaHalfWidth => spawnAreaHalfWidth;
    public float SpawnAreaHalfHeight => spawnAreaHalfHeight;


    private GameObject player;
    public GameObject Player => player;

    private List<GameObject> Enemies = new List<GameObject>();


    private void Awake()
    {
        spawnAreaHalfWidth = (spawnAreaWidth / 2) - spawnAreaMargin;
        spawnAreaHalfHeight = (spawnAreaHeight / 2) - spawnAreaMargin;
    }

    public void SpawnPlayer()
    {
        var playerRes = Resources.Load<GameObject>(PlayerPrefName);
        player = Instantiate(playerRes);
    }

    public void SpawnMonster()
    {
        Enemies.Clear();
        var enemyRes = Resources.Load<GameObject>(EnemyPrefName);
        for (int i = 0; i < MonsterSpawnCount; i++)
        {
            //                                    -18                   18
            float spawnPosX = Random.Range(-spawnAreaHalfWidth, spawnAreaHalfWidth);
            float spawnPosZ = Random.Range(-spawnAreaHalfHeight, spawnAreaHalfHeight);

            float spawnRotY = Random.Range(0, 360);

            Vector3 spawnPos = new Vector3(spawnPosX, enemyRes.transform.position.y, spawnPosZ);
            Quaternion spawnRot = Quaternion.Euler(0, spawnRotY, 0);

            GameObject enemy = Instantiate(enemyRes, spawnPos, spawnRot);
            Enemies.Add(enemy);
        }
    }
}
