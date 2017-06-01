using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : SceneControl {

	public void OnClick()
    {
        SceneManager.Instance.ChangeScene(Scenes.SceneType.main);
    }

}
