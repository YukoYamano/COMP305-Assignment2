using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipToHazardPlatformController : MonoBehaviour
{
    public GameObject gobj;
    [SerializeField] private Transform respawnPoint;

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
            Instantiate(gobj, respawnPoint.position, Quaternion.identity);
            Destroy(other.gameObject);
        }       
    }





}
