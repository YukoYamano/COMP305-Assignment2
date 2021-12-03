using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    //public Vector2 waypoint;
    //public Vector2 waypoint2;
    //private Vector2 currentTarget;

    //public GameObject waypointObj;

    public float moveSpeed = 5.0f;
   // public List<Vector2> waypoints;
    public List<Transform> waypoints;

    private int currentTargetIndex=0;
    
    // Start is called before the first frame update
    void Awake()
    {
        currentTargetIndex = 0;
      /*  waypoints  = new List<Transform>();
        foreach (Transform t in transform.parent.GetChild(1))
        {
            waypoints.Add(t);
        }
       if(waypoints.Count > 0) 
        transform.position = waypoints[0].position;*/
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, waypoints[currentTargetIndex], Time.deltaTime*moveSpeed);
        if(waypoints.Count > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentTargetIndex].position, Time.deltaTime * moveSpeed);


            if (Vector2.Distance(transform.position, waypoints[currentTargetIndex].position) < 0.01f)
            {
                //close enough! Then change my target
                currentTargetIndex = (currentTargetIndex + 1) % waypoints.Count;

            }

        }
    }

  





    /*
    public void AddNewWaypoint()
    {
        GameObject gobj = Instantiate(waypointObj, Vector2.zero, Quaternion.identity);
        gobj.transform.SetParent(transform.parent.GetChild(1));
        gobj.name = "Waypoint" + waypoints.Count;
        waypoints.Add(gobj.transform);
    }
    public void RemoveWaypoint(int index)
    {
        waypoints.RemoveAt(index);
        //waypoints.TrimExcess();
        DestroyImmediate(transform.parent.GetChild(1).GetChild(index));
    }
    public void ClearWaypoints()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            DestroyImmediate(waypoints[i].gameObject);
        }
           waypoints.Clear(); 
    }*/
}
