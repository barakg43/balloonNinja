using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BalloonMovement : MonoBehaviour
{
    public bool isTouched = false;//flag to check if the sowrd already cut the ballon
    public int points = 0;
    public float minForce, maxForce;
    public Text balloon_score;
    private Rigidbody rb_ballon;

    public GameObject playerSword;
    [Range(0.2f, 10.0f)]
    public float upForce;

    // Start is called before the first frame update
    void Start()
    {
        rb_ballon = GetComponent<Rigidbody>();
        upForce = Random.Range(minForce, maxForce);
        playerSword = GameObject.Find("Sword");
    }

    // Update is called once per frame
    void Update()
    {

        rb_ballon.velocity = Vector3.up * upForce;
        if (transform.position.y > 3)
        {
            playerSword.GetComponent<PlayerContoller>().missedBallonCounter++;
            Destroy(this.gameObject);
        }



    }
}