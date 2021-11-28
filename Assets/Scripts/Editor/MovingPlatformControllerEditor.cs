using UnityEngine;
using UnityEditor;

/*[CustomEditor(typeof(MovingPlatformController))]
public class MovingPlatformControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MovingPlatformController controller = (MovingPlatformControllerEditor) target;

        controller.waypointObj = (GameObject)EditorGUILayout.FloatField("Waypoint object: ", controller.waypointObj, typeof(GameObject), false);
        controller.movespeed = EditorGUILayout.FloatField("Speed", controller.moveSpeed);

        EditorGUILayout.LabelField("waypoints", EditorStyles.boldLabel);

        if (controller.waypoints != null && controller.waypoints.Count !=0)
        {
            for (int i = 0; i < controller.waypoints.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                controller.waypoints[i].gameObject.name = EditorGUILayout.TextField(controller.waypoints[i].gameObject.name);
                EditorGUILayout.Vector2Field(" " + i, controller.waypoints[i].position);
                if (GUILayout.Button("Delete?"))
                {
                    //Remove specific waypoint
                }
                EditorGUILayout.EndHorizontal();    
            }
        }

        
        if(GUILayout.Button("Add waypoint"))
        {
           controller.AddNewWaypoint();
        
        }
        if(GUILayout.Button("Clear Waypoints"))
        {
            controller.ClearWaypoints();
        }
        
        //base.OnInspectorGUI();
    }
}
*/