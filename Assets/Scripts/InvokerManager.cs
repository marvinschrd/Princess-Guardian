using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokerManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawner;
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
            mmonster=(Monster)Random.Range(0,3);
                canChoseMonster = true;
                timer = timeBeforeInstantiate;
                state = State.WAITING;
            break;
            case State.CHOSING_SPAWN:
                indexSpawnPosition = Random.Range(0, spawner.Length);
                state = State.SPAWNING;
                break;
            case State.SPAWNING:
                Instantiate(monsterToSpawn, spawner[indexSpawnPosition].position, Quaternion.identity);
                break;
            case State.WAITING:
                break;
            case State.COOLDOWN:
                timer -= Time.deltaTime;
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
                    randomResult = Random.Range(0, 1);
                    if (randomResult == 1)
                    {
                        monsterToSpawn = fastMonster;
                    }
                    else
                    {
                        state = State.CHOSING_MONSTER;
                    }
                    canChoseMonster = false;
                    break;
                case Monster.STRONG_MONSTER:
                    randomResult = Random.Range(0, 3);
                    if (randomResult == 3)
                    {
                        monsterToSpawn = strongMonster;
                    }
                    else
                    {
                        state = State.CHOSING_MONSTER;
                    }
                    canChoseMonster = false;
                    break;
                case Monster.SUPER_STRONG_MONSTER:
                    randomResult = Random.Range(0, 4);
                    if (randomResult == 4)
                    {
                        monsterToSpawn = superStrongMonster;
                    }
                    else
                    {
                        state = State.CHOSING_MONSTER;
                    }
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
