using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardKinds
{
    card1st,
    card2nd,
    card3rd,
    card4th,
    card5th
};

public class MainCard : MonoBehaviour
{
    string name;
    CardKinds kind;
    int presentNum;
    public bool IsOpen { get { return isOpen; } }
    bool isOpen = false;

    public Image thisCard;
    Sprite spriteHeads;

    public void SetData(CardType type)
    {
        name = type.name;
        kind = type.kind;
        presentNum = type.presentNum;
        spriteHeads = type.pict;
        isOpen = false;
    }

    public void OnSelect()
    {
        if (!isOpen)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("name", name);
            dict.Add("kind", kind);
            dict.Add("presentNum", presentNum);
            dict.Add("ans", false);
            UIManager.instance.ShowPopup("PopupCardSelect", dict, (data)=> {
                if(((Dictionary<string, object>)data).ContainsKey("ans"))
                {
                    if (!((bool)((Dictionary<string, object>)data)["ans"]))
                        isOpen = false;
                    
                }
            });
            isOpen = true;
        }
    }

}
