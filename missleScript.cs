using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missleScript : MonoBehaviour {

    public float speed;
    public float turnSpeed;
    public GameObject target;
    public float damage;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        // Update vector 
        GetComponent<Rigidbody>().velocity = transform.up * speed;

        // Look towards target. 
        
        Vector3 dir = (target.transform.position - transform.position).normalized;
        //Debug.Log(target.transform.position - transform.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir, transform.up) * Quaternion.Euler(90, 0, 0), turnSpeed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision col)
    {
        // Boom 
        // Create explosive force. 
        
        Debug.Log("Dead missle!");

        Debug.Log(col.gameObject.name);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 7);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(250, transform.position, 5, 3F);

                // Damage all
                if (hit.GetComponent<hpInterface>() != null)
                {
                    hit.GetComponent<hpInterface>().TakeDamage(damage);
                }
            }
        }

        Destroy(gameObject);
        
        

    }
}
