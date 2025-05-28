using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : UIBase
{
    // 옵션창 열기
    [SerializeField] private Button btnOption;
    // 게임 종료 팝업 열기
    [SerializeField] private Button btnGameQuit;
    // 메뉴창 닫기
    [SerializeField] private Button btnResume;

    // Start is called before the first frame update
    void Start()
    {
        btnOption.onClick.AddListener(OpenOptionUI);
        btnGameQuit.onClick.AddListener(OpenGameQuitPopup);
        btnResume.onClick.AddListener(CloseUI);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void OpenOptionUI()
    {
        var uiOption = UIManager.Instance.GetUI<UIOption>();
        uiOption.OpenUI();
        
    }

    public void OpenGameQuitPopup()
    {
        var uiQuitPopup = UIManager.Instance.GetUI<UIQuitPopup>();
        uiQuitPopup.OpenUI();
    }
}
