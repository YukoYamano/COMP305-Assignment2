using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatformController : MonoBehaviour
{
    public GameObject gameObjectTodisable;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("CollapsePlatform", 0.8f);
        }
    }

    private void CollapsePlatform()
    {
        gameObjectTodisable.SetActive(false);
        Invoke("DestroyObject", 0.8f);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
