using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{
    [SerializeField] RawImage _rawImg = null;
    [SerializeField] Texture _brushTexure = null;
    [SerializeField] RenderTexture _renderTexture = null;

    // 밑에 세개는 스티커 붙히기에 쓰기
    [SerializeField] SkinnedMeshRenderer _renderSkinned = null;
    [SerializeField] Mesh _mesh = null;
    [SerializeField] MeshCollider _col = null;

    [SerializeField] private GameObject spriteTeeth; // 생성할 스프라이트 프리팹

    [SerializeField] float brushSize = 128.0f;



        private bool isDragging;

    private void Awake()
    {
        _renderTexture = new RenderTexture(512, 512, 32, RenderTextureFormat.ARGB32);
        _rawImg.texture = _renderTexture;
    }
    private void Start()
    {
    }
    void Update()
    {
        Draw();


    }
    void Draw()
    {
        if (Input.GetMouseButton(0))
        {

            var mousePosition = Input.mousePosition;
            var texSize = 512;


            GL.PushMatrix();                            // push 해서 그릴 것 넣어줌
            GL.LoadPixelMatrix(0, texSize, texSize, 0);

            var activeRt = RenderTexture.active;
            RenderTexture.active = _renderTexture;

            var screenX = mousePosition.x - 150f;
            var screenY = Screen.height - mousePosition.y;
            var screenRect = new Rect(screenX - brushSize / 2f, screenY - brushSize / 2f, brushSize, brushSize);

            Graphics.DrawTexture(screenRect, _brushTexure);

            RenderTexture.active = activeRt;
            GL.PopMatrix();
        }
    }
    public void MargentaColorChange()
    {
        // 빨간색 브러시 생성
        Texture2D redBrushTexture = new Texture2D(1, 1);
        redBrushTexture.SetPixel(0, 0, Color.magenta);
        redBrushTexture.Apply();

        // _brushTexture에 redBrushTexture 할당
        _brushTexure = redBrushTexture;
    }
    public void BlueColorChange()
    {
        // 빨간색 브러시 생성
        Texture2D redBrushTexture = new Texture2D(1, 1);
        redBrushTexture.SetPixel(0, 0, Color.blue);
        redBrushTexture.Apply();

        // _brushTexture에 redBrushTexture 할당
        _brushTexure = redBrushTexture;
    }
    public void GreenColorChange()
    {
        // 빨간색 브러시 생성
        Texture2D redBrushTexture = new Texture2D(1, 1);
        redBrushTexture.SetPixel(0, 0, Color.green);
        redBrushTexture.Apply();

        // _brushTexture에 redBrushTexture 할당
        _brushTexure = redBrushTexture;
    }

    // 스티커 관련
    public void ClickTeeth()
    {
        Debug.Log("fff");
        Camera mainCamera = Camera.main; // 혹은 다른 방법으로 카메라를 가져옵니다.

        Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward; // 생성 위치 계산
        Quaternion spawnRotation = mainCamera.transform.rotation; // 생성 회전값

        Instantiate(spriteTeeth, spawnPosition, spawnRotation);
    }
}