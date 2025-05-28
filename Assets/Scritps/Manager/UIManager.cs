using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    Dictionary<string, UIBase> UIList = new Dictionary<string, UIBase>();

    public void Clear()
    {
        UIList.Clear();
    }

    /// <summary>
    /// UI�� �����մϴ�.
    /// ������ UI�� �����ߴٸ� ����� �ٽ� �����մϴ�.
    /// </summary>
    /// <typeparam name="T">������ UI Class</typeparam>
    /// <param name="parent">�θ� �ʿ��ϴٸ� �������ݴϴ�.</param>
    /// <returns></returns>
    public T CreateUI<T>(Transform parent = null) where T : UIBase
    {
        string path = GetPath<T>();

        if (IsUIExist<T>())
            RemoveUI<T>();
            
        T go = Instantiate(Resources.Load<T>(path), parent);
        T temp = go.GetComponent<T>();
        AddUI<T>(go);

        return temp;
    }


    /// <summary>
    /// UI�� �޾ƿɴϴ�. �޾ƿ� UI�� �����������ʴٸ� ���� �� ��ȯ�մϴ�.
    /// </summary>
    /// <typeparam name="T">�޾ƿ� UI Class</typeparam>
    /// <param name="parent">�θ� �ʿ��ϴٸ� �������ݴϴ�.</param>
    /// <returns></returns>
    public T GetUI<T>(Transform parent = null) where T : UIBase
    {
        if (IsUIExist<T>())
            return UIList[typeof(T).Name].GetComponent<T>();
        else
            return CreateUI<T>(parent);
    }
    
    /// <summary>
    /// UI�� ����Ʈ�� ����մϴ�.
    /// </summary>
    /// <param name="go">�߰��� UI�� Gameobject</param>
    /// <typeparam name="T">����� UI Class</typeparam>
    private void AddUI<T>(UIBase go) where T : UIBase
    {
        string className = typeof(T).Name;
        UIList.TryAdd(className, go);
    }
    
    /// <summary>
    /// UI�� ����Ʈ���� �����ϰ� �ı��մϴ�.
    /// </summary>
    /// <typeparam name="T">�����ų UI Class</typeparam>
    public void RemoveUI<T>() where T : UIBase
    {
        string className = typeof(T).Name;
        
        if (UIList[className].gameObject)
            Destroy(UIList[className]);
        
        if (UIList.ContainsKey(className))
            UIList.Remove(className);
    }


    /// <summary>
    /// UI ���� ���θ� üũ�մϴ�.
    /// </summary>
    /// <typeparam name="T">üũ�� UI Class</typeparam>
    /// <returns>UI�� �����ϴ��� ����</returns>
    public bool IsUIExist<T>() where T : UIBase
    {
        string className = typeof(T).Name;
        if (UIList.ContainsKey(className) && UIList[className] != null)
            return true;
        else
            return false;
    }
    
    
    private string GetPath<T>() where T : UIBase
    {
        string className = typeof(T).Name;
        return "UI/" + className;
    }
}
