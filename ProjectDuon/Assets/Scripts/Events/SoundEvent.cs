using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : GameplayEvent
{
    AudioClip audioClip;
    AudioSource targetAudioSource;
    float volume;

    public SoundEvent(AudioClip audioClip, AudioSource targetAudioSource, float volume)
    {
        this.audioClip = audioClip;
        this.targetAudioSource = targetAudioSource;
        this.volume = volume;
        requiresTimedActions = false;
    }

    public override IEnumerator ExecuteEvent()
    {
        targetAudioSource.PlayOneShot(audioClip, volume);
        isFinished = true;
        return null;
    }
}
