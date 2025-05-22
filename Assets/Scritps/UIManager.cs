using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public UIMain uiMain;
    public UIPause uiPause;
    public UIOption uiOption;
    public UIQuitPopup uiQuitPopup;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
}
