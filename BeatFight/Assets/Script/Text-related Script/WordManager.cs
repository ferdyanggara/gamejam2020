using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    private WordManager() { }
    public static WordManager Instance;
    string[] wordData;

    private void Awake()
    {
        Instance = this;
        wordData = TextAssetTool.ReadTextAssetData("Word/english.txt");
        if (wordData.Length > 0) { Debug.LogWarning("wordData has been initialized with " + wordData.Length + "words!"); }
    }

    public string GetRandomWord() 
    {
        return wordData[Random.Range(0, wordData.Length - 1)];
    }

    public string GetDifferentWord(string previousWord) 
    {
        string newWord = GetRandomWord();
        while (previousWord == newWord) 
        {
            newWord = GetRandomWord();
        }
        return newWord;
    }

    


}
