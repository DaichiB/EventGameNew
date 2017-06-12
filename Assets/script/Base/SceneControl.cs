using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour {

    public Scenes.SceneType scene;
	public virtual void Init()
    {
        Debug.Log(scene);
    }

}
