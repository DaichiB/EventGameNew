using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scenes{

    public enum SceneType
    {
        title,
        main
    }

    public string name;
    public SceneControl scene;
    public SceneType type; 


}
public class SceneManager : SingletonMonoBehaviour<SceneManager> {

    [SerializeField]
    public List<Scenes> sceneList;

    const string SCENE_PATH = "Scenes/";

    Scenes target;

    Scenes.SceneType currentScene;
    public void Awake()
    {
        currentScene = Scenes.SceneType.title;
        foreach(Scenes item in sceneList)
        {
            if (item.type == Scenes.SceneType.title)
            {
                item.scene.gameObject.SetActive(true);
                target = item;
            }
            else item.scene.gameObject.SetActive(false);
        }
        target.scene.Init();
        Debug.Log(currentScene);
    }
	public void ChangeScene(Scenes.SceneType scene)
    {
        foreach(Scenes item in sceneList)
        {
            if (item.type == currentScene)
                item.scene.gameObject.SetActive(false);
            else if (item.type == scene)
            {
                item.scene.gameObject.SetActive(true);
                target = item;
            }
        }
        currentScene = scene;
        target.scene.Init();
    }
}
