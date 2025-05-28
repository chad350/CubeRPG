using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public virtual void OpenUI()
    {
        gameObject.SetActive(true);
    }
    
    public virtual void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
