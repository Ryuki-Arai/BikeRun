using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FealdGenerator : MonoBehaviour
{
    // フィールド作成のためのパーツへの参照です。
    [SerializeField] GameObject fieldParts;

    // フィールドパーツの親オブジェクトのTransformです。
    [SerializeField] Transform fieldParent;

    [Header("フィールドに関する情報")]
    const int FIELD_X = 1;
    [SerializeField] int fieldSizeZ = 50;
    [SerializeField] int fieldHeight = 20;

    [Header("パーリンノイズに関する情報")]
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
    /// フィールドを生成するメソッドです。
    /// </Summary>
    //void GenerateFieldParts()
    //{
    //    for (float z = 0f; z < fieldSizeZ; z++)
    //    {
    //        // パーリンノイズの座標を指定して値を取得します。
    //        float xValue = xOrigin + FIELD_X * scale;
    //        float yValue = yOrigin + z * scale;
    //        float perlinValue = Mathf.PerlinNoise(xValue, yValue);
    //        float height = fieldHeight * perlinValue;

    //        // 位置のVector3を作成してオブジェクトをインスタンス化します。
    //        Vector3 pos = new Vector3(FIELD_X, height, z);
    //        InstantiateFieldParts(pos);
    //    }
    //}

    IEnumerator GenerateFieldParts()
    {
        int z = 0;
        while (true)
        {
            // パーリンノイズの座標を指定して値を取得します。
            float xValue = xOrigin + FIELD_X * scale;
            float yValue = yOrigin + z * scale;
            float perlinValue = Mathf.PerlinNoise(xValue, yValue);
            float height = fieldHeight * perlinValue;

            // 位置のVector3を作成してオブジェクトをインスタンス化します。
            Vector3 pos = new Vector3(FIELD_X, height, z);
            InstantiateFieldParts(pos);
            z++;
            yield return null;
        }
    }

    /// <Summary>
    /// オブジェクトをインスタンス化するメソッドです。
    /// </Summary>
    void InstantiateFieldParts(Vector3 pos)
    {
        // オブジェクトをインスタンス化します。
        GameObject obj = Instantiate(fieldParts, Vector3.zero, Quaternion.identity);

        // オブジェクトのTransformを設定します。
        obj.transform.SetParent(fieldParent);
        obj.transform.localPosition = pos;
    }
}
