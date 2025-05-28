using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : UIBase
{
    // 체력 업데이트 - 체력바 이미지, 체력 글자
    [SerializeField] private Slider imgHp;
    [SerializeField] private TMP_Text txtHp;

    // 점수 업데이트 - 점수 글자
    [SerializeField] private TMP_Text txtScore;

    // 메뉴 오픈 - 버튼
    [SerializeField] private Button btnOption;

    // 다른 UI 찾는 법
    // 1. 인스펙터에서 연결  [SerializeField] private GameObject uiMenu;
    // 2. UIManager 활용


    // Start is called before the first frame update
    void Start()
    {
        btnOption.onClick.AddListener(OpenMenu);
    }

    public void SetHP(int hp)
    {
        imgHp.maxValue = hp;
        imgHp.value = hp;
        txtHp.text = hp.ToString();
    }

    public void UpdateHP(int hp)
    {
        imgHp.value = hp;
        txtHp.text = hp.ToString();
    }

    public void UpdateSocre(int score)
    {
        txtScore.text = score.ToString();
    }

    public void OpenMenu()
    {
        var uiPause = UIManager.Instance.GetUI<UIPause>();
        uiPause.OpenUI();
    }
}
