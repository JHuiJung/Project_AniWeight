using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneName = "Title";
    
    public void MoveScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void MoveScene(string _name)
    {
        SceneManager.LoadScene(_name);
    }
}
