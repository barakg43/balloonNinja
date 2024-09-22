using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class swordUI : MonoBehaviour
{
    public AudioSource swordSound;
    [SerializeField]
    private Animator swordAnimContoller;

    void Start()
    {
        swordAnimContoller = GetComponent<Animator>();
        swordSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.JoystickButton0)|| Input.GetKey(KeyCode.A))
        {
            swordAnimContoller.SetTrigger("LeftSwing");
            swordSound.Play(0);
        }

        if (Input.GetKey(KeyCode.JoystickButton1) || Input.GetKey(KeyCode.D))
        {
            swordAnimContoller.SetTrigger("ForwardSwing");
            swordSound.Play(0);
        }
       

      
           
    }

    private void OnTriggerEnter(Collider col) //This Function manage the UI - play botton, exit botton, and how to play botton.
    {
        if (col.gameObject.tag == "PlayBotton")
        {
            SceneManager.LoadScene("MainSceneGame", LoadSceneMode.Single);
            
        }
        if (col.gameObject.tag == "ExitBotton")
        {
            Debug.Log("Exit Game");
            Application.Quit();
        }
     
   
    }
}
        
