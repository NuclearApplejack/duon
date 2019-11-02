using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimManager : MonoBehaviour {

    public TitleScreenManager manager;
    public GameObject image;
    public AudioSource aSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetOffAlpha()
    {
        manager.SetOffAlpha();
    }

    public void StartSong()
    {
        manager.GetComponent<BGMPlayer>().PlayBGM();
    }

    public void DisableBG()
    {
        image.SetActive(false);
    }

    public void PlayAudio1()
    {
        aSource.PlayOneShot(Resources.Load<AudioClip>("Sound/SFX/Misc/intro load 1"), 1f);
    }

    public void PlayAudio2()
    {
        aSource.PlayOneShot(Resources.Load<AudioClip>("Sound/SFX/Misc/intro load 2"), 1f);
    }
}
