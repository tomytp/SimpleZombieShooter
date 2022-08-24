using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Assertions;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private float spawnCooldown = 1f;
    private GameObject[] _spawnLocations;

    private void Awake()
    {
        _spawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");
        Assert.IsTrue(_spawnLocations.Length > 0, "No Spawn Locations Detected");
    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            var spawnLocation = _spawnLocations[Random.Range(0, _spawnLocations.Length)].transform;
            var spawned = Instantiate(zombie, spawnLocation.position, spawnLocation.rotation, transform);
            spawned.transform.GetChild(Random.Range(1,28)).gameObject.SetActive(true);
            spawnCooldown *= 0.99f;
            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}
