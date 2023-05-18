using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveRandomText : MonoBehaviour
{
    static readonly string[] WORD_LIST = new string[]
    {
    "사랑",
    "여행",
    "꿈",
    "자유",
    "즐거움",
    "도전",
    "성공",
    "자연",
    "휴식",
    "지식",
    "창의성",
    "우정",
    "건강",
    "희망",
    "인생",
    "모험",
    "평화",
    "성장",
    "문화",
    "행복",
    };

    private string _filePath;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            // GenerateRandomWords();
            StartCoroutine(SaveText());
        }
    }

    private void GenerateRandomWords()
    {
        string[] randomWords = GetRandomWords(10);
        //wordText.text = string.Join(", ", randomWords);
        SaveWordsToFile(randomWords);
    }

    private string[] GetRandomWords(int count)
    {
        string[] randomWords = new string[count];
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, WORD_LIST.Length);
            randomWords[i] = WORD_LIST[index];
        }
        return randomWords;
    }

    private void SaveWordsToFile(string[] words)
    {
        // string filePath = Path.Combine(Application.persistentDataPath, "SaveText");
        string folderPath = Path.Combine(Application.dataPath, "GameData", "SaveText.txt");
        // if (!Directory.Exists(folderPath))
        // {
        //     Directory.CreateDirectory(folderPath);
        // }
        File.WriteAllLines(folderPath, words);
        Debug.Log(" 단어 저장 " + folderPath);

        // string folderPath = Path.Combine(Application.persistentDataPath, "SaveText");
        // if (!Directory.Exists(folderPath))
        // {
        //     Directory.CreateDirectory(folderPath);
        // }

        // string filePath = Path.Combine(folderPath, _filePath);
        // File.WriteAllLines(filePath, words);
        // Debug.Log(" 단어 저장 " + filePath);
    }

    IEnumerator SaveText()
    {
        yield return new WaitForEndOfFrame();
        GenerateRandomWords();

        // string filePath = Path.Combine(Application.persistentDataPath, "SaveText");
        string folderPath = Path.Combine(Application.dataPath, "GameData", "SaveText");
        // string filePath = Path.Combine(folderPath, filePath);
        Debug.Log("단어 출력 : " + string.Join(", ", WORD_LIST));
        Debug.Log("FilePath: " + folderPath);
    }
}
