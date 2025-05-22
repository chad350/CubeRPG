using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
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

    public void OpenOptionUI()
    { 

        UIManager.Instance.uiOption.gameObject.SetActive(true);
    }

    public void OpenGameQuitPopup()
    {
        UIManager.Instance.uiQuitPopup.gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
