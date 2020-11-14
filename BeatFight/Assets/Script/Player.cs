using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health = 3;

    private void Awake()
    {
        Enemy.OnEnemyAttack += Harmed;
    }

    public void Harmed() 
    {
        health--;
        Debug.Log("PLAYER HIT");
        if (health <= 0) 
        {
            Debug.LogError("IT FUKIN DIED");

        }
    }
}
