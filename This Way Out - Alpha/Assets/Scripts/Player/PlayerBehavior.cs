using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Game Manager
    private GameObject gm;
    
    // Player options
    public float moveSpeed;
    private float dashCoolDown = 0;

    // Animations
    private Animator animator;

    // External
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

    void Awake()
    {   
        // Get the game manager
        gm = GameObject.FindWithTag("GameManager");

        // Get the animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {   
        Debug.Log(Time.time);
        // Handle walking movements
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("isWalking", true);
            Move();
        } 
        else 
        {
            animator.SetBool("isWalking", false);
        }

    }

    void Move() 
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        animator.SetFloat("walkHorizontal", x);
        animator.SetFloat("walkVertical", y);   
        transform.position += new Vector3(x, y, 0);

        if (Input.GetAxis("Jump") != 0 && (Time.time - dashCoolDown) >= 3) 
        {
            transform.position += new Vector3(x*5, y*5, 0);
            dashCoolDown = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Frog" ||
            col.gameObject.tag == "Arrow")
        {
            gm.SendMessage("UpdateHealth", -1);
            if (col.gameObject.tag == "Arrow")
            {
                Destroy(col.gameObject);
            }
        }
    }

    public void PlayWalkAudio()
    {
      // play movement sound
      audioSource.PlayOneShot(audioClipArray[0]);
    }

}
