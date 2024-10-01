using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampInside : MonoBehaviour
{
    public Transform target;
    [SerializeField] float radius = 5;
    Vector3 center;
    [SerializeField] float distance;

    void FixedUpdate()
    {
        center = target.position;
        distance = Vector3.Distance(this.transform.position, center);

        if (distance > radius)
        {
            Vector3 OriginToObject = this.transform.position - center;
            OriginToObject *= radius / distance;
            this.transform.position = center + OriginToObject;
        }
    }
}
