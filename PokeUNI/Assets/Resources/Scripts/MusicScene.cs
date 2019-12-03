using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScene : MonoBehaviour
{
    private AudioSource audioSource;
    //public AudioClip[] musicList;
    //private int musicListLenght;

    public AudioSource[] _refAudioSources;

    void Start()
    {
        //musicListLenght = musicList.Length;
        //audioSource = GetComponent<AudioSource>();
        //StartCoroutine(MusicLoopLogic());
        DontDestroyOnLoad(this);
        _refAudioSources[1].PlayDelayed(_refAudioSources[0].clip.length - 0.025f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private IEnumerator MusicLoopLogic()
    //{
    //    if(musicListLenght != 0)
    //    {
    //        audioSource.clip = musicList[0];
    //        audioSource.Play();
    //        yield return new WaitForSeconds(audioSource.clip.length);
    //        audioSource.clip = musicList[1];
    //        audioSource.Play();
    //        audioSource.loop = true;
    //    }
    //    else
    //    {
    //        yield return null;
    //    }
        
    //}
}
