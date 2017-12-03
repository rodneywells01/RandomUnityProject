using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballEnemy : MonoBehaviour {

    GameObject player;
    Rigidbody rb;
    public float speed;
    public float maxspeed;
    bool canRoll;


	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        rb = GetComponent<Rigidbody>();
        canRoll = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if (canRoll && rb.velocity.magnitude < maxspeed)
        {
            rb.AddForce((player.transform.position - transform.position) * speed);
        }
    }


    // Collision Handling to enable movement. 
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            canRoll = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            canRoll = false;
        }
    }


    
}
