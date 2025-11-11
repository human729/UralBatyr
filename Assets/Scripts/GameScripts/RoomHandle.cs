using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoomHandle : MonoBehaviour
{
    public List<Animation> GatesAnims;

    [Header("Targets")]
    public GameObject Enemy;
    public GameObject Player;

    [Header("SpawnZone")]
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float y;

    private bool isStarted = false;
    private List<GameObject> Enemies = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (!isStarted)
            {
                isStarted = true;
                foreach (Animation anim in GatesAnims)
                {
                    anim.Play("GatesAnim");
                }
                
                StartCoroutine(WaveEndWaiting());
            }
        }
    }

    public void SpawnEnemies()
    {
        int EnemyCount = Random.Range(3, 10);
        for (int i = 0; i < EnemyCount; i++)
        {
            GameObject singleEnemy = Enemy;
          //  singleEnemy.GetComponent<AINavigation>().target = Player.transform;
            Enemies.Add(Instantiate(singleEnemy, new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ)), Quaternion.identity));
        }
    }

    IEnumerator WaveEndWaiting()
    {
        int WavesCount = Random.Range(2, 5);
        for (int i = 0; i < WavesCount; i++)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(5f);
            foreach (var enemy in Enemies)
            {
                Destroy(enemy);
            }
        }
        Enemies.Clear();
        foreach (Animation anim in GatesAnims)
        {
            anim.Play("DownGates");
        }
    }
}
