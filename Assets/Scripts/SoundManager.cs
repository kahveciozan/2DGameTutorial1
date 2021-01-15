using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip jumpClipNormal, jumClipExtra, gameOverClip;



    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void JumpSoundNormalFX()
    {
        soundFX.clip = jumpClipNormal;
        soundFX.Play(); 
    }
    public void JumpSoundExtraFX()
    {
        soundFX.clip = jumClipExtra;
        soundFX.Play();
    }
    public void GameOverSoundFX()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }
}
