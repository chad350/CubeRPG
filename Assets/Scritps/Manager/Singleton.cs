using UnityEngine;
public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _Instance;

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                // 인스턴스 존재 여부 확인
                _Instance = (T)FindObjectOfType(typeof(T));

                // 아직 생성되지 않았다면 인스턴스 생성
                if (_Instance == null)
                {
                    // 새로운 게임오브젝트를 만들어서 싱글톤 Attach
                    var singletonObject = new GameObject();
                    _Instance = singletonObject.AddComponent<T>();
                    singletonObject.name = $"[{typeof(T).ToString()}]";
                    
                    DontDestroyOnLoad(singletonObject);
                }
            }

            return _Instance;
        }
    }

    public static void Init()
    {
        Debug.Log($"Init : {Instance.name}");
    }

    public void Release()
    {
        Destroy(_Instance.gameObject);
        _Instance = null;
    }
}