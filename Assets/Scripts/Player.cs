using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("�W�����v��")] int _jumpPower;
    [SerializeField,Tooltip("�A���W�����v�ł����")] int _jumpMaxCount;
    int _count;
    Rigidbody _rb;


    void OnEnable()
    {
        _count = _jumpMaxCount;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_count > 0)
            {
                _count--;
                _rb.velocity = Vector3.zero;
                _rb.AddForce(_jumpPower * transform.up, ForceMode.Impulse);
                Debug.Log($"jump�F�c��{_count}��");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _count = _jumpMaxCount;
        Debug.Log($"���Z�b�g�F�c��{_count}��");
    }
}
