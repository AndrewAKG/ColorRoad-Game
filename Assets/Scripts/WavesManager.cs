using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour {

    public Transform player;
    public GameObject wavePrefab;
    private float spawnZ = -20.0f;
    private float waveLength = 374f;
    private float safeZone = 374f;
    private int amountOfWaves = 4;
    private List<GameObject> activeWaves;

    private void Start()
    {
        activeWaves = new List<GameObject>();
        for (int i = 0; i < amountOfWaves; i++)
        {
            SpawnWave();
        }
    }

    // Update is called once per frame
    void Update () {
        if (player.transform.position.z - safeZone > (spawnZ - amountOfWaves * waveLength))
        {
            SpawnWave();
            DeleteWave();
        }
    }

    void SpawnWave()
    {
        GameObject go;
        go = Instantiate(wavePrefab) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(0f, -3.8f, spawnZ);
        spawnZ += waveLength;
        activeWaves.Add(go);
    }

    void DeleteWave()
    {
        Destroy(activeWaves[0]);
        activeWaves.RemoveAt(0);
    }
}
