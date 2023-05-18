using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class ScreenShot : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] string _screenShotName;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeScreenShot();
        }
    }
    private IEnumerator ScreenShotClick()
    {
        yield return new WaitForEndOfFrame();
        RenderTexture renderTexture = _cam.targetTexture;
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
        RenderTexture.active = renderTexture;

        // 화면 크기
        Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
        texture.ReadPixels(rect, 0, 0);
        texture.Apply();

        byte[] byteArray = texture.EncodeToPNG();
        //Destroy(texture);

        string directoryPath = Path.Combine(Application.dataPath, "GameData", "ScreenShots");
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // 경로 설정
        string fileName = _screenShotName + "_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        string filePath = Path.Combine(directoryPath, fileName);
        File.WriteAllBytes(filePath, byteArray);

        Debug.Log("스크린샷이 저장되었습니다. 경로: " + filePath);

    }
    void TakeScreenShot()
    {
        StartCoroutine(ScreenShotClick());
    }
}
