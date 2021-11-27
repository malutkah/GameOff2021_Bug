using Newtonsoft.Json;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    private Highscore highscore = new Highscore();

    public Highscore GetHighscore()
    {
        return highscore;
    }

    Highscore InitializeHighscore()
    {
        // load json file

        highscore = new Highscore();

        try
        {
            // deserialize json file
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }

        return highscore;
    }

    public void SaveHighscore(Highscore highscore)
    {
        // serialize highscore
        highscore = new Highscore()
        {
            score = GameManager.instance.score
        };

        string highscoreText = JsonUtility.ToJson(highscore);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/YourHighscore.json", highscoreText);
    }
}