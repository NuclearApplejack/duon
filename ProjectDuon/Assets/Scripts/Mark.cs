using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Mark : PlayableCharacter {

    new void Start()
    {
        base.Start();
        homeDimension = Dimension.DIMENSION_A;
    }

    new void Update()
    {
        base.Update();

        
    }


    void FixedUpdate()
    {
        if (!generalManager.GetComponent<PauseManager>().gameIsPaused)
        {
            
            ManageActions();

        }
        
    }

    public void ArtEvent1()
    {
        StartCoroutine(generalManager.GetComponent<EventIssuer>().ShakeScreenDuringGameplay(0.2f, 0.5f));
    }

    public void ArtEvent2()
    {
        if (isFacingRight)
        {
            TeleportCharacter(new Vector2(25, 0));
        }
        else
        {
            TeleportCharacter(new Vector2(-25, 0));
        }

        StartCoroutine(generalManager.GetComponent<EventIssuer>().FlashScreenDuringGameplay(0, 0.1f, 0f, new Color(1, 1, 1, 1)));
        StartCoroutine(generalManager.GetComponent<EventIssuer>().ShakeScreenDuringGameplay(0.4f, 0.2f));
    }

    public void PunchSoundEvent()
    {
        int value = Random.Range(1, 4);
        AudioClip soundEffect = Resources.Load<AudioClip>("Sound/SFX/Attacks/Punch" + value.ToString());
        audioSource.PlayOneShot(soundEffect, 0.6f);
    }

    public void ArtSoundEvent2()
    {
        AudioClip soundEffect = Resources.Load<AudioClip>("Sound/SFX/Attacks/ShatteringTempest1");
        audioSource.PlayOneShot(soundEffect, 0.5f);
    }
}
