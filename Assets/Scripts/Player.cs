using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("ジャンプ力")] int _jumpPower;
    [SerializeField,Tooltip("連続ジャンプできる回数")] int _jumpMaxCount;
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
                Debug.Log($"jump：残り{_count}回");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _count = _jumpMaxCount;
        Debug.Log($"リセット：残り{_count}回");
    }
}
