using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wallPrefab;
    public GameObject RoomPrefab;
    public int roomWidth = 12;
    public int roomDepth = 12;
    public int gapThreshold = 4;
 
    void Start()
    {
        for (int x = 0; x < roomWidth; x++)
        {
            for (int y = 0; y < roomDepth; y++)
            {
                Instantiate(RoomPrefab, new Vector3(x * 5f, 0f, y * 5f), Quaternion.identity, GetComponent<Transform>());
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
