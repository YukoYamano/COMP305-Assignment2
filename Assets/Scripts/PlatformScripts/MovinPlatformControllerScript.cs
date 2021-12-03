using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinPlatformControllerScript : MonoBehaviour
{

    [Header("Path")] public GameObject[] wayPoints;
    [Header("Speed")] public float speed = 5.0f;

    private Rigidbody2D rBody;
    private int currentPointIndex = 0;
    private bool returnPoint = false;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        if (wayPoints != null && wayPoints.Length > 0 && rBody != null)
        {
            rBody.position = wayPoints[0].transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (wayPoints != null && wayPoints.Length > 1 && rBody != null)
        {
            //Move Forward
            if (!returnPoint)
            {
                int nextPoint = currentPointIndex + 1;

                //Get close enough
                if (Vector2.Distance(transform.position, wayPoints[nextPoint].transform.position) > 0.1f)
                {
                    //make vector to next position
                    Vector2 toVector = Vector2.MoveTowards(transform.position, wayPoints[nextPoint].transform.position, speed * Time.deltaTime);

                    //go to next position
                    rBody.MovePosition(toVector);
                }
                //next index ++
                else
                {
                    rBody.MovePosition(wayPoints[nextPoint].transform.position);
                    ++currentPointIndex;

                    //if this is the last index
                    if (currentPointIndex + 1 >= wayPoints.Length)
                    {
                        returnPoint = true;
                    }
                }
            }
            //go back
            else
            {
                int nextPoint = currentPointIndex - 1;

                //go close enough
                if (Vector2.Distance(transform.position, wayPoints[nextPoint].transform.position) > 0.1f)
                {
                    //make next target distination
                    Vector2 toVector = Vector2.MoveTowards(transform.position, wayPoints[nextPoint].transform.position, speed * Time.deltaTime);

                    //move to next vecotor2
                    rBody.MovePosition(toVector);
                }
                //go back
                else
                {
                    rBody.MovePosition(wayPoints[nextPoint].transform.position);
                    --currentPointIndex;

                    //if this is the first position
                    if (currentPointIndex <= 0)
                    {
                        returnPoint = false;
                    }
                }
            }
        }
    }


}
