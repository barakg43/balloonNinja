using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerContoller : MonoBehaviour
{
    public int balloon_points = 0, missedBallonCounter = 0;
    public int lives = 4;
    public AudioSource swordSound;
    public BalloonMovement balloonScript;
    public GameObject balloonAudioControl;
    [SerializeField]
    public GameObject lifeManager;
    public GameObject gameOverText;
    public GameObject scoreContoller;
    bool isGameOver = false;

    [SerializeField]
    public Text game_score;
    public Material skull_material, currentBalloonMaterial;
    private Animator swordAnimContoller;


    void Start()
    {
        swordAnimContoller = GetComponent<Animator>();
        swordSound = GetComponent<AudioSource>();
        scoreContoller = GameObject.Find("ScoreController");
    }

    void Update()
    {

        if (!isGameOver && Input.GetKey(KeyCode.JoystickButton0) )
        {
          
            swordAnimContoller.SetTrigger("LeftSwing");
            swordSound.Play(0);
        }

        if (!isGameOver&&Input.GetKey(KeyCode.JoystickButton1) )
        {
            swordAnimContoller.SetTrigger("ForwardSwing") ;
            swordSound.Play(0);

        }
       

        if (missedBallonCounter == 3)//the class BalloonMovment decrease the counter evrey time missed balloon
        {
            decreaseLives();
            missedBallonCounter = 0;
        }
        GameScoreCounter();

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Balloon")
        {
            if (col.gameObject.GetComponent<BalloonMovement>().isTouched==false)
            {
                col.gameObject.GetComponent<BalloonMovement>().isTouched = true;
                currentBalloonMaterial = col.gameObject.transform.GetChild(0).GetComponent<Renderer>().sharedMaterial;
                balloonAudioControl.GetComponent<PlayPopSound>().playSound();

                Destroy(col.gameObject);

                if (currentBalloonMaterial != skull_material) //not a skull ,normal color
                {
                    balloon_points++;

                }
                else//this is skull ballon,decrese life from game
                {
                    decreaseLives();
                }
                currentBalloonMaterial = null;
            }
        }
         
    }

    private void GameScoreCounter()
    {
       
        game_score.text = balloon_points.ToString();
    }

    private void decreaseLives()
    {

        lives--;
        if(lifeManager.transform.childCount>0)
              Destroy(lifeManager.transform.GetChild(lives).gameObject);
        if (lives==0)
        {
            scoreContoller.GetComponent<ScoreManager>().updateHighSocreTable(balloon_points);
            isGameOver = true;
            gameOverText.SetActive(true);
            StartCoroutine(WaitBeforeMenu());
        }
 
    }



    private IEnumerator WaitBeforeMenu()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MainMenu");
       
    }
}







