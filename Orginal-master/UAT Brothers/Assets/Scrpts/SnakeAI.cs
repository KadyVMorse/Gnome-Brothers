using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAI : MonoBehaviour
{
    //Integers
    public int curhealth;
    public int maxhealth;

    //Floats
    public float distance;
    public float wakeRange;

    //Booleans
    public bool awake;

    //refernces
    public Animator anim;
    public Transform target;
    public Transform attackPointLeft;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
     void Start()
    {
        curhealth = maxhealth;
    }

    void Update()
    {
        anim.SetBool("Awake", awake);

        RangeCheck();
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance < wakeRange)
        {
            awake = true;
        }
        if(distance > wakeRange)
        {
            awake = false;
        }
    }
}
