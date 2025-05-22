using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOption : MonoBehaviour
{
    // �ݴ� ��ư
    [SerializeField] private Button btnClose;

    // Start is called before the first frame update
    void Start()
    {
        btnClose.onClick.AddListener(CloseUI);
    }

    private void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
