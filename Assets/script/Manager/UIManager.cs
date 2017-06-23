using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    static private UIManager m_Instance;
    static public UIManager instance { get { return m_Instance; } }
    private Dictionary<string, UIBase> m_Popups = new Dictionary<string, UIBase>();
    [SerializeField]
    private Transform popup;

    private const string POPUP_PATH = "Popup/";
    private const string MANAGER_PATH = "Manager/UIManager"; 

    static public void Create()
    {
        GameObject obj = LoadPrefab(MANAGER_PATH);
        m_Instance = obj.GetComponent<UIManager>();

        DontDestroyOnLoad(obj);
    }

    public void ShowPopup(string popupName, Dictionary<string, object> _data=null, Action<object> callBackOnDone=null)
    {
        if (!m_Popups.ContainsKey(popupName))
        {
            GameObject obj = LoadPrefab(POPUP_PATH+popupName);
            if (obj != null)
            {
                obj.transform.SetParent(popup, false);
                UIBase pop = obj.GetComponent<UIBase>();
                pop.Init(_data, callBackOnDone);
                m_Popups.Add(popupName, pop);
            }
        }
    }
    static public GameObject LoadPrefab(string objName)
    {
        GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load(objName));
        /*if (parent != null)
            obj.transform.SetParent(parent, false);*/
        return obj;
    }

    public bool RemoveListPopups(string popupName)
    {
        if (!m_Popups.ContainsKey(popupName))
            return false;
        m_Popups.Remove(popupName);

        return true;
    }
}
