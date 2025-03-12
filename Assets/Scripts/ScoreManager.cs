using System.IO;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
	public static ScoreManager Instance { get; private set; }
	public string CurrentUserName { get; private set; }
	public string BestScoreUserName { get; private set; }
	public int BestScore { get; private set; }
	void Awake()
	{
		// start of new code
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		// end of new code

		Instance = this;
		DontDestroyOnLoad(gameObject);
		LoadScore();
	}
	void Start()
	{
		BestScore = 0;
		BestScoreUserName = "";
	}

	[System.Serializable]
    public class SaveData
    {
        public string BestScoreUserName;
        public int BestScore;
    }

	public void SetCurrentUserToBestScore(int score)
	{
		BestScoreUserName = CurrentUserName;
		BestScore = score;
	}
	public void SetCurrentUserName(string name)
	{
		CurrentUserName = name;
	}

    // Save method
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.BestScoreUserName = BestScoreUserName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // Load method
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
			
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestScoreUserName = data.BestScoreUserName;
            BestScore = data.BestScore;
        }
				
    }
}
