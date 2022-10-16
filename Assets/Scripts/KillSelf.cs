using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    // Start is called before the first frame update

    int timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        timer++;
        if (timer > 300)
        {
            Destroy(gameObject);
        }
    }
}
