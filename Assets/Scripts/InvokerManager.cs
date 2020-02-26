using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokerManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawner = new Transform[3];
   //[SerializeField] private GameObject[] monster;

    float timer = 0;
    const float restartTimer = 0;
    [SerializeField] float timeBeforeInstantiate;
    [SerializeField] float dispertion;

    GameObject monsterToSpawn;

    [SerializeField] GameObject normalMonster;
    [SerializeField] GameObject fastMonster;
    [SerializeField] GameObject strongMonster;
    [SerializeField] GameObject superStrongMonster;

    //[SerializeField] Transform spawn1;
    //[SerializeField] Transform spawn2;
    //[SerializeField] Transform spawn3;
    //[SerializeField] Transform spawn4;
    //int spawnNumber = 0;
    //Transform spawn;


    bool canChoseMonster = false;
    int chosenMonster = 0;
    int randomResult = 0;
    int indexSpawnPosition = 0;
    void Start()
    {
    }
    enum Monster
    {
        NORMAL_MONSTER,
        FAST_MONSTER,
        STRONG_MONSTER,
        SUPER_STRONG_MONSTER
    }
    Monster mmonster;


    enum State
    {
        CHOSING_SPAWN,
        CHOSING_MONSTER,
        SPAWNING,
        WAITING,
        COOLDOWN
    }

    State state = State.CHOSING_MONSTER;
    void Update()
    {

        switch(state)
        {
            case State.CHOSING_MONSTER: // doit changer pour augmenter la chance de spawn un ennemi normal et non puissant
               // Debug.Log("chosing monster");
            mmonster=(Monster)Random.Range(0,3);
               // Debug.Log(mmonster);
                canChoseMonster = true;
                timer = timeBeforeInstantiate;
                state = State.WAITING;
            break;
            case State.CHOSING_SPAWN:
               // Debug.Log("chosing spawn");
                indexSpawnPosition = Random.Range(0, spawner.Length);
               
                state = State.SPAWNING;
                break;
            case State.SPAWNING:
               // Debug.Log("spawning");
                Instantiate(monsterToSpawn, spawner[indexSpawnPosition].position, Quaternion.identity);
                state = State.COOLDOWN;
                break;
            case State.WAITING:
                break;
            case State.COOLDOWN:
                timer -= Time.deltaTime;
               // Debug.Log("waiting");
                if(timer<=0)
                {
                    state = State.CHOSING_MONSTER;
                }
                break;
        }

        if (canChoseMonster)
        {
            switch (mmonster)
            {
                case Monster.NORMAL_MONSTER:
                    monsterToSpawn = normalMonster;
                    state = State.CHOSING_SPAWN;
                    canChoseMonster = false;
                    break;
                case Monster.FAST_MONSTER:
                    //randomResult = Random.Range(0, 1);
                    //Debug.Log(randomResult);
                    //if (randomResult == 1)
                    //{
                    //    monsterToSpawn = fastMonster;
                    //    state = State.CHOSING_SPAWN;
                    //}

                    //else
                    //{
                    //    state = State.CHOSING_MONSTER;
                    //}
                    monsterToSpawn = fastMonster;
                    state = State.CHOSING_SPAWN;
                    canChoseMonster = false;
                    break;
                case Monster.STRONG_MONSTER:
                    //randomResult = Random.Range(0, 3);
                    //Debug.Log(randomResult);
                    //if (randomResult == 3)
                    //{
                    //    monsterToSpawn = strongMonster;
                    //    state = State.CHOSING_SPAWN;
                    //}
                    //else
                    //{
                    //    state = State.CHOSING_MONSTER;
                    //}
                    monsterToSpawn = strongMonster;
                    state = State.CHOSING_SPAWN;

                    canChoseMonster = false;
                    break;
                case Monster.SUPER_STRONG_MONSTER:
                    //randomResult = Random.Range(0, 4);
                    //Debug.Log(randomResult);
                    //if (randomResult == 4)
                    //{
                    //    monsterToSpawn = superStrongMonster;
                    //    state = State.CHOSING_SPAWN;
                    //}
                    //else
                    //{
                    //    state = State.CHOSING_MONSTER;
                    //}
                    monsterToSpawn = superStrongMonster;
                    state = State.CHOSING_SPAWN;

                    canChoseMonster = false;
                    break;
            }
        }

        




        //timer += Time.deltaTime;
        //if (timer >= timeBeforeInstantiate)
        //{
        //    SpawnRandom();
        //    timer = restartTimer;
        //}
    }
    
    //private void SpawnRandom()
    //{
    //    int indexMonster = Random.Range(0, monster.Length);
    //    int indexSpawnPosition = Random.Range(0, monster.Length);
    //    GameObject invocation = Instantiate(monster[indexMonster], spawner[indexSpawnPosition].position, Quaternion.identity);
    //    invocation.transform.position += (Vector3)Random.insideUnitCircle * dispertion;

    //    int indexMonster2 = Random.Range(0, monster.Length);
    //    GameObject invocation2 = Instantiate(monster[indexMonster2], spawner[indexSpawnPosition].position, Quaternion.identity);
    //    invocation.transform.position += (Vector3)Random.insideUnitCircle * dispertion;

    //}
}
