using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
     public float turnSpeed = 4.0f;
     public Transform camTarget;
 
     private float pLerp = .2f;
     private float rLerp = .1f;
 
 
     void Update()
     {
         transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
         transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
     }
}
