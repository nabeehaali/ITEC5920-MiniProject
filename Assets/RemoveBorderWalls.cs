using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBorderWalls : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> borders;
    public int wallThreshold;
    public float wallAdd;
    public GameObject wallPrefab;
    void Start()
    {
        for (int i = 0; i < borders.Count / wallThreshold; i++)
        {
           int randomWall = Random.Range(0, borders.Count);
           Destroy(borders[randomWall].transform.parent.gameObject);
           borders.RemoveAt(randomWall);
        }

        for (int i = 0; i < transform.childCount * wallAdd; i++)
        {
            int randomWall = Random.Range(0, transform.childCount);
            Instantiate(wallPrefab, transform.GetChild(randomWall));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
