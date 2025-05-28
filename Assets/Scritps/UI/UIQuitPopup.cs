using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIQuitPopup : UIBase
{
    [SerializeField] private Button btnOK;
    [SerializeField] private Button btnClose;

    // Start is called before the first frame update
    void Start()
    {
        btnOK.onClick.AddListener(Confirm);
        btnClose.onClick.AddListener(CloseUI);
    }

    private void Confirm()
    {
        SceneManager.LoadScene("Intro");
    }
}
