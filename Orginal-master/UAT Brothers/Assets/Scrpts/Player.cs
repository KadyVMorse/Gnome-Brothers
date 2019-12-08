using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Varibles

        //Floats
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    //Booleans
    public bool grounded;
    public bool canDoubleJump;
    public bool canMove;
    public bool wallSliding;
    public bool wallCheck;
    public bool facingRight = true;


    //Stats
    public int curHealth;
    public int maxHealth = 5;

    //Refrences
    private Rigidbody2D rb2d;
    private Animator anim;
    private gameMaster gm;
    public Transform wallCheckpoint;
    public LayerMask walllayerMask;


    // Start is called before the first frame update
    void Start()
    {
        //gets the Rigibody2d and Animator
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        //current health is equal to the max health 
        curHealth = maxHealth;
        //Finds the componet of Game Master
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        //Setting the boolen of Grounded and Speed
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (!canMove)
        {
            rb2d.velocity = Vector2.zero;
            return;
        }
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        if (Input.GetButtonDown("Jump") && !wallSliding)
        {
            if (grounded)
            {
                //Regular jump that can lead into double jump 
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                // Can double jump and multiplys the power of jump
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower);
                }

            }
        }
        //Current Health = Max Health 
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        //If the Curhealth is less than the max ealth which is five then the player will die
        if (curHealth <= 0)
        {
            Die();
        }
        if (!grounded)
        {
            wallCheck = Physics2D.OverlapCircle(wallCheckpoint.position, 0.1f, walllayerMask);
            
            if(facingRight && Input.GetAxis("Horizontal")> 0.1f || !facingRight && Input.GetAxis("Horizontal") <0.1f)
            {
                if (wallCheck)
                {
                    HandleWallSliding();
                }
            }

        }
        if(wallCheck == false || grounded)
        {
            wallSliding = false;
        }
    }

    void HandleWallSliding()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, -0.7f);


        wallSliding = true;

        if (Input.GetButtonDown("Jump"))
        {
            if (facingRight)
            {
                rb2d.AddForce(new Vector2(-1.5f, 3) * jumpPower);
            }
            else
            {
                rb2d.AddForce(new Vector2(1.5f, 3) * jumpPower);
            }
        }

    }



    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //moving the player
        if (grounded)
        {
            rb2d.AddForce((Vector2.right * speed) * h);
        }
        else
        {
            rb2d.AddForce((Vector2.right * speed/2) * h);
        }

        //Limiting the Speed oof the player
        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }
    void Die()
    {
        //Restart Level When player dies
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        FindObjectOfType<AudioManager>().Play("PlayerDeath");
    }
    public void Damage(int dmg)
    {
        // damage done by spikes
        curHealth -= dmg;

        //Plays the animation 
        gameObject.GetComponent<Animation>().Play("Player_RedFlash");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //If player enters the trigger box for gems then it willl find the gem object and add +1
        if (col.CompareTag("Gem"))
        {
            FindObjectOfType<AudioManager>().Play("Gem");
            Destroy(col.gameObject);
            gm.gems += 1;
        }
    }
    // Knockback when player hits the spikes and represnts the Duration Power and Direction of it 
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        FindObjectOfType<AudioManager>().Play("PlayerHit");
        float timer = 0;

        while (knockDur > timer)
        {

            timer += Time.deltaTime;

            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y + knockbackPwr, transform.position.z));
        }
        yield return 0;
    }
}
