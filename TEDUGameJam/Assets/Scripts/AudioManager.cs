using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    public AudioClip background;

    private void Awake() {
        if (FindObjectsOfType<AudioManager>().Length > 1) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        music = GetComponent<AudioSource>();
        music.loop = true;
        music.clip = background;
        music.Play();
    }
}
