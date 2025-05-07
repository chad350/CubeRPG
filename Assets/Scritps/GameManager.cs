using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱��� 
    // �� ������ �����ϸ鼭 �� �ϳ��� �ʿ��ҋ�
    // ��𼭵��� ���ϰ� �����ϰ� ��

    public static GameManager Instance;

    public int Score;

    // �÷��̾� ����
    [Header("�÷��̾�")]
    [SerializeField] private GameObject PlayerPref;

    // ���� ����
    [Header("����")]
    [SerializeField] private int MonsterSpawnCount = 10;
    [SerializeField] private GameObject EnemyPref;
    [SerializeField] private float spawnAreaWidth = 40;
    [SerializeField] private float spawnAreaHeight = 40;
    [SerializeField] private float spawnAreaMargin = 2;

    private float spawnAreaHalfWidth;
    private float spawnAreaHalfHeight;

    // ������Ƽ - ��ü���� 
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
