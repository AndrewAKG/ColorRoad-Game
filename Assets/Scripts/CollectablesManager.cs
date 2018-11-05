using UnityEngine;

public class CollectablesManager : MonoBehaviour {

    public GameObject[] collectablePrefabs;
    public Transform player;
    public int collectablesSoFar = 0;

    private float spawnZ = 4.0f;
    private float spawnX = 0.0f;
    private int amountOfCollectables = 30;
    private int randomIndex;
    private float[] XValues = { 1.5f, 0f, -1.5f };

    // Use this for initialization
    void Start () {
        for (int i = 0; i < amountOfCollectables; i++)
        {
            SpawnCollectable();
        }
    }
	
	// Update is called once per frame
	void Update () {
        while(collectablesSoFar < amountOfCollectables)
        {
            SpawnCollectable();
        }
    }

    void SpawnCollectable()
    {
        randomIndex = Random.Range(0, 3);
        spawnX = XValues[Random.Range(0, 3)];
        GameObject collectable;
        collectable = Instantiate(collectablePrefabs[randomIndex]) as GameObject;
        collectable.transform.SetParent(transform);
        collectable.transform.position = new Vector3(spawnX, 0.3f, spawnZ);
        spawnZ += Random.Range(2,6);
        collectablesSoFar++;
    }
}
