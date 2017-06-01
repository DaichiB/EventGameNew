using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCardList : MonoBehaviour {

    [SerializeField]
    MainCard cardPrefab;
    [SerializeField]
    Transform parent;

    public void SetCards()
    {

        Debug.Log(CardManager.Instance.SumCards);
        for(int i = 0; i < CardManager.Instance.SumCards; i++)
        {
            MainCard card = (MainCard)GameObject.Instantiate(cardPrefab, parent).GetComponent<MainCard>();
        }
    }

}
