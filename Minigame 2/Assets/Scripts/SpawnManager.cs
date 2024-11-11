using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leavesPrefab;
    public float spawnXOffset = 1.5f; // Controls the range on the X axis
    public float spawnYOffset = 3f; // Controls the range on the Y axis
    public int numLeavesToSpawn = 20; // Total number of leaves to spawn

    void Start()
    {
        // Find all capsules in the scene
        GameObject[] capsules = GameObject.FindGameObjectsWithTag("Capsule"); // Assuming you tagged the capsules as "Capsule"
        
        // Check if we have at least 1 capsule to spawn leaves around
        if (capsules.Length == 0) return;

        // Spawn a set number of leaves
        for (int i = 0; i < numLeavesToSpawn; i++)
        {
            // Choose a random capsule
            GameObject chosenCapsule = capsules[Random.Range(0, capsules.Length)];

            // Generate a random position near the chosen capsule
            Vector3 spawnPosition = chosenCapsule.transform.position + new Vector3(
                Random.Range(-spawnXOffset, spawnXOffset), // Randomize on X axis
                Random.Range(-spawnYOffset, spawnYOffset), // Randomize on Y axis
                0 // Keep Z axis constant
            );

            // Instantiate the leaves at the calculated position
            Instantiate(leavesPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        // Optional: Any additional behavior for the leaves can be added here
    }
}
