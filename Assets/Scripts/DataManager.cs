using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int HiScore;
    private string m_HiScorePlayerName;
    public string HiScorePlayerName
    {
        get 
        {
            if(string.IsNullOrEmpty(m_HiScorePlayerName))
            {
                return "Nobody!";
            }
            return m_HiScorePlayerName;
        }
        set
        {
            m_HiScorePlayerName = value;
        }
    }
    public string CurrentPlayerName;

    private string m_SaveDataPath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        m_SaveDataPath = Application.persistentDataPath + "/savedata.json";

        LoadHiScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int HiScore;
        public string PlayerName;
    }

    public void SaveHiScore()
    {
        SaveData saveData = 
            new SaveData { 
                HiScore = HiScore, 
                PlayerName = HiScorePlayerName };

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(m_SaveDataPath, json);
    }

    public void LoadHiScore()
    {
        if(File.Exists(m_SaveDataPath))
        {
            string json = File.ReadAllText(m_SaveDataPath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            HiScorePlayerName = saveData.PlayerName;
            HiScore = saveData.HiScore;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        SaveHiScore();
    }
}
