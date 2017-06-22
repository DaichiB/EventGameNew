using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    static protected UIManager m_Instance;
    static public UIManager instance { get { return m_Instance; } }
    protected Dictionary<string, UIBase> m_Popups = new Dictionary<string, UIBase>();
    [SerializeField]
    protected Transform popup;

    public void ShowPopup(string popupName, Dictionary<string, object> _data, Action<object> callBackOnDone)
    {
        if (!m_Popups.ContainsKey(popupName))
        {
            GameObject obj = LoadPrefab(popupName);
            if (obj != null)
            {
                obj.transform.SetParent(popup, false);
                UIBase pop = obj.GetComponent<UIBase>();
                pop.Init(_data, callBackOnDone);
                m_Popups.Add(popupName, pop);
            }
        }
    }
    public GameObject LoadPrefab(string objName, Transform parent=null)
    {
        GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load(objName));
        if (parent != null)
            obj.transform.SetParent(parent, false);
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
