using System;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float power = 50;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.TransformDirection(Vector3.forward) * power, ForceMode.Impulse);

        Invoke("clean",3);
    }

    void OnCollisionEnter(Collision other){
        Destroy(gameObject);
    }

    void clean(){
        Destroy(gameObject);
    }
}
