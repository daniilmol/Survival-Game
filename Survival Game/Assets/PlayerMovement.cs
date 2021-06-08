using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float speed = 5f;
    private Rigidbody2D playerBody;
    private Vector2 movement;
    private Animator animator;
    private static int playerNumber = 0;
    private AudioSource footstepPlayer;
    [SerializeField] AudioClip[] grassSteps = new AudioClip[30];

    void Start(){
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        footstepPlayer = GetComponent<AudioSource>();
        playerNumber++;
    }
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(movement.x + ", " + movement.y);
        if((movement.x != 0 || movement.y != 0) && !footstepPlayer.isPlaying){
            footstepPlayer.PlayOneShot(grassSteps[Random.Range(0, grassSteps.Length)]);
        }else if(movement.x == 0 && movement.y == 0){
            //footstepPlayer.Stop();
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate() {
        playerBody.MovePosition(playerBody.position + movement * speed * Time.fixedDeltaTime);
        GameObject.Find("Player" + playerNumber + "Camera").transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
    }
}
