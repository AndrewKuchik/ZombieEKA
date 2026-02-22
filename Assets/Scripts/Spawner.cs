using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] Collectibles;
    public Vector3 size = new Vector3(10f,0,10f);
    public float spawnDelay = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnFruit),1f, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFruit()
    {
        int index = Random.Range(0, Collectibles.Length);
        Vector3 randomPosition = transform.position + new Vector3(
            Random.Range(-size.x, size.x), 0f,
            Random.Range(-size.z, size.z) );
        Instantiate(Collectibles[index], randomPosition, Quaternion.identity);
    }
}
