using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject roomTemplate;
    GameObject room;
    int incrementX = 50;
    int incrementZ = 50;
    int randW;
    int randD;
    void Start()
    {
        
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                room = Instantiate(roomTemplate, new Vector3(i*50 + incrementX, 0, j*50 + incrementZ), Quaternion.identity, GetComponent<Transform>());
                //room.transform.localPosition = new Vector3(room.transform.position.x +300, 0, room.transform.position.z +300);
                incrementZ += 50;
            }
            incrementX += 50;
            incrementZ = 50;
        }
        transform.position = new Vector3(22, 0, 22);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
