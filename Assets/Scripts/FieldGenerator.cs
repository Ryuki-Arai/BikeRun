using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField,Tooltip("�t�B�[���h�̃v���n�u")] GameObject fieldPrefab;

    [SerializeField,Tooltip("�e�I�u�W�F�N�g")] Transform fieldParent;

    [Header("�t�B�[���h�Ɋւ�����")]
    [SerializeField] int fieldX = 0;
    [SerializeField] int fieldHeight = 20;
    [SerializeField,Tooltip("�V�[����ɏo��������ő吔(0�Ő�������)")] int maxFieldSpawn;

    [Header("�p�[�����m�C�Y�Ɋւ�����")]
    [SerializeField] float xOrigin;
    [SerializeField] float zOrigin;
    [SerializeField] float noizeScale = 0.05f;

    void Start()
    {
        StartCoroutine(GenerateFieldParts());
    }

    IEnumerator GenerateFieldParts()
    {
        float fieldZ = 0;
        while (fieldParent.childCount <= maxFieldSpawn || maxFieldSpawn <= 0)
        {
            // �p�[�����m�C�Y�̍��W���w�肵�Ēl���擾���܂��B
            var xValue = xOrigin * noizeScale;
            var zValue = zOrigin + fieldZ * noizeScale;
            var perlinValue = Mathf.PerlinNoise(xValue, zValue);
            var height = fieldHeight * perlinValue;

            // �ʒu��Vector3���쐬���ăI�u�W�F�N�g���C���X�^���X�����܂��B
            var pos = new Vector3(fieldX, height, fieldZ);
            InstantiateFieldParts(pos);
            fieldZ += fieldPrefab.transform.localScale.z;
            yield return null;
        }
    }

    /// <Summary>
    /// �I�u�W�F�N�g���C���X�^���X�����郁�\�b�h�ł��B
    /// </Summary>
    void InstantiateFieldParts(Vector3 pos)
    {
        // �I�u�W�F�N�g���C���X�^���X���B
        var obj = Instantiate(fieldPrefab, fieldParent);
        // �I�u�W�F�N�g��Position��ݒ�B
        obj.transform.position = pos;
    }
}
