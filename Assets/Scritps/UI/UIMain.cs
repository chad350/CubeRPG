using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : UIBase
{
    // ü�� ������Ʈ - ü�¹� �̹���, ü�� ����
    [SerializeField] private Slider imgHp;
    [SerializeField] private TMP_Text txtHp;

    // ���� ������Ʈ - ���� ����
    [SerializeField] private TMP_Text txtScore;

    // �޴� ���� - ��ư
    [SerializeField] private Button btnOption;

    // �ٸ� UI ã�� ��
    // 1. �ν����Ϳ��� ����  [SerializeField] private GameObject uiMenu;
    // 2. UIManager Ȱ��


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
