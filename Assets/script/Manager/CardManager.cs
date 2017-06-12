using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CardType
{
    public string name;
    public CardKinds kind;
    public int presentNum;//プレゼントする数
    public int numberCards;//最大何枚存在するのか
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

    public List<CardType> GetCardList()
    {
        List<CardType> cardList = new List<CardType>();
        for(int i = 0; i < cardTypes.Count; i++)
        {
            CardType type = cardTypes[i];
            for (int j = 0; j < type.numberCards; j++)
                cardList.Add(type);
        }
        return cardList;
    }

}
