using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTN_Escape : MonoBehaviour
{

    [Space(10)]
    public bool isCloseObj = false;
    public GameObject targetCloseObj;

    [Space(10)]
    public bool isOpenObj = false;
    public GameObject targetOpenObj;

    [Space(10)]
    public bool isLoadScene = false;
    public string sceneName = "Title";

    [Space]
    public bool isToggleObj = false;
    public GameObject targetToggleObj;

    private void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(isOpenObj)
                {
                    targetOpenObj.SetActive(true);
                }

                if(isCloseObj)
                {
                    targetCloseObj.SetActive(false);
                }

                if(isLoadScene)
                {
                    SceneManager.LoadScene(sceneName);
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isOpenObj)
            {
                targetOpenObj.SetActive(true);
            }

            if (isCloseObj)
            {
                targetCloseObj.SetActive(false);
            }

            if (isLoadScene)
            {
                SceneManager.LoadScene(sceneName);
            }

            if(isToggleObj)
            {
                targetToggleObj.SetActive(!targetToggleObj.activeSelf);
            }

        }



    }
}
