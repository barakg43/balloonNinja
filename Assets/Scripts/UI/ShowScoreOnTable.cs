using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowScoreOnTable : MonoBehaviour
{
    Text[] newText;
    // Start is called before the first frame update
    void Start()
    {
        showHighSocreTable();


    }

    public void showHighSocreTable()
    {



        for (int i = 1; i <= 10; i++) //for top 10 highscores
        {
            transform.GetChild(i-1).GetComponent<Text>().text = PlayerPrefs.GetInt("HighScorePos" + i.ToString()).ToString();

        }


    }
}
