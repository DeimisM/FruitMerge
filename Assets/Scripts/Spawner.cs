using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnerSpeed = 100;
    public Transform[] spawnableFruits;
    static public bool didFruitSpawnYet = false;

    static public Vector2 spawnerXPos;

    void Start()
    {
        
    }

    public void Update()
    {
        SpawnNewFruit();

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.y = 4;

        var finalPostion = Vector3.MoveTowards(transform.position, mousePos, spawnerSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPostion);
        spawnerXPos = finalPostion;
    }

    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(spawnableFruits[Random.Range(0, spawnableFruits.Length)], transform.position, transform.rotation);
    }

    void SpawnNewFruit()
    {
        if (!didFruitSpawnYet)
        {
            StartCoroutine(SpawnCooldown());
            //Instantiate(spawnableFruits[Random.Range(0, spawnableFruits.Length)], transform.position, transform.rotation);
            didFruitSpawnYet = true;
        }
    }
}
