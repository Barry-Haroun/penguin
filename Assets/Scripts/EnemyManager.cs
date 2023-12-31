using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;
    private int totalEnemies;
    private int deadEnemies;
    [SerializeField] private float aggroThreshold = 0.8f;

    public delegate void EnemyEvents();
    public static EnemyEvents ThresholdReached;
    private bool thresholdHasReached = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        // By doing this I find all the pigeons in the scene, which allows me to have the total amount
        EnemyPatrol[] allPigeons = GameObject.FindObjectsByType<EnemyPatrol>(FindObjectsSortMode.None);
        totalEnemies = allPigeons.Length;
    }

    public static EnemyManager GetInstance()
    {
        return instance;
    }

    public void IncreaseDeadEnemies()
    {
        deadEnemies++;
        if (deadEnemies / totalEnemies > aggroThreshold & !thresholdHasReached)
        {
            thresholdHasReached = true;
            ThresholdReached();
        }
    }

    public int GetDeadEnemies()
    {
        return deadEnemies;
    }

    public int GetTotalEnemies()
    {
        return totalEnemies;
    }
}