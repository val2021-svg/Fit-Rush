using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatofrm : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int i = 0; // currentwaypointsIndex
    private float speed = 3f;


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[i].transform.position, transform.position) < .1f) {
            i++;
            if (i >= waypoints.Length) {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[i].transform.position, Time.deltaTime * speed);
    }
}
