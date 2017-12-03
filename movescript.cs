using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescript : MonoBehaviour {

    private IEnumerator movementcoroutine;
    public float speed = 5f;
    public bool boosting = false;

    // Use this for initialization
    void Start () {
        movementcoroutine = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (boosting) { speed = 5f; }
            else { speed = 30f;  }

            boosting = !boosting;
        }

        //GetComponent<Rigidbody>().velocity = velocity;
    }

    public void IssueMoveCommand(Vector3 startPos, Vector3 endPos)
    {
        Debug.Log("Moving!");
        if (movementcoroutine != null)
        {
            StopCoroutine(movementcoroutine);            
        }
        movementcoroutine = MoveObject(startPos, endPos);
        StartCoroutine(movementcoroutine);
    }


    float getTerrainHeightUnderPlayer()
    {
        // Vertical pos based on terrain. 
        Ray terraincheckray = new Ray(GetComponent<Transform>().position, Vector3.down);
        RaycastHit hit;
        float height = GetComponent<Transform>().position.y;
        if (Physics.Raycast(terraincheckray, out hit))
        {
            if (hit.collider.gameObject.tag == "terrain")
            {
                height = hit.point.y;
            }
        }
        return height;
    }

    private IEnumerator MoveObject(Vector3 startPos, Vector3 endPos)
    {
        float progress = 0.0f;
        

        Debug.Log(endPos);

        float distance = Vector3.Distance(startPos, endPos);

        while (progress < 1.0f)
        {
            // Set Horizontal position.
            Vector3 newpos = Vector3.Lerp(startPos, endPos + Vector3.up, progress);

            newpos.y = getTerrainHeightUnderPlayer() + 1;

            // Set new pos.
            GetComponent<Transform>().position = newpos;

            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime * speed / distance * 1.0f;
        }

        GetComponent<Transform>().transform.position = endPos + Vector3.up;
    }
}
