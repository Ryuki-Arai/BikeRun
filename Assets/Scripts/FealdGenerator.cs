using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FealdGenerator : MonoBehaviour
{
    // �t�B�[���h�쐬�̂��߂̃p�[�c�ւ̎Q�Ƃł��B
    [SerializeField] GameObject fieldParts;

    // �t�B�[���h�p�[�c�̐e�I�u�W�F�N�g��Transform�ł��B
    [SerializeField] Transform fieldParent;

    [Header("�t�B�[���h�Ɋւ�����")]
    const int FIELD_X = 1;
    [SerializeField] int fieldSizeZ = 50;
    [SerializeField] int fieldHeight = 20;

    [Header("�p�[�����m�C�Y�Ɋւ�����")]
    [SerializeField] float xOrigin;
    [SerializeField] float yOrigin;
    [SerializeField] float scale = 0.05f;

    void Start()
    {
        StartCoroutine(GenerateFieldParts());
    }

    void Update()
    {
        
    }

    /// <Summary>
    /// �t�B�[���h�𐶐����郁�\�b�h�ł��B
    /// </Summary>
    //void GenerateFieldParts()
    //{
    //    for (float z = 0f; z < fieldSizeZ; z++)
    //    {
    //        // �p�[�����m�C�Y�̍��W���w�肵�Ēl���擾���܂��B
    //        float xValue = xOrigin + FIELD_X * scale;
    //        float yValue = yOrigin + z * scale;
    //        float perlinValue = Mathf.PerlinNoise(xValue, yValue);
    //        float height = fieldHeight * perlinValue;

    //        // �ʒu��Vector3���쐬���ăI�u�W�F�N�g���C���X�^���X�����܂��B
    //        Vector3 pos = new Vector3(FIELD_X, height, z);
    //        InstantiateFieldParts(pos);
    //    }
    //}

    IEnumerator GenerateFieldParts()
    {
        int z = 0;
        while (true)
        {
            // �p�[�����m�C�Y�̍��W���w�肵�Ēl���擾���܂��B
            float xValue = xOrigin + FIELD_X * scale;
            float yValue = yOrigin + z * scale;
            float perlinValue = Mathf.PerlinNoise(xValue, yValue);
            float height = fieldHeight * perlinValue;

            // �ʒu��Vector3���쐬���ăI�u�W�F�N�g���C���X�^���X�����܂��B
            Vector3 pos = new Vector3(FIELD_X, height, z);
            InstantiateFieldParts(pos);
            z++;
            yield return null;
        }
    }

    /// <Summary>
    /// �I�u�W�F�N�g���C���X�^���X�����郁�\�b�h�ł��B
    /// </Summary>
    void InstantiateFieldParts(Vector3 pos)
    {
        // �I�u�W�F�N�g���C���X�^���X�����܂��B
        GameObject obj = Instantiate(fieldParts, Vector3.zero, Quaternion.identity);

        // �I�u�W�F�N�g��Transform��ݒ肵�܂��B
        obj.transform.SetParent(fieldParent);
        obj.transform.localPosition = pos;
    }
}
