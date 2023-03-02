using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FealdGenerator : MonoBehaviour
{
    [SerializeField] GameObject _ground;
    [SerializeField] Vector3 _currentPos;
    [SerializeField] int _instabilityY;
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
        while (true)
        {
            Instantiate(_ground,new Vector3(_currentPos.x,_currentPos.y + Random.Range(-_instabilityY,_instabilityY),_currentPos.z),Quaternion.identity);
            yield return new WaitForSeconds(_generatInterval);
        }
    }
}
