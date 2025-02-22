using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    public AudioClip background;
    public void Start()
    {
        music.clip = background;
        music.Play();
    }
}
