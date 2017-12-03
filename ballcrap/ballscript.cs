using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour {

    Vector3 startposition;
    // Use this for initialization
    void Start () {
        startposition = this.gameObject.transform.position;            
	}

    public void Reset()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.position = startposition;
        rb.angularVelocity = Vector3.zero;
        int max = 3;
        rb.velocity = new Vector3(Random.Range(-max, max), Random.Range(-max, max), Random.Range(-max, max));

        
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
