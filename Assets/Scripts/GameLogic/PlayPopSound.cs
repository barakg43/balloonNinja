using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPopSound : MonoBehaviour
{
    public AudioSource balloonPopSound;

    // Start is called before the first frame update
    void Start()
    {
        balloonPopSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void playSound()
    {
        balloonPopSound.Play(0);
    }
}
