using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerWithBuffer : MonoBehaviour
{
    [SerializeField] private Transform player;

    [Range(1.0f,10.0f)][SerializeField] private float camearaOffsetX = 5.0f;
    [Range(1.0f, 10.0f)] [SerializeField] private float camearaOffsetY = 5.0f;


    // Update is called once per frame
    void Update()
    {
        if(player.position.x < transform.position.x - (0.5f * camearaOffsetX)) //left
        {
                transform.position = new Vector3(
                player.position.x + (0.5f * camearaOffsetX),
                transform.position.y,
                transform.position.z);
        }else if(player.position.x > transform.position.x + (0.5f * camearaOffsetX)) //right
        {
              transform.position = new Vector3(
              player.position.x - (0.5f * camearaOffsetX),
              transform.position.y,
              transform.position.z);
        }

        //Check the Y threshold
        if(player.position.y < transform.position.y - (0.5f * camearaOffsetY))
        {
               transform.position = new Vector3(
               transform.position.x ,
               player.position.y + (0.5f * camearaOffsetY),
               transform.position.z);
        }else if (player.position.y > transform.position.y + (0.5f * camearaOffsetX))
        {
            transform.position = new Vector3(
             transform.position.x,
             player.position.y - (0.5f * camearaOffsetY),
             transform.position.z);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(camearaOffsetX, camearaOffsetY, 0.0f));
    }
}
