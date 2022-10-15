using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 position = gameObject.transform.position;
        gameObject.transform.position = new Vector3(position.x - 0.1f, position.y, position.z);
    }
}
