using UnityEngine;

public class RandomMusicPlayer : MonoBehaviour
{
    public AudioClip[] tracks;
    public AudioSource audioSource; 

    void Start()
    {
        PlayRandomTrack();
    }

    void PlayRandomTrack()
    {
        if (tracks.Length == 0 || audioSource == null)
            return;

        // Вибираємо випадковий трек
        int index = Random.Range(0, tracks.Length);
        audioSource.clip = tracks[index];
        audioSource.Play();

        // Викликаємо наступний трек, коли цей закінчиться
        Invoke(nameof(PlayRandomTrack), audioSource.clip.length);
    }
}