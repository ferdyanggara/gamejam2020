using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnemyManager : MonoBehaviour
{
    private EnemyManager() { }
    public static EnemyManager Instance;
    List<Enemy> enemyData;
    public int NumOfEnemy;

    private void Awake()
    {
        Instance = this;
    }

    public void InitializeEnemy() 
    {
        if (enemyData.Count > 0) //assuming there is enemy pre-initialized
        {
            enemyData.Clear();
        }
        for (int i = 0; i < NumOfEnemy; i++) 
        {
            enemyData.Add(new Enemy());
        }
    }

    public void 
}
