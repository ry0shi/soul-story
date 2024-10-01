using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothTime = 0.3f;

    private Vector3 velocity;
    public float translationFactor = 20;

    void LateUpdate(){
        if(transform.position != target.position) 
        {
            transform.position += (target.position - transform.position) / translationFactor;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);           
        }
    }
}
