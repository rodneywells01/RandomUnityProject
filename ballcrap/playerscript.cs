using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour {

    // Use this for initialization
    GameObject[] balls;
    void Start () {
		balls = GameObject.FindGameObjectsWithTag("ball");
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject ball in balls)
            {
                ball.GetComponent<ballscript>().Reset();
            }
        }
    }
   

	// Update is called once per frame
	void Update () {
		
	}
}
