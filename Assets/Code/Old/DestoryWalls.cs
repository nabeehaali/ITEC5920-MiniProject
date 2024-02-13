using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryWalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.transform.parent.gameObject.tag == "Wall")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
