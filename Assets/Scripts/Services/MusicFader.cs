using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFader : MonoBehaviour {

	public static IEnumerator fadeIn(AudioSource audio, float fadeTime, float volume) {
        while(audio.volume < volume) {
            audio.volume += volume * Time.deltaTime / fadeTime;

            yield return null;
        }
    }

    public static IEnumerator fadeOut(AudioSource audio, float fadeTime) {
        float startVolume = audio.volume;

        while (audio.volume > 0) {
            audio.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }
    }
}
