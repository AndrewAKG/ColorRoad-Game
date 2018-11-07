using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public GameObject[] lightPrefabs;
    private float spawnZ = 100.0f;
    private float spawnX = 0.0f;
    private int amountOfLights = 1;
    public int lightsSoFar = 0;
    private int randomIndex;


    // Use this for initialization
    void Start()
    {
        SpawnLight();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsSoFar < amountOfLights)
        {
            SpawnLight();
        }
    }

    void SpawnLight()
    {
        randomIndex = Random.Range(0, 3);
        GameObject light;
        light = Instantiate(lightPrefabs[randomIndex]) as GameObject;
        light.transform.SetParent(transform);
        light.transform.position = new Vector3(spawnX, 5.0f, spawnZ);
        spawnZ += 200;
        lightsSoFar++;
    }
}