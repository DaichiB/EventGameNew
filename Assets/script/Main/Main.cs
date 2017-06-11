using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : SceneControl {

    [SerializeField]
    MainCardList cardList;
    public override void Init()
    {
        base.Init();
        StartCoroutine(cardList.SetCards());
    }

}
