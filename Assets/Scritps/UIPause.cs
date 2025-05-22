using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
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
