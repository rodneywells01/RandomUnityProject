using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour {

    Vector3 position;
    Vector3 cameraoffset;
    GameObject player;


    // Use this for initialization
    void Start () {
        position = GetComponent<Transform>().position;
        player = GameObject.Find("player");
        cameraoffset = position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Transform>().position = player.transform.position + cameraoffset;

        if (Input.GetMouseButton(0))
        {
            // User leftclick. Raycast to object. 
            RaycastHit hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);            

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit!");

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
