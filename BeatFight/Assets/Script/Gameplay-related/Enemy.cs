using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health = Random.Range(10, 15);
    string currentWord;
    WordManager wordManager;

    int attackSpeed = 9999; //poor implementation
    float timeInterval = 0;
    bool goAttack = false;

    public delegate void EnemyAttack();
    public static event EnemyAttack OnEnemyAttack;
    public Enemy() //by logic, since enemy will be called during gameplay, wordmanager should exist already
    {
        TypingManager.OnUpdateWord += CheckAttackWord;
        wordManager = WordManager.Instance;
        currentWord = wordManager.GetRandomWord();
    }

    public void Update()
    {
        if (goAttack) 
        {
            timeInterval += Time.deltaTime;
            if (timeInterval > attackSpeed)
            {
                OnEnemyAttack?.Invoke();
            }
        }
    }

    public void SetEnemyAttackSpeed(int speed) 
    {
        attackSpeed = speed;

    }

    public string GetEnemyCurrentWord() 
    {
        return currentWord;
    }

    public void CheckAttackWord(string sentWord) 
    {
        if (sentWord == currentWord) Damaged(sentWord);
    }

    private void Damaged(string sentWord) 
    {
        health -= sentWord.Length;
        if(health > 0) { currentWord = wordManager.GetDifferentWord(sentWord); }
    }

    public bool IsAlive() 
    {
        return health > 0;
    }
}
