using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpInterface : MonoBehaviour {
    public float health;
    public TextMesh damageDisplay;
    bool hasCollided = false;

    public void TakeDamage(float damage)
    {
        if (!hasCollided)
        {
            hasCollided = true;

            // Show the damage.       
            TextMesh newDisplay = Instantiate(damageDisplay);
            newDisplay.text = damage.ToString();
            newDisplay.transform.position = gameObject.transform.position + Vector3.up * 3;
            newDisplay.transform.LookAt(2 * transform.position - GameObject.Find("Main Camera").transform.position);

            // Inflict damage.
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
                Destroy(this);
            }
        }
        
    }

    void LateUpdate()
    {
        //Fix for multiple collisions. 
        hasCollided = false;
    }
}
