using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour {

    protected Dictionary<string, object> m_Data;
    protected Action<object> m_CallBackOnDone;
    protected string m_UIName;

	public virtual void Init(Dictionary<string, object> _data=null, Action<object> callBackOnDone=null)
    {
        m_Data = _data;
        m_CallBackOnDone = callBackOnDone;
        m_UIName = this.gameObject.name.Replace("(Clone)", "");
    }

    public virtual void Hide()
    {
        OnHide();
    }
    void OnHide()
    {
        if (!UIManager.instance.RemoveListPopups(m_UIName))
        {
            Debug.LogError("Can't Hide "+ m_UIName);
            return;
        }
        if (m_CallBackOnDone != null)
            m_CallBackOnDone(m_Data);
        if (this.gameObject != null)
            Destroy(this.gameObject);
    }
}
