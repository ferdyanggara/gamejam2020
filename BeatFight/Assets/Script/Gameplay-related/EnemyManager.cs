using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnemyManager : MonoBehaviour
{
    private EnemyManager() { }
    public static EnemyManager Instance;
    List<Enemy> enemyData = new List<Enemy>();
    public GameObject sampleEnemy;
    public int NumOfEnemy;

    private void Awake()
    {
        Instance = this;
        TypingManager.OnSendWord += CheckEnemyWord;
    }

    public void InitializeEnemy() 
    {
        if (enemyData.Count > 0) //assuming there is enemy pre-initialized
        {
            enemyData.Clear();
        }
        for (int i = 0; i < NumOfEnemy; i++) 
        {

            enemyData.Add(Instantiate(sampleEnemy, transform).GetComponent<Enemy>());
        }
    }

    public void CheckEnemyWord(string text) 
    {

        foreach (Enemy data in enemyData) 
        {
            if (data.CheckAttackWord(text)) 
            {
                CheckNextEnemyState();
                return;
            } 

        }
    }

    public void CheckNextEnemyState() 
    {
        foreach (Enemy data in enemyData) 
        {
            if (!data.IsAlive()) 
            {
                enemyData.Remove(data);
                Destroy(data);
            }
            break;
        }
        if (enemyData.Count <= 0) 
        {
            //insert what scenario should play
            Debug.LogWarning("REINIT ENEMY");
            InitializeEnemy();
        }
    }
}
