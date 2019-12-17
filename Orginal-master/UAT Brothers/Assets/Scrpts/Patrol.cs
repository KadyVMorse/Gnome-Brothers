using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //speed and distance of patrol
    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetection;

     void Start()
        //plays mini minotaur noiseat begginning of game
    {
        FindObjectOfType<AudioManager>().Play("Mini");
    }
    void Update()
    {
        //creats a ray cast and ground check so it can patrol only that area
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //detcts the ground so the enmy doesn't walk past it 
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down , distance);


        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                //if not moving right then it will go left
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                //if not moving left then it will go right 
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
