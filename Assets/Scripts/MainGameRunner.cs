﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameRunner : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera mainCamera;
    public GameObject fireBar;

    private float cameraWidth;
    private float cameraHeight;

    public GameObject goodNode;
    public GameObject badNode;

    private List<GameObject> goodNodes;
    private List<GameObject> badNodes;


    //Control variables
    private float ultimateSpeed = 200;
    private float fraction = 3;

    private float options = 3;

    private float explosionRadius;

    private float timer = 0;
    private float limit;
    private List<float> positions;

    private float speed;

    private float impact_time;

    public bool testMode;

    public GameObject explosion;


    private MainAlgorithm calculator;


    void Start()
    {
        calculator = new MainAlgorithm();

        limit = ultimateSpeed / fraction;

        float upper_half = Mathf.Ceil(fraction/2);



        impact_time = ultimateSpeed * (upper_half / fraction);



        var size = mainCamera.orthographicSize * 2;
        cameraWidth = size * (float)Screen.width / Screen.height;
        cameraHeight = size;


        gameObject.transform.position = new Vector3(cameraWidth / 2, 0, 0);
        gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 1);

        fireBar.transform.position = new Vector3(0, cameraHeight / 2 - 0.1f, 0);

        goodNodes = new List<GameObject>();
        badNodes = new List<GameObject>();

        positions = new List<float>();


        speed = cameraWidth / ultimateSpeed;

        

        FillStartPositions();
        
    }

    void FillStartPositions()
    {
        float fakeHeight = cameraHeight * 0.75f;

        explosionRadius = (fakeHeight / options) / 3f;


        float splits = fakeHeight / (options + 1);

        for (int i = 1; i <= (int)options; i++)
        {
            
            float final = (fakeHeight / -2.0f) + splits * (float)i;


            positions.Add(final);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Fire(int keyPress)
    {
        if (keyPress == -1) { return; }

        GameObject node = Instantiate(badNode);


        node.GetComponent<NodeScript>().SetStuff(cameraWidth / -2.0f, positions[keyPress - 1],speed);
        badNodes.Add(node);

    }

    private void ComputerFire(int opponentKey)
    {

        if (testMode)
        {

            int keyPress = -1;
            if (Input.GetKey(KeyCode.Q))
            {
                keyPress = 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                keyPress = 2;
            }
            if (Input.GetKey(KeyCode.E))
            {
                keyPress = 3;
            }
            if (Input.GetKey(KeyCode.R))
            {
                keyPress = 4;
            }
            if (Input.GetKey(KeyCode.T))
            {
                keyPress = 5;
            }
            if (Input.GetKey(KeyCode.Y))
            {
                keyPress = 6;
            }

            if (keyPress == -1) { return; }



            createBadNode(keyPress);


        }
        else
        {

            calculator.addToArray(opponentKey);
            int nextMove = calculator.GetPrediction();

            if (nextMove == -1)
            {
                nextMove = (int)Random.Range(1, options);
            }

            createBadNode(nextMove);


        }
        


    }


    private void createBadNode(int pos)
    {
        GameObject node = Instantiate(goodNode);

        float random_x = Random.Range(0.1f, 1f) * speed;

        float wave_size = cameraHeight / 2.4f;

        float random_y = Mathf.Asin(positions[pos - 1] / wave_size) / (random_x) - impact_time;

        node.GetComponent<NodeScript>().SetStuff(cameraWidth / 2.0f, positions[pos - 1], speed, random_y, random_x, wave_size, impact_time);

        goodNodes.Add(node);
    }



    private void FixedUpdate()
    {


        timer++;
        if (timer >= limit)
        {
            int keyPress = -1;
            

            if (Input.GetKey(KeyCode.Alpha1))
            {
                keyPress = 1;
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                keyPress = 2;
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                keyPress = 3;
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                keyPress = 4;
            }
            if (Input.GetKey(KeyCode.Alpha5))
            {
                keyPress = 5;
            }
            if (Input.GetKey(KeyCode.Alpha6))
            {
                keyPress = 6;
            }


            Fire(keyPress);

            ComputerFire(keyPress);


            timer = 0;
        }


        float scale = ((float)limit - (float)timer) / (float)limit;


        fireBar.transform.localScale = new Vector3(scale * 10f, 1, 0);



        MoveNodes();


    }

    private void MoveNodes()
    {




        int toDestroy = -1;
        int toRemove = -1;


        for (int i = goodNodes.Count - 1; i >= 0; i--)
        {
            goodNodes[i].GetComponent<NodeScript>().Tick();

            if (goodNodes[i].GetComponent<NodeScript>().time > impact_time)
            {
                GameObject death = Instantiate(explosion) as GameObject;
                death.transform.position = goodNodes[i].transform.position;
                toDestroy = i;
            }
        }

        

        if (toDestroy != -1)
        {
            var foulNode = goodNodes[toDestroy];

            for (int i = 0; i < badNodes.Count; i++)
            {
                if (Vector3.Distance(foulNode.transform.position, badNodes[i].transform.position) < explosionRadius)
                {
                    toRemove = i;
                }
            }



            goodNodes.Remove(foulNode);
            Destroy(foulNode);
        }




        
        if (badNodes.Count != 0)
        {
            for (int i = 0; i < badNodes.Count; i++)
            {
                badNodes[i].GetComponent<NodeScript>().Tick();

                if(badNodes[i].GetComponent<NodeScript>().time > impact_time * 2f + 31.0f)
                {
                    toRemove = i;
                }
            }
        }
        if (toRemove != -1)
        {
            var foulNode = badNodes[toRemove];
            badNodes.Remove(foulNode);
            Destroy(foulNode);
        }



        



    }



}
