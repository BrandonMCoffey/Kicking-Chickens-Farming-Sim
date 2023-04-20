using Palmmedia.ReportGenerator.Core.Logging;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioSource PlayClip3D(AudioClip clip, float volume)
        {
            GameObject audioObGameObject = new GameObject("Audio2D");
            AudioSource audioSource = audioObGameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.spatialBlend = 1.0f;
            audioSource.Play();
            Destroy(audioObGameObject, clip.length);
            return audioSource;
        }
    }
}
