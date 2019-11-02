using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploTempController : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip sound1;
    public AudioClip sound2;
    GameObject generalManager;

    // Use this for initialization
    void Start()
    {
        generalManager = GameObject.Find("GeneralManager");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound1()
    {
        audioS.PlayOneShot(sound1, 1f);
    }

    public void PlaySound2()
    {
        audioS.PlayOneShot(sound2, 0.8f);
        
        
    }

    public void Flash()
    {
        StartCoroutine(generalManager.GetComponent<EventIssuer>().FlashScreenDuringGameplay(0f, 0.3f, 0f, new Color(1, 1, 1, 0.5f)));
        StartCoroutine(generalManager.GetComponent<EventIssuer>().ShakeScreenDuringGameplay(0.5f, 0.3f));
    }
}
