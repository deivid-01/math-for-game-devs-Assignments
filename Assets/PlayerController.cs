using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

     static public Player player;

     private void Awake()
     {
        string data =  PlayerPrefs.GetString("player");
        player  = JsonUtility.FromJson<Player>(data);
        
       
        
        print("Datos cargados");
     }

     void Start()
    {
      //  player = new Player("Juan");
       // player.piezas[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level2");
        }
    }

    private void OnDestroy()
    {
       
        string data =  JsonUtility.ToJson(player);
       
       
       
       PlayerPrefs.SetString("player",data);
       
       print("Datos guardados");
    }
}
