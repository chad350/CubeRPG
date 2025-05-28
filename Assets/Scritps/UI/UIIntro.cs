using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIIntro : UIBase
{
    [SerializeField] private Button btnStart;
    
    // Start is called before the first frame update
    void Start()
    {
        btnStart.onClick.AddListener(GameStart);
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }
}
