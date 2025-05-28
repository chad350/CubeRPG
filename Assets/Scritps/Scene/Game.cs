using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.Clear();
        UIManager.Instance.GetUI<UIMain>();
        
        ProjectileManager.Instance.SetProjecctile();
        
        GameManager.Instance.SpawnPlayer();
        GameManager.Instance.SpawnMonster();
    }
}
