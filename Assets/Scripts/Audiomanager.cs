using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource songAudio;
    public AudioClip song;
    public float songStartDelay = 3f;
    private Coroutine songRoutine;

    public void StartSong()
    {
        if (songRoutine != null)
        StopCoroutine(songRoutine);

        songRoutine = StartCoroutine(PlaySongAfterDelay());
    }

    IEnumerator PlaySongAfterDelay()
    {
        if (songAudio == null || song == null)
        {
            Debug.LogWarning("Add the song");
            songRoutine = null;
            yield break;
        }

        songAudio.Stop();
        songAudio.clip = song;
        yield return new WaitForSecondsRealtime(Mathf.Max(0f, songStartDelay));
        songAudio.Play();
        songRoutine = null;
    }

    public void StopSong()
    {
        if (songRoutine != null)
        {
            StopCoroutine(songRoutine);
            songRoutine = null;
        }

        if (songAudio != null)
        songAudio.Stop();
    }
}