using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    bool hasntSpawned = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (hasntSpawned)
        {
            GetComponent<Transform>().position = Spawner.spawnerXPos;
        }

        if(Input.GetMouseButtonDown(0)) 
        {
            hasntSpawned = false;
            Spawner.didFruitSpawnYet = false;       // nepamirsti zymeti kad ivyko/neivyko
        }
    }
}
