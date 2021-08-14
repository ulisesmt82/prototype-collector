using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemsPrefabs;
    [SerializeField]
    private List<GameObject> items = new List<GameObject>();
    private int itemIndex = 0;
    private float spawnRangeX = 2;
    private float spawnZ = 11;
    public float spawnInitY = 3;
    private float spawnTime = 2.0f;
    public int limitSpawn = 5;

    // Start is called before the first frame update
    void Start()
    {
        //initial start
        for (int i = 0; i < 5; i++)
        {
            SpawnRandomItem();

        }
        StartCoroutine(SpawnMoreitems(spawnTime));
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(items);
    }

    IEnumerator SpawnMoreitems(float waitTime) {
        while (items.Count <= limitSpawn) {
            yield return new WaitForSeconds(waitTime);
            SpawnRandomItem();
        }
    }

    void SpawnRandomItem()
    {
        
        GameObject i = Instantiate(itemsPrefabs[Random.Range(0, itemsPrefabs.Length)], new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnInitY, spawnZ), itemsPrefabs[itemIndex].transform.rotation) as GameObject;
        //items.Add(i);
        ItemList.Add(i);


    }
    // ENCAPSULATION
    public List<GameObject> ItemList{
        get { return items;  }
        private set { items = value; }
    }

    public void RemoveItem(GameObject index) {
        if (index != null)
        {
            ItemList.Remove(index);
        }
    }
}
