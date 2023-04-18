using UnityEngine;


public static class AudioManager
{
    public static AudioSource PlayerClip2D(AudioClip clip, float volume)
    {
        GameObject audioObject = new GameObject("Audio2D");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
        Object.Destroy(audioObject, clip.length);
        return audioSource;
    }
}
