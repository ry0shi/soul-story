using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    float horInput;
    float vertInput;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        speed = sprintSpeed;
        else if (!Input.GetKey(KeyCode.LeftShift))
        speed = walkSpeed;
        horInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        vertInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(horInput, vertInput, 0));
    }
}
