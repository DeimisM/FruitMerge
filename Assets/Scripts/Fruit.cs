using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    bool hasntSpawned = true;

    void Start()
    {
        if (transform.position.y < 3)
        {
            hasntSpawned = false;
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            Spawner.spawnPosition = transform.position;
            Spawner.isNewFruit = true;
            Spawner.fruitLevel = int.Parse(gameObject.tag);
            
            Destroy(gameObject);
        }
    }
}
