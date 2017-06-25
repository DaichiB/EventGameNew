using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupCardSelect : UIBase {

    [SerializeField]
    GameObject cardImage;
    [SerializeField]
    Text rarityText;
    [SerializeField]
    Text contentText;
    [SerializeField]
    Text contentNum;
    [SerializeField]
    List<Button> buttons;
    public override void Init(Dictionary<string, object> _data = null, Action<object> callBackOnDone = null)
    {
        base.Init(_data, callBackOnDone);
        rarityText.gameObject.SetActive(false);
        contentText.gameObject.SetActive(false);
        if (!m_Data.ContainsKey("name") || !m_Data.ContainsKey("presentNum"))
            Debug.LogError("No Card Data");
        else
        {
            rarityText.text = m_Data["name"] as string;
            //Text contentNum = contentText.transform.Find("numText").GetComponent<Text>();
            contentNum.text = m_Data["presentNum"] as string;
            Debug.Log("presentNum " + m_Data["presentNum"]);
        }
    }

    public void OnSelect()
    {
        OnSelectAnimetion();
    }

    public void OnSelectAnimetion()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", -180.0f,
            "to", 0,
            "time",2.0f,
            "easeType", iTween.EaseType.linear,
            "onupdate", "OnRotateCardAni",
            "oncomplete", "OnDoneAni"
            ));
    }

    public void OnRotateCardAni(float rot)
    {
        Vector3 newRot = new Vector3(cardImage.transform.eulerAngles.x, rot, cardImage.transform.eulerAngles.z);
        cardImage.transform.eulerAngles = newRot;
        if (rot >= -90)
        {
            rarityText.gameObject.SetActive(true);
            contentText.gameObject.SetActive(true);
        }
    }

    public void OnDoneAni()
    {
        for (int i = 0; i < 2; i++)
            buttons[i].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(true);
    }

    public void OnTitle()
    {
        SceneManager.Instance.ChangeScene(Scenes.SceneType.title);
        Hide();
    }
}
