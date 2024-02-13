using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject wallPrefab;
    GameObject room;
    int incrementX = 50;
    int incrementZ = 50;
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                room = Instantiate(wallPrefab, new Vector3(i*50 + incrementX, 0, j*50 + incrementZ), Quaternion.identity);
                room.transform.localScale = new Vector3(Random.Range(5, 15), 0, Random.Range(5, 15));
                incrementZ += 50;
            }
            incrementX += 50;
            incrementZ = 50;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
