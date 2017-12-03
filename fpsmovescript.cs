using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsmovescript : MonoBehaviour
{

    public float speed = 5f;
    public bool boosting = false;
    Vector3 velocity;
    GameObject camera;
    GameObject gun;
    GameObject gunbarrel;
    public Transform targetReticle;
    public Transform bomb;
    bool touchingGround;

    // Use this for initialization
    void Start()
    {
        touchingGround = true;
        camera = GameObject.Find("Main Camera");
        gun = GameObject.Find("gun");
        gunbarrel = GameObject.Find("launchorigin");
    }

    // Update is called once per frame
    void Update()
    {
        // Determine movement. 
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            velocity += camera.transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity -= camera.transform.right * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity -= camera.transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += camera.transform.right * speed;
        }

        // Normalize on the world plane.
        velocity = Vector3.ProjectOnPlane(velocity, new Vector3(0, 1, 0)).normalized * speed;

        // Restore previous speed 
        velocity.y = GetComponent<Rigidbody>().velocity.y;

        // Boost?
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (boosting) { speed = 5f; }
            else { speed = 30f; }
            boosting = !boosting;
        }

     
        GetComponent<Rigidbody>().velocity = velocity;

        // Jump? 
        if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 250);
        }

        //Shoot?
        if (Input.GetMouseButtonDown(0))
        {
            // Generate bomb, put some spin  on it and launch it. 
            launchObject(bomb, 2000, 10);
        }
        if (Input.GetMouseButtonDown(1))
        {
            launchObject(targetReticle, 2000, 10);
        }
    }

    void launchObject(Transform launchobject, float force, float maxtorque)
    {
        Transform launchedobject = Instantiate(launchobject, gunbarrel.transform.position, Quaternion.identity);
        launchedobject.GetComponent<Rigidbody>().AddForce(camera.transform.forward * force);       
        launchedobject.GetComponent<Rigidbody>().AddTorque(new Vector3(
            Random.RandomRange(-maxtorque, maxtorque), Random.RandomRange(-maxtorque, maxtorque), Random.RandomRange(-maxtorque, maxtorque)
        ));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Terrain")
        {
            touchingGround = true;
        }        
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Terrain")
        {
            touchingGround = false;
        }
    }
}
