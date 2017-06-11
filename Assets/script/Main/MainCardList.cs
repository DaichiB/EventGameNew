using System.Collections;
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

        Debug.Log(CardManager.Instance.SumCards);
        for(int i = 0; i < CardManager.Instance.SumCards; i++)
        {
            MainCard card = (MainCard)GameObject.Instantiate(cardPrefab, parent).GetComponent<MainCard>();
            yield return new WaitForSeconds(time);
        }
    }

}
