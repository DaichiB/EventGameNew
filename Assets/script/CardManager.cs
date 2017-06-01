using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CardType
{
    public string name;
    public int presentNum;
    public int numberCards;
    public Sprite pict;
}
public class CardManager : SingletonMonoBehaviour<CardManager> {

    [SerializeField]
    public List<CardType> cardTypes;
    public int SumCards {
        get {
            int sum = 0;
            foreach (CardType item in cardTypes)
                sum += item.numberCards;
            return sum;
                }
    }

}
