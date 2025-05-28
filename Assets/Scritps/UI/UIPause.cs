using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : UIBase
{
    // �ɼ�â ����
    [SerializeField] private Button btnOption;
    // ���� ���� �˾� ����
    [SerializeField] private Button btnGameQuit;
    // �޴�â �ݱ�
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
