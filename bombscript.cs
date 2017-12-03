using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombscript : MonoBehaviour {

    public float damage;

	// Use this for initialization
	void Start () {
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.Find("player").GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        GetComponent<Collider>().enabled = false;
        Debug.Log("Bombhit!");
        GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(GetComponent<Rigidbody>());

        // Create explosive force. 
        Collider[] colliders = Physics.OverlapSphere(transform.position, 7);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>(); 
            if (rb != null)
            {
                rb.AddExplosionForce(250, transform.position, 5, 3F);

                // Damage enemies
                if (hit.GetComponent<hpInterface>() != null)
                {
                    hit.GetComponent<hpInterface>().TakeDamage(damage);
                }
            }
        }

        // Hide the bomb, wick, and fuse.              
        Destroy(transform.FindChild("Wick").gameObject);
        
        // Start the explosion animation 
        transform.Find("ExplosionParticleSystem").GetComponent<ParticleSystem>().Play();

        // Delete the object.         
        GetComponent<timeLife>().TriggerDeath();
    }
  
}
