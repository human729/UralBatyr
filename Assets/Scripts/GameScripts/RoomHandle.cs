using UnityEngine;

public class RoomHandle : MonoBehaviour
{
    [Header("Targets")]
    public GameObject Enemy;
    public GameObject Player;

    [Header("SpawnZone")]
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float y;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            SpawnEnemies();
        }
    }

    public void SpawnEnemies()
    {
        int EnemyCount = Random.Range(3, 10);

        for (int i = 0; i < EnemyCount; i++)
        {
            GameObject singleEnemy = Enemy;
            singleEnemy.GetComponent<AINavigation>().target = Player.transform;
            Instantiate(singleEnemy, new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ)), Quaternion.identity);
        }
    }
}
