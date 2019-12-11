using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathZone : MonoBehaviour
{

        void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        //Reload to the begging of the Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    
}
