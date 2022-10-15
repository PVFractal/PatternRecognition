using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameRunner : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera mainCamera;

    private float cameraWidth;
    private float cameraHeight;

    void Start()
    {
        var size = mainCamera.orthographicSize * 2;
        var cameraWidth = size * (float)Screen.width / Screen.height;
        var cameraHeight = size;

        gameObject.transform.position = new Vector3(cameraWidth / 2, 0, 0);
        gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }




}
