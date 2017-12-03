using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetDesignator : MonoBehaviour {

    public Transform missle;
    bool hitsomething = false;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col) {
        // Stick to parent. 
        if (!hitsomething)
        {
            hitsomething = true;
            Debug.Log("Desig hit!");

            transform.parent = col.gameObject.transform;
            GetComponent<Collider>().enabled = false;
            Destroy(GetComponent<Rigidbody>());

            // Summon missle. 
            Transform misslelaunch = Instantiate(missle, GameObject.Find("missleSpawnPoint").transform.position, Quaternion.identity);
            Debug.Log("Missle Spawned");
            misslelaunch.GetComponent<missleScript>().target = gameObject;
            misslelaunch.GetComponent<missleScript>().speed = 20f;
            misslelaunch.GetComponent<missleScript>().turnSpeed = 3f;
            misslelaunch.GetComponent<missleScript>().damage = 30f;
        }

        
    }
}
