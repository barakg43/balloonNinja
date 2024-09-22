using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
//    private Transform entryContainer;
//    private Transform entryTemplate;
//    private List<HighScoreEntry> highscoreEntryList;
//    private List<Transform> highScoreEnteryTransfromList;

//    private void Awake()
//    {
//        entryContainer = transform.Find("highScoreEntryContainer");
//        entryTemplate = entryContainer.Find("highScoreEntryTemplate");

//        entryTemplate.gameObject.SetActive(false);


//        string jsonString = PlayerPrefs.GetString("highScoreTable");
//        Highscores highscores = JsonUtiliy.FromJson<HighScores>(jsonString);
//        // Sort entry list by score  
//        for (int i = 0; i < highscoreEntryList.Count; i++)
//        {
//            for (int j = i+1; j < highscoreEntryList.Count; j++)
//            {
//                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
//                {
//                    HighScoreEntry tmp = highscoreEntryList[i];
//                    highscoreEntryList[i] = highscoreEntryList[j];
//                    highscoreEntryList[j] = tmp;
//                }
//            }
//        }

//        highScoreEnteryTransfromList = new List<Transform>();
//        foreach (HighScoreEntry hs in highscoreEntryList)
//        {
//            createHighScoreEntry(hs, entryContainer, highScoreEnteryTransfromList);
//        }
//        /*
//        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
//        string json = JsonUtility.ToJson(highscores);
//        PlayerPrefs.SetString("highScoreTable", json);
//        PlayerPrefs.Save(); */
       
//    }

//    //add single entry to table (single line in table)
//    private void createHighScoreEntry(HighScoreEntry hs, Transform container, List<Transform> transformList)
//    {
//        float templateHeight = 45f; //distance between two lines 
//        Transform entryTransform = Instantiate(entryTemplate, container);
//        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
//        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
//        entryTransform.gameObject.SetActive(true);

//        int rank = transformList.Count + 1;
//        string rankString; // rank is given by the position in the list
//        switch (rank)
//        {
//            default:
//                rankString = rank + "th"; break;
//            case 1: rankString = "1st"; break;
//            case 2: rankString = "2nd"; break;
//            case 3: rankString = "3rd"; break;
//        }

//        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
//        int score = hs.score;
//        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

//        string name = hs.name;
//        entryTransform.Find("nameText").GetComponent<Text>().text = name;

//        transformList.Add(entryTransform);
//    }

//    private class Highscores
//    {
//        public List<highScoreEntry> highscoreEntryList;
//    }


//    // one Line of table
//    [System.Serializable]
//    private class HighScoreEntry
//    {
//        public int score;
//        public string name;
//    }

}

