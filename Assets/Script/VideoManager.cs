using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource bgAudioSource;
    [SerializeField]
    private AudioSource otnerAudioSource;
    [SerializeField]
    private AudioClip urgentClip;
    [SerializeField]
    private AudioClip successClip;

    private void Awake()
    {
        EventCenter.AddListener(GameEventType.PlaySuccess, PlaySuccess);
        EventCenter.AddListener(GameEventType.PlayUrgent, PlayUrgent);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(GameEventType.PlaySuccess, PlaySuccess);
        EventCenter.RemoveListener(GameEventType.PlayUrgent, PlayUrgent);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySuccess() {
        otnerAudioSource.clip = successClip;
        otnerAudioSource.Play();
    }

    private void PlayUrgent() {
        bgAudioSource.Stop();
        otnerAudioSource.clip = urgentClip;
        otnerAudioSource.Play();
    }

}
