using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlantform : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float fallDelay;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb2d.isKinematic = false;
        GetComponent < Collider2D>().isTrigger = true;
        yield return 0;
    }
}
