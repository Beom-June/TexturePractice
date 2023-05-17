using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureEx : MonoBehaviour
{
    [SerializeField] Material _material = null;
    [SerializeField] RenderTexture _renderTexture = null;
    void Update()
    {
        // _renderTexture를 _material의 Main Texture에 할당
        _material.mainTexture = _renderTexture;

    }
}
