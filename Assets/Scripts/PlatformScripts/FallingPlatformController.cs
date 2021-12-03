using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformController : MonoBehaviour
{
    private Rigidbody2D rBody;
    public float startCollapsingSecond = 0.5f;
    public float destroyGameObjectSecond =1.0f;
  
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("CollapsePlatform", startCollapsingSecond);
            Destroy(gameObject, destroyGameObjectSecond);
        }
    }

    private void CollapsePlatform()
    {
        rBody.isKinematic = false;
    }


}
