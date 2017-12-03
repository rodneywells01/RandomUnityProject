using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeLife : MonoBehaviour {
    public float timeToLive;

    public void TriggerDeath()
    {
        StartCoroutine(DeathRoutine(timeToLive));
    }

    public void TriggerDeath(float timeToLive)
    {
        StartCoroutine(DeathRoutine(timeToLive));
    }

    IEnumerator DeathRoutine(float timeToLive)
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }
}
