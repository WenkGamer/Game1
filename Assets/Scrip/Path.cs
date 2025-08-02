using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public static List<Vector3> waypoints = new List<Vector3>();
   

    void Awake()
    {
        waypoints.Clear();
       
        foreach (Transform child in transform)
        {
            waypoints.Add(child.position);
        }
        
    }
}
