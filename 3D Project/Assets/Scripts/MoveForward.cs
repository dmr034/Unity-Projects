using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    private float range = 14.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if(transform.position.z > range || transform.position.z < -range || transform.position.x > range || transform.position.x < -range) {
            Destroy(gameObject);
        }
    }
}
