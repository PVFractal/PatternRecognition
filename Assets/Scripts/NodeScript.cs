using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 0;
    public bool Good;



    private float startY;
    private float startX;
    private float xSpeed;
    private float constant;

    private float xR;
    private float yR;

    private float impact_time;

    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetStuff(float X, float Y, float speed, float yRand = 0, float xRand = 0, float c = 0, float t = 0)
    {
        startY = Y;
        startX = X;
        xSpeed = speed;
        constant = c;

        xR = xRand;
        yR = yRand;

        impact_time = t;

        
    }

    public void Tick()
    {
        time++;
        if (!Good)
        {
            gameObject.transform.position = new Vector3(startX + (time * xSpeed), startY, 0);

        }
        else
        {
            gameObject.transform.position = new Vector3(startX - (time * xSpeed), constant * Mathf.Sin(xR * (time + yR)), 0);
        }

    }
    
}
