﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCardList : MonoBehaviour {

    [SerializeField]
    MainCard cardPrefab;
    [SerializeField]
    Transform parent;

    public float time = 2f;

    public IEnumerator SetCards()
    {

        List<CardType> list = CardManager.Instance.GetCardList();
        Debug.Log(CardManager.Instance.SumCards);
        for(int i = 0; i < list.Count; i++)
        {
            MainCard card = (MainCard)GameObject.Instantiate(cardPrefab, parent).GetComponent<MainCard>();
            card.SetData(list[i]);
            yield return new WaitForSeconds(time);
        }
    }

}
