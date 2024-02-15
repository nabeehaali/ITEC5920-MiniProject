using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RoomTemplate;
    public int mazeWidth;
    public int mazeDepth;
 
    void Start()
    {
        mazeWidth = GameObject.Find("MazeGenerator").GetComponent<MazeGenerator>()._mazeWidth;
        mazeDepth = GameObject.Find("MazeGenerator").GetComponent<MazeGenerator>()._mazeHeight;

        for (int x = 0; x < mazeWidth; x++)
        {
            for (int y = 0; y < mazeDepth; y++)
            {
                Instantiate(RoomTemplate, new Vector3(x * 5f, 0f, y * 5f), Quaternion.identity, GetComponent<Transform>());
                //Physics.IgnoreCollision(RoomPrefab.transform.GetChild(0).GetComponent<Collider>(), wallPrefab.transform.GetChild(0).GetComponent<Collider>());
            }
        }

        //int childCount = transform.childCount;
        //for (int i = 0; i < childCount / gapThreshold; i++)
        //{
        //    int randomChild = Random.Range(0, childCount);
        //    Destroy(transform.GetChild(randomChild).gameObject);
        //}
        //Physics.IgnoreCollision(RoomPrefab.transform.GetChild(0).GetComponent<Collider>(), wallPrefab.transform.GetChild(0).GetComponent<Collider>(), false);
    }

    // Update is called once per fram
    void Update()
    {
        
    }
}
