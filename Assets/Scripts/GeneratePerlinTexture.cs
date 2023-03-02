using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <Summary>
/// �p�[�����m�C�Y�̃e�N�X�`���𐶐�����N���X�ł��B
/// </Summary>
public class GeneratePerlinTexture : MonoBehaviour
{
    // �e�N�X�`����\������C���[�W�ւ̎Q�Ƃł��B
    public RawImage rawImage;

    // ���������e�N�X�`���ł��B
    Texture2D texture;

    public float xOrigin;
    public float yOrigin;
    public float scale = 0.01f;

    /// <Summary>
    /// �p�[�����m�C�Y�ɂ�鐔��𐶐����܂��B
    /// </Summary>
    /// <param name="length"></param>
    void GeneratePerlinArray(int length)
    {
        List<float> perlinArrayList = new List<float>();
        float y = 0.5f;
        for (int i = 0; i < length; i++)
        {
            // 0����1�܂ł̃p�[�����m�C�Y�̒l���擾���܂��B
            float xValue = xOrigin + i * scale;
            float yValue = yOrigin + y * scale;
            float value = Mathf.PerlinNoise(xValue, yValue);
            perlinArrayList.Add(value);
        }

        GenerateTexture(perlinArrayList);
    }

    /// <Summary>
    /// �����̃��X�g�����Ƀe�N�X�`���𐶐����܂��B
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