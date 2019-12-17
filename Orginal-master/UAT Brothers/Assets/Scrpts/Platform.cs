using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //moves the platform to a certain postion and speed
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    // Start is called before the first frame update
    //platform goes to next postion
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if in postion 1 them it will go to postion 2
        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        // if in postion 2 it will go into postion 1
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        //controls the speed and the time traveling between the two point
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    //draws gizmo in editor so you can edit it
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
