using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public Transform player;

    public GameObject[] tilePrefabs;
    private float spawnZ = 0.0f;
    private float tileLength = 7.4f;
    private int amountOfTiles = 20;
    private float safeZone = 7.0f;
    private List<GameObject> activeTiles;
    private int randomIndex = 1;
    private int bridgeCount = 0;

	// Use this for initialization
	void Awake () {
        activeTiles = new List<GameObject>();
        for(int i = 0; i < amountOfTiles; i++)
        {
            SpawnTile();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.z - safeZone > (spawnZ - amountOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    void SpawnTile()
    {
        bridgeCount++;
        randomIndex = (bridgeCount % 5 == 0) ? 1 : 0;
        GameObject go;
        go = Instantiate(tilePrefabs[randomIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
