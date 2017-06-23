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

    CardKinds kind;
    int presentNum;
    public bool IsOpen { get { return isOpen; } }
    bool isOpen = false;

    public Image thisCard;
    Sprite spriteHeads;

    public void SetData(CardType type)
    {
        kind = type.kind;
        presentNum = type.presentNum;
        spriteHeads = type.pict;
        isOpen = false;
    }

    public void OnSelect()
    {
        if (!isOpen)
        {
            thisCard.sprite = spriteHeads;
            isOpen = true;
        }

        UIManager.instance.ShowPopup("PopupCardSelect");
    }

}
