using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI display;
    
    const string FILE_DIR = "/DATA/";
    const string DATA_FILE = "JSONHighScores.json";
    string FILE_FULL_PATH;
    
    public int score;
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;

            if (isHighScore(score))
            {
                int highScoreSlot = -1;

                for (int i = 0; i < HighScores.Count; i++)
                {
                    if (score > highScores[i])
                    {
                        highScoreSlot = i;
                        break;
                    }
                }
                
                highScores.Insert(highScoreSlot, score);

                highScores = highScores.GetRange(0, 5);

                string scoreBoardText = "";

                foreach (var highScore in highScores)
                {
                    scoreBoardText += highScore + "\n";
                }

                highScoresString = scoreBoardText;
                
                File.WriteAllText(FILE_FULL_PATH, highScoresString);
            }
        }

    }
    
    private Dictionary<string, int> highScores;
    string highScoresString = "";
    public Dictionary<string, int> HighScores
    {
        get
<<<<<<< HEAD
        {// When try to get the highscore info
            if (highScores != null && File.Exists(FILE_FULL_PATH))
            {
                Debug.Log("got from file");
                // Initiate new dictionary
                highScores = new Dictionary<string, int>();
                //******************************************************
                // Get highscores record from the saved file
=======
        {
            if (highScores == null)
            {
                highScores = new List<int>();

>>>>>>> parent of 2eada4f (Revised the bug)
                highScoresString = File.ReadAllText(FILE_FULL_PATH);
                
                //highScoresString = highScoresString.Trim();
                
                //string[] highScoreArray = highScoresString.Split("\n");

                //for (int i = 0; i < highScoreArray.Length; i++)
                //{
                //    int currentScore = Int32.Parse(highScoreArray[i]);
                //    highScores.Add(currentScore);
                //}
            }
<<<<<<< HEAD
            // when try to get highscores for the first time:
            else if(highScores == null)
            {
                Debug.Log("NOPE");
                // initiate a new dictionary for highscores
                highScores = new Dictionary<string, int>();
                highScores.Add("player", 0);
            }
=======
>>>>>>> parent of 2eada4f (Revised the bug)

            return highScores;
        }
    }

    float timer = 0;

    public int maxTime = 10;

    bool isInGame = true;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        FILE_FULL_PATH = Application.dataPath + FILE_DIR + DATA_FILE;
    }
    
    void Update()
    {
        if (isInGame)
        {
            display.text = "Score: " + score + "\nTime:" + (maxTime - (int)timer);
        }
        else
        {
            display.text = "GAME OVER\nFINAL SCORE: " + score +
                           "\nHigh Scores:\n" + highScoresString;
        }

        //add the fraction of a second between frames to timer
        timer += Time.deltaTime; 
        
        //if timer is >= maxTime
        if (timer >= maxTime && isInGame)
        {
            isInGame = false;
            SceneManager.LoadScene("EndScene");
        }
    }

<<<<<<< HEAD
    // When time is over, compare the score to the highscores
    bool IsHighScore(int score)
=======
    bool isHighScore(int score)
>>>>>>> parent of 2eada4f (Revised the bug)
    {
        foreach (int highScore in highScores.Values)
        {
            if (score > highScore)
            {
                return true;
            }
<<<<<<< HEAD
        }return false;
    }                
    
    // When there is a highscore, add it to the file
    void SetHighScore()
    {
        if (IsHighScore(score))
        {
            int highScoreSlot = -1;
            
            foreach (int highScore in highScores.Values)
            {
                if (score > highScore)
                {
                    break;
                }
                
            highScores.Add();

            highScores = highScores.

            string scoreBoardText = "";

            foreach (int highScore in highScores.Values)
            {
                scoreBoardText += highScore + "\n";
            }

            highScoresString = scoreBoardText;
            
            // Write dictionary to the json file
            var json = JsonUtility.ToJson(new SerializedData());
            File.WriteAllText(FILE_FULL_PATH, json);
        }
=======
        }

        return false;
>>>>>>> parent of 2eada4f (Revised the bug)
    }
}
