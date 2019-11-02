using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Luna : PlayableCharacter {

    new void Start()
    {
        base.Start();
        homeDimension = Dimension.DIMENSION_Z;
    }

    new void Update()
    {
        base.Update();

        if (isFacingRight)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }



    void FixedUpdate()
    {
        if (!generalManager.GetComponent<PauseManager>().gameIsPaused)
        {
            ManageActions();
        }
        
    
    }

    public void PlasmaCutterEvent1()
    {
        AudioClip soundEffect = Resources.Load<AudioClip>("Sound/SFX/Attacks/Slash1");
        audioSource.PlayOneShot(soundEffect, 1f);
    }

    public void PlasmaShotEvent1()
    {
        AudioClip soundEffect = Resources.Load<AudioClip>("Sound/SFX/Attacks/Plasma1");
        audioSource.PlayOneShot(soundEffect, 0.5f);
    }

    public void BackflipEvent1()
    {
        AudioClip soundEffect = Resources.Load<AudioClip>("Sound/SFX/Attacks/Cloth1");
        audioSource.PlayOneShot(soundEffect, 0.7f);
    }

    public void ArtEvent1()
    {
        if (isFacingRight)
        {
            TeleportCharacter(new Vector2(30, 0));
        }
        else
        {
            TeleportCharacter(new Vector2(-30, 0));
        }

        StartCoroutine(generalManager.GetComponent<EventIssuer>().ShakeScreenDuringGameplay(0.2f, 0.2f));
    }

    public void ArtEvent2()
    {

        StartCoroutine(generalManager.GetComponent<EventIssuer>().FlashScreenDuringGameplay(0, 0.1f, 0f, new Color(1, 1, 1, 1)));
        StartCoroutine(generalManager.GetComponent<EventIssuer>().ShakeScreenDuringGameplay(0.4f, 0.2f));
    }

    public void ArtSoundEvent1()
    {
        AudioClip soundEffect = Resources.Load<AudioClip>("Sound/SFX/Attacks/FissureRush1");
        audioSource.PlayOneShot(soundEffect, 0.6f);
    }

    public void ArtSoundEvent2()
    {
        AudioClip soundEffect = Resources.Load<AudioClip>("Sound/SFX/Attacks/FissureRush2");
        audioSource.PlayOneShot(soundEffect, 0.7f);
    }
}
