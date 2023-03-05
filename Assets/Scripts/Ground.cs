using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] int _moveSpeed;
    [SerializeField] int _deletePosZ;
    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector3(0, 0, _moveSpeed * -1);
        if(transform.position.z <= _deletePosZ) Destroy(gameObject);
    }
}
