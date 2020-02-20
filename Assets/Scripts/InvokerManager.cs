using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokerManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawner;
    [SerializeField] private GameObject[] monster;

    float timer = 0;
    const float restartTimer = 0;
    [SerializeField] float timeBeforeInstantiate;
    [SerializeField] float dispertion;

    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBeforeInstantiate)
        {
            SpawnRandom();
            timer = restartTimer;
        }
    }
    
    private void SpawnRandom()
    {
        int indexMonster = Random.Range(0, monster.Length);
        int indexSpawnPosition = Random.Range(0, monster.Length);
        
        GameObject invocation = Instantiate(monster[indexMonster], spawner[indexSpawnPosition].position, Quaternion.identity);
        invocation.transform.position += (Vector3)Random.insideUnitCircle * dispertion;
    }
}
