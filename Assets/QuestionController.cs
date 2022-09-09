using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuestionController : MonoBehaviour
{
    // Start is called before the first frame update

    public int sceneActual= 0;
    
    #region Singlenton

    public static QuestionController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            return;
        }
        Destroy(this);
    }

    #endregion
    void Start()
    {
      
        LoadNextScene(sceneActual,true);
    }

    
    public void LoadNextScene(int actualScene,bool option)
    {
        

        switch(actualScene)
        {
            case 0 :

                if (option)
                {
                    instance.sceneActual = 3;
                    SceneManager.LoadScene(("Scene_question3"));
                }
                else
                {
                    instance.sceneActual = 2; 
                    SceneManager.LoadScene(("Scene_question2"));

                }
                break;
            case 3 : 
                if (option == true)
                {
                    instance.sceneActual = 4;
                    SceneManager.LoadScene(("Scene_question4"));
                }
                else
                {
                    instance.sceneActual = 6; 
                    SceneManager.LoadScene(("Scene_question6"));
                }

                break;
        }
    }


}
