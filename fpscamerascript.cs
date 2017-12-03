using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpscamerascript : MonoBehaviour
{

    Vector3 position;
    Vector3 cameraoffset;
    GameObject player;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    float speed = 5f;
    public float speedH;
    public float speedV;
    
    // Use this for initialization
    void Start()
    {
        speedH = speed;
        speedV = speed;
        position = GetComponent<Transform>().position;
        player = GameObject.Find("player");
        cameraoffset = position - player.transform.position;

        pitch = transform.eulerAngles.x;
        yaw = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = player.transform.position + cameraoffset;
        updateRotation();
    }

    void updateRotation()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    void depr()
    {
        if (Input.GetMouseButton(0))
        {
            // User leftclick. Raycast to object. 
            RaycastHit hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Let us see what was hit. 
                if (hit.transform.gameObject.tag == "terrain")
                {
                    // Issuing new move command.  
                    player.GetComponent<movescript>().IssueMoveCommand(player.transform.position, hit.point);
                }
            }
        }
    }
}
