using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed;
    [SerializeField] [Range(0.01f,1f)] // ! 

    private Vector3 velocity = Vector3.zero;
  
    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y + offset.y, target.position.z + offset.z);
        transform.position =Vector3.SmoothDamp(transform.position,desiredPosition,ref velocity,smoothSpeed);// ! 
        //transform.position = desiredPosition;
        //transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed); // kameradaki x i belirli aralýklara alman gerek 

    }
}
