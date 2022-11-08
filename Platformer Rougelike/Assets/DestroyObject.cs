using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float TimeToDestroy;
    void Start()
    {
        StartCoroutine(DestroyObjectCooldown());
    }

   IEnumerator DestroyObjectCooldown()
   {
        yield return new WaitForSeconds(TimeToDestroy);
        Destroy(gameObject);
   }
}
