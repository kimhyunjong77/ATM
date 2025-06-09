using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UserData userData;

    private string savePath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Path.Combine(Directory.GetCurrentDirectory(), "userdata.json");
        LoadUserData();
    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("저장 완료: " + savePath);
    }

    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("불러오기 완료");
        }
        else
        {
            // 초기값 세팅
            userData = new UserData("김현종", 100000, 50000);
            SaveUserData(); // 기본값 저장
        }
    }
}
