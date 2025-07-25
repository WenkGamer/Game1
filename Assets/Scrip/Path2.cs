using System.Collections.Generic;
using UnityEngine;

public class Path2 : MonoBehaviour
{
    public static List<Vector3> waypoints2 = new List<Vector3>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        waypoints2.Clear();

        
        foreach (Transform child in transform)
        {
            waypoints2.Add(child.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
