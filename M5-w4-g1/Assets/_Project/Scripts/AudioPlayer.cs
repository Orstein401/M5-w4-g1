using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private PlayerController player;
    [Header("Clip Audio")]
    [Header("Walk")]
    [SerializeField] private AudioClip[] clipsDirtWalk;
    [SerializeField] private AudioClip[] clipsStoneWalk;
    [SerializeField] private AudioClip[] clipsWoodWalk;
    [Header("Run")]
    [SerializeField] private AudioClip[] clipsDirtRun;
    [SerializeField] private AudioClip[] clipsStoneRun;
    [SerializeField] private AudioClip[] clipsWoodRun;

    private void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
        player = GetComponentInParent<PlayerController>();
    }

    public void StartSoundFootStep()
    {
        ChooseTypeSound();
        audioSource.Play();
    }
    public void ChooseTypeSound()
    {
        switch (player.WalkedGround)
        {
            case TypeGround.Dirt:
                if (player.Run)
                {
                    CasualSoundSelect(clipsDirtRun);
                }
                else
                {
                    CasualSoundSelect(clipsDirtWalk);
                }
                
                break;

            case TypeGround.Wood:
                if (player.Run)
                {
                    CasualSoundSelect(clipsWoodRun);
                }
                else
                {
                    CasualSoundSelect(clipsWoodWalk);
                }
                break;

            case TypeGround.Stone:
                if (player.Run)
                {
                    CasualSoundSelect(clipsStoneRun);
                }
                else
                {
                    CasualSoundSelect(clipsStoneWalk);
                }
                break;

        }
    }

    public void CasualSoundSelect(AudioClip[] audioClips)
    {
        int index = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[index];
    }
}
