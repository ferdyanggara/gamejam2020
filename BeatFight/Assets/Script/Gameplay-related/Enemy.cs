using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health;
    string currentWord;
    WordManager wordManager;

    float attackSpeed = 9999; //poor implementation
    float timeInterval = 0;

    public delegate void EnemyAttack();
    public static event EnemyAttack OnEnemyAttack;

    public void Start()
    {
        health = Random.Range(10, 15);
        wordManager = WordManager.Instance;
        currentWord = wordManager.GetRandomWord();
        attackSpeed = 5;
        Debug.LogError(currentWord);
    }
    public void Update()
    {
        timeInterval += Time.deltaTime;
        if (timeInterval > attackSpeed)
        {
            Debug.Log("ENEMY ATTACK!");
            OnEnemyAttack?.Invoke();
            timeInterval = 0;
        }

    }

    public string GetEnemyCurrentWord() 
    {
        return currentWord;
    }

    public bool CheckAttackWord(string sentWord) 
    {
        if (sentWord == currentWord.Trim()) 
        { 
            Damaged(sentWord); 
            return true; 
        }
        else return false;
    }

    private void Damaged(string sentWord) 
    {
        health -= sentWord.Length;
        if(health > 0) 
        { 
            currentWord = wordManager.GetDifferentWord(sentWord);
            timeInterval = 0;
            Debug.Log("Enemy New WORD " + currentWord);
        }
    }

    public bool IsAlive() 
    {
        return health > 0;
    }
}
