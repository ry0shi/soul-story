using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haunter : MonoBehaviour
{
    [SerializeField] public GameObject hauntedObject;
    [SerializeField] GameObject LimitCirclePrefab;
    ClampInside clamp;

    void Start()
    {
        clamp = GetComponent<ClampInside>();
    }

    void Update()
    {
        if (hauntedObject != null)
        this.transform.position = hauntedObject.transform.position;

        if (Input.GetKeyDown(KeyCode.X) && hauntedObject != null)
        Unhaunt();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Puppet" && hauntedObject == null)
        {
            for (int i = 0; i < 2; i++)
            Destroy(GameObject.FindWithTag("LimitCircle"));

            hauntedObject = other.gameObject;
            clamp.target = hauntedObject.transform;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Movement>().enabled = false;
            this.transform.position = hauntedObject.transform.position;
        }
    }

    void Unhaunt()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Movement>().enabled = true;
        Instantiate(LimitCirclePrefab, this.transform.position, this.transform.rotation, hauntedObject.transform);
        clamp.target = hauntedObject.transform;
        hauntedObject = null;

    }
}

// Unused code parts (yet):
//
// Instantiate(LimitCirclePrefab); - used
// GameObject.Find("LimitCircle").transform.SetParent(hauntedObject.transform);
