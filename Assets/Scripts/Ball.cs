using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    [SerializeField] float moveSpeed = 12f;
    public Rigidbody rb;
    Vector2 moveInput;
    Transform spawnPoint;
    public GameObject ballControlsUI;

    void Awake(){
        GetComponent<PlayerInput>().enabled = true;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        spawnPoint = gameObject.transform;
    }

    void FixedUpdate(){
        Move();
    }

    void Update(){
        if(!GetComponent<PlayerInput>().enabled && rb.velocity == Vector3.zero){
             rb.AddForce(new Vector3(Random.Range(-5f, 5f), 0, 0));
        }
    }

    void Move(){
        //Vector3 velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y * moveSpeed, moveInput.y * moveSpeed);
        // = transform.TransformDirection(velocity);
        if(moveInput.x == -1){
            rb.AddForce(-moveSpeed, 0, 0);
        }else if(moveInput.x == 1){
            rb.AddForce(moveSpeed, 0, 0);
        }
    }

    void OnMovement(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void OnDrop(){
        GetComponent<PlayerInput>().enabled = false;
        ballControlsUI.SetActive(false);
        rb.velocity = new Vector3(0, 0, 0);
        rb.useGravity = true;
    }

    public Transform GetSpawnPoint(){
        return spawnPoint;
    }

    //Buttons || Mobile
    public void MoveLeft(){
        rb.AddForce(-moveSpeed * 15, 0, 0);
    }
    public void MoveRight(){
        rb.AddForce(moveSpeed * 15, 0, 0);
    }
    public void StopMovement(){
        rb.velocity = new Vector3(0, 0, 0);
    }
    public void Drop(){
        GetComponent<PlayerInput>().enabled = false;
        ballControlsUI.SetActive(false);
        rb.velocity = new Vector3(0, 0, 0);
        rb.useGravity = true;
    }

}
