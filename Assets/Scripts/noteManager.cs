using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteManager : MonoBehaviour
{
    float time = 0;
    float timeLimit = Mathf.Infinity;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setup(AudioClip audioClip, float pitch, float time)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.pitch = pitch;
        audioSource.Play();
        timeLimit = time;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > timeLimit)
        {
            Destroy(this.gameObject);
        }
    }
}
