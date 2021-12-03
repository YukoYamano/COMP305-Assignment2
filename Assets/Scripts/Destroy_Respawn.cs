using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Respawn : MonoBehaviour
{
    [SerializeField] private GameObject gobj;
    [SerializeField] private Transform spawnPoint;

   

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            Instantiate(gobj, spawnPoint.position, Quaternion.identity);
            Destroy(other.gameObject);

        }

    }
}
