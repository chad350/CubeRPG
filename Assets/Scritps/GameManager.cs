using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 
    // 이 게임을 진행하면서 단 하나만 필요할떄
    // 어디서든지 편하게 접근하게 함

    public static GameManager Instance;

    public int Score;

    // 플레이어 정보
    [Header("플레이어")]
    [SerializeField] private GameObject PlayerPref;

    // 몬스터 정보
    [Header("몬스터")]
    [SerializeField] private int MonsterSpawnCount = 10;
    [SerializeField] private GameObject EnemyPref;
    [SerializeField] private float spawnAreaWidth = 40;
    [SerializeField] private float spawnAreaHeight = 40;
    [SerializeField] private float spawnAreaMargin = 2;

    private float spawnAreaHalfWidth;
    private float spawnAreaHalfHeight;

    // 프로퍼티 - 객체지향 
    public float SpawnAreaHalfWidth => spawnAreaHalfWidth;
    public float SpawnAreaHalfHeight => spawnAreaHalfHeight;


    private GameObject Player;
    private List<GameObject> Enemies = new List<GameObject>();


    private void Awake()
    {
        Instance = this;

        spawnAreaHalfWidth = (spawnAreaWidth / 2) - spawnAreaMargin;
        spawnAreaHalfHeight = (spawnAreaHeight / 2) - spawnAreaMargin;
    }

    private void Start()
    {        
        SpawnPlayer();
        SpawnMonster();
    }

    void SpawnPlayer()
    {
        Player = Instantiate(PlayerPref);
    }

    void SpawnMonster()
    {
        

        for (int i = 0; i < MonsterSpawnCount; i++)
        {
            //                                    -18                   18
            float spawnPosX = Random.Range(-spawnAreaHalfWidth, spawnAreaHalfWidth);
            float spawnPosZ = Random.Range(-spawnAreaHalfHeight, spawnAreaHalfHeight);

            float spawnRotY = Random.Range(0, 360);

            Vector3 spawnPos = new Vector3(spawnPosX, EnemyPref.transform.position.y, spawnPosZ);
            Quaternion spawnRot = Quaternion.Euler(0, spawnRotY, 0);

            GameObject enemy = Instantiate(EnemyPref, spawnPos, spawnRot);
            Enemies.Add(enemy);
        }
    }
}
