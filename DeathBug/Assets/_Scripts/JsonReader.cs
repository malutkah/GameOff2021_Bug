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

}