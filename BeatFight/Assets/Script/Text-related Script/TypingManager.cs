using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingManager : MonoBehaviour
{
    private string currentWord = "";
    public delegate void UpdateWord(string word); //Delegate when typed word is updated
    public static event UpdateWord OnUpdateWord;

    public delegate void SendWord(string word); //Delegate when typed word is sent
    public static event SendWord OnSendWord;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //TODO: Need to add pause, but i dont know what's the best way to do so
    {
        CheckInput();
    }

    private void CheckInput() 
    {
        if (Input.anyKeyDown) 
        {
            Debug.Log("Input detected");
            if (Input.GetKeyDown("space"))
            {
                OnSendWord?.Invoke(currentWord);
                Debug.LogWarning(currentWord);
                currentWord = "";
            }

            else 
            {
                Debug.LogWarning(Input.inputString);
                if (Input.inputString.Length > 0) 
                {
                    currentWord += Input.inputString;
                    Debug.Log(currentWord);
                    OnUpdateWord?.Invoke(currentWord);
                }
            }
        }
    }
}
