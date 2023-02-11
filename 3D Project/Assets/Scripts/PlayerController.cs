using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public GameObject projectilePrefab;
    public Quaternion shotLocation;

    public float horizontalInput;
    public float verticalInput;
    public float mouseSpeed;
    public float speed = 10.0f;
    public float xRange = 14.45f;
    public float zRange = 14.45f;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        shotLocation = transform.localRotation; 
        shotLocation.z = 90 ;
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        if(Input.GetMouseButtonDown(0) && !gameOver) {
            Instantiate(projectilePrefab, transform.position, shotLocation);
        }

        if(transform.position.z > zRange && !gameOver) {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        else if(transform.position.z < -zRange && !gameOver) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        else if(transform.position.x < -xRange && !gameOver) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > xRange && !gameOver) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if(!gameOver){
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            mouseSpeed += Input.GetAxis("Mouse X");
            transform.localRotation = Quaternion.Euler(0, mouseSpeed, 0);
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
        if(collision.gameObject.CompareTag("Enemy")) {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
