using UnityEngine;

public class PickupManager : MonoBehaviour
{
    // randomly spawn pickups within the available area
    // pickup prefab
    // spawnable area
    // time frequency

    [SerializeField]
    private GameObject pickupPrefab = null;

    [SerializeField]
    private Transform minSpawnArea = null;

    [SerializeField]
    private Transform maxSpawnArea = null;

    [SerializeField]
    private float minSpawnRate = 1.0f;

    [SerializeField]
    private float maxSpawnRate = 1.0f;

    private float nextSpawnTime = 0.0f;

    private void Awake()
    {
        nextSpawnTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawnTime -= Time.deltaTime;
        if(nextSpawnTime < 0.0f)
        {
            SpawnPickup();
            nextSpawnTime = UnityEngine.Random.Range(minSpawnRate, maxSpawnRate);
        }
    }
    private void SpawnPickup()
    {
        Vector3 spawnPosition = Vector3.zero;
        spawnPosition.x = Random.Range(minSpawnArea.position.x, maxSpawnArea.position.x);
        spawnPosition.y = Random.Range(minSpawnArea.position.y, maxSpawnArea.position.y);
        spawnPosition.z = minSpawnArea.position.z;
        Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
    }
}
