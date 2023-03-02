using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <Summary>
/// パーリンノイズのテクスチャを生成するクラスです。
/// </Summary>
public class GeneratePerlinTexture : MonoBehaviour
{
    // テクスチャを表示するイメージへの参照です。
    public RawImage rawImage;

    // 生成したテクスチャです。
    Texture2D texture;

    public float xOrigin;
    public float yOrigin;
    public float scale = 0.01f;

    /// <Summary>
    /// パーリンノイズによる数列を生成します。
    /// </Summary>
    /// <param name="length"></param>
    void GeneratePerlinArray(int length)
    {
        List<float> perlinArrayList = new List<float>();
        float y = 0.5f;
        for (int i = 0; i < length; i++)
        {
            // 0から1までのパーリンノイズの値を取得します。
            float xValue = xOrigin + i * scale;
            float yValue = yOrigin + y * scale;
            float value = Mathf.PerlinNoise(xValue, yValue);
            perlinArrayList.Add(value);
        }

        GenerateTexture(perlinArrayList);
    }

    /// <Summary>
    /// 引数のリストを元にテクスチャを生成します。
    /// </Summary>
    /// <param name="length"></param>
    void GenerateTexture(List<float> valueList)
    {
        int texWidth = valueList.Count;
        int texHeight = (int)rawImage.rectTransform.sizeDelta.y;
        texture = new Texture2D(texWidth, texHeight);
        Color[] colorArray = new Color[texWidth * texHeight];

        for (int i = 0; i < texWidth * texHeight; i++)
        {
            colorArray[i] = Color.white;
        }

        for (int i = 0; i < valueList.Count; i++)
        {
            int y = Mathf.RoundToInt(valueList[i] * 100);
            Color col = Color.black;
            colorArray[i + texWidth * y] = col;
        }

        texture.SetPixels(colorArray);
        texture.Apply();
        rawImage.texture = texture;
    }

    public void OnPressedPerlinButton()
    {
        int width = (int)rawImage.rectTransform.sizeDelta.x;
        GeneratePerlinArray(width);
    }
}