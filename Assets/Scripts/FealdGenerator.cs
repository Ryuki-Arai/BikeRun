using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FealdGenerator : MonoBehaviour
{
    [SerializeField] GameObject _ground;
    [SerializeField] Vector3 _currentPos;
    [SerializeField] int _generatInterval;
    [SerializeField] int _holeProbability;

    void Start()
    {
        StartCoroutine(FealdGenerate());
    }

    void Update()
    {
        
    }

    IEnumerator FealdGenerate()
    {
        do
        {
            Instantiate(_ground,_currentPos,Quaternion.identity);
            yield return new WaitForSeconds(_generatInterval);
        }while(true);
    }
}
