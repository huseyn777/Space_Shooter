﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    private bool stopSpawning = false;
    [SerializeField] private GameObject [] powerups;

    // Start is called before the first frame update
    public void StartSpawning()
    {
       StartCoroutine(SpawnEnemyRoutine());
       StartCoroutine(SpawnTripleShotPowerupRoutine());
    }

    //Type IEnumerator lets us to yield events
    IEnumerator SpawnEnemyRoutine()
    {
        while(!stopSpawning)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-8f, 8f),7,0),Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            //yield return value(in this example object that makes system to wait for 5 seconds) and then continuies execution from where it left
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator SpawnTripleShotPowerupRoutine()
    {
        while(!stopSpawning)
        {
            yield return new WaitForSeconds(Random.Range(3, 8));
            Instantiate(powerups[Random.Range(0,3)], new Vector3(Random.Range(-8f, 8f),7,0),Quaternion.identity);
        }
    }

    public void PlayerIsDead()
    {
        stopSpawning = true;
    }
}
