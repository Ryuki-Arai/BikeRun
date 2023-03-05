using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField,Tooltip("フィールドのプレハブ")] GameObject fieldParts;

    [SerializeField,Tooltip("親オブジェクト")] Transform fieldParent;

    [Header("フィールドに関する情報")]
    float fieldX = 1f;
    [SerializeField] int fieldHeight = 20;
    [SerializeField,Tooltip("シーン上に出現させる最大数")] int maxFieldSpawn;

    [Header("パーリンノイズに関する情報")]
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
        while (fieldParent.childCount <= maxFieldSpawn)
        {
            // パーリンノイズの座標を指定して値を取得します。
            var xValue = xOrigin + fieldX * noizeScale;
            var zValue = zOrigin + fieldZ * noizeScale;
            var perlinValue = Mathf.PerlinNoise(xValue, zValue);
            var height = fieldHeight * perlinValue;

            // 位置のVector3を作成してオブジェクトをインスタンス化します。
            var pos = new Vector3(fieldX, height, fieldZ);
            InstantiateFieldParts(pos);
            fieldZ += fieldParts.transform.localScale.z;
            yield return null;
        }
    }

    /// <Summary>
    /// オブジェクトをインスタンス化するメソッドです。
    /// </Summary>
    void InstantiateFieldParts(Vector3 pos)
    {
        // オブジェクトをインスタンス化します。
        var obj = Instantiate(fieldParts, pos, Quaternion.identity);

        // オブジェクトのTransformを設定します。
        obj.transform.SetParent(fieldParent);
    }
}
