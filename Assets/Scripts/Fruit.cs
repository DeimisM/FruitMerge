using UnityEngine;

public class FruitMerge : MonoBehaviour
{
    public int fruitLevel = 1;

    public GameObject applePrefab;
    public GameObject orangePrefab;

    private bool hasSpawnedNewFruit = false; // Flag to track if a new fruit has been spawned

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        FruitMerge collidedFruit = collidedObject.GetComponent<FruitMerge>();

        // Ensure the fruit has not already spawned a new fruit and only one of the colliding fruits handles spawning
        if (!hasSpawnedNewFruit && collidedFruit != null && collidedFruit.fruitLevel == fruitLevel && collidedFruit.transform.position.x < transform.position.x)
        {
            Destroy(collidedObject); // Destroy the collided fruit
            hasSpawnedNewFruit = true; // Set the flag to true to prevent multiple spawns

            SpawnUpgradedFruit(fruitLevel + 1);

            // Disable movement controlled by the Player script
            GetComponent<Player>().enabled = false;
        }
    }

    private void SpawnUpgradedFruit(int newLevel)
    {
        GameObject newFruit = Instantiate(GetFruitPrefab(newLevel), transform.position, Quaternion.identity);

        // Adjust the position based on the size of the new fruit to prevent clipping
        Vector3 newPosition = newFruit.transform.position;
        newPosition.y -= newFruit.GetComponent<SpriteRenderer>().bounds.extents.y; // Adjust vertically by half of the fruit's height
        newFruit.transform.position = newPosition;

        // Add merge script to the new fruit
        FruitMerge newFruitMerge = newFruit.AddComponent<FruitMerge>();
        newFruitMerge.fruitLevel = newLevel;
    }

    private GameObject GetFruitPrefab(int newLevel)
    {
        if (newLevel == 2) return orangePrefab;
        if (newLevel == 3) return applePrefab;

        return applePrefab; // Default to apple prefab
    }
}
