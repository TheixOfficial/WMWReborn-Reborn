using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    public float scrollSpeed;

    public float topBarrier;
    public float botBarrier;
    public float leftBarrier;
    public float rightBarrier;

    private float maxY;
    private float minY;
    private float maxX;
    private float minX;

    private float camX;
    private float camY;


    private void Start()
    {
        maxY = GameObject.Find("Wall North").transform.position.z;
        minY = GameObject.Find("Wall South").transform.position.z;
        maxX = GameObject.Find("Wall East").transform.position.x;
        minX = GameObject.Find("Wall West").transform.position.x;

    }

    private void Update()
    {
        camX = Camera.main.gameObject.transform.position.x;
        camY = Camera.main.gameObject.transform.position.z;

        if (Input.mousePosition.y >= Screen.height * topBarrier && camY <= maxY-10)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
        }
        if (Input.mousePosition.y <= Screen.height * botBarrier && camY >= minY)
        {
            transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed, Space.World);
        }
        if (Input.mousePosition.x >= Screen.width * rightBarrier && camX <= maxX)
        {
            transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed, Space.World);
        }
        if (Input.mousePosition.x <= Screen.width * leftBarrier && camX >= minX)
        {
            transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed, Space.World);
        }
    }
}
