﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void QuitGame()
    {
       Application.Quit();
       Debug.Log("Quit!"); 
    }

}
