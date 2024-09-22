using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
 public class ScoreManager : MonoBehaviour
{
    public bool levelComplete, IsScoreSaved = false;
    public string highscorePos;
    [SerializeField]
    bool resetScoreBoard = false;
    public int temp;

    void Start()
    {
        if(resetScoreBoard)
        {
            for (int i = 1; i <= 10; i++)
                PlayerPrefs.SetInt("HighScorePos"+i.ToString(), 0);
            
        }
            
    }

   public void updateHighSocreTable(int score)
    {
        levelComplete = true;
       
        for (int i = 1; i <= 10; i++) //for top 5 highscores
        {
            if (PlayerPrefs.GetInt("HighScorePos" + i.ToString()) < score&&! IsScoreSaved)     //if cuurent score is in top 5
            {
                temp = PlayerPrefs.GetInt("HighScorePos" + i.ToString());//store the old highscore in temp varible to shift it down
                IsScoreSaved = true;
                PlayerPrefs.SetInt("HighScorePos" + i.ToString(), score);     //store the currentscore to highscores
                if (i < 10)                                        //do this for shifting scores down
                {
                    int j = i + 1;
                    PlayerPrefs.SetInt("HighScorePos" + j.ToString(), temp);
                }
            }
        }

        IsScoreSaved = false;//for saving next score
    }


}
