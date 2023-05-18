using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCount : MonoBehaviour
{
    [SerializeField] private Text _CountText;

    private int playCount;

    private void Start()
    {
        // PlayerPrefs에서 저장된 Play Count를 로드합니다.
        playCount = PlayerPrefs.GetInt("PlayCount", 0);
        
        // 텍스트 UI에 Play Count를 표시합니다.
        UpdatePlayCountText();
        
        // 게임 시작 시마다 Play Count를 1 증가시킵니다.
        IncreasePlayCount();
    }

    private void OnDestroy()
    {
        // 게임 종료 시에 Play Count를 저장합니다.
        PlayerPrefs.SetInt("PlayCount", playCount);
        PlayerPrefs.Save();
    }

    private void IncreasePlayCount()
    {
        playCount++;
        UpdatePlayCountText();
    }

    private void UpdatePlayCountText()
    {
        _CountText.text = "Play Count: \n" + playCount.ToString();
    }
}
