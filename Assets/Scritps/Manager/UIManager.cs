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
    /// UI를 생성합니다.
    /// 이전에 UI가 존재했다면 지우고 다시 생성합니다.
    /// </summary>
    /// <typeparam name="T">생성할 UI Class</typeparam>
    /// <param name="parent">부모가 필요하다면 선언해줍니다.</param>
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
    /// UI를 받아옵니다. 받아올 UI가 생성되있지않다면 생성 후 반환합니다.
    /// </summary>
    /// <typeparam name="T">받아올 UI Class</typeparam>
    /// <param name="parent">부모가 필요하다면 선언해줍니다.</param>
    /// <returns></returns>
    public T GetUI<T>(Transform parent = null) where T : UIBase
    {
        if (IsUIExist<T>())
            return UIList[typeof(T).Name].GetComponent<T>();
        else
            return CreateUI<T>(parent);
    }
    
    /// <summary>
    /// UI를 리스트에 등록합니다.
    /// </summary>
    /// <param name="go">추가할 UI의 Gameobject</param>
    /// <typeparam name="T">등록할 UI Class</typeparam>
    private void AddUI<T>(UIBase go) where T : UIBase
    {
        string className = typeof(T).Name;
        UIList.TryAdd(className, go);
    }
    
    /// <summary>
    /// UI를 리스트에서 제거하고 파괴합니다.
    /// </summary>
    /// <typeparam name="T">종료시킬 UI Class</typeparam>
    public void RemoveUI<T>() where T : UIBase
    {
        string className = typeof(T).Name;
        
        if (UIList[className].gameObject)
            Destroy(UIList[className]);
        
        if (UIList.ContainsKey(className))
            UIList.Remove(className);
    }


    /// <summary>
    /// UI 존재 여부를 체크합니다.
    /// </summary>
    /// <typeparam name="T">체크할 UI Class</typeparam>
    /// <returns>UI가 존재하는지 여부</returns>
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
