using UnityEngine.Audio;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public AudioSource[] soundEffects;
    public AudioClip wallHit;
    public GameObject wallHitObj;
    public AudioMixerGroup audioMixerGroup;

    public void playClapping()
    {
        soundEffects[0].Play();
    }

    public void playHole()
    {
        soundEffects[1].Play();
    }

    public void playStrike()
    {
        soundEffects[2].Play();
    }

    public void playWater()
    {
        soundEffects[3].Play();
    }

    public void playWall()
    {
        //AudioSource.PlayClipAtPoint(wallHit, this.transform.position);
        GameObject obj = Instantiate(wallHitObj);
        obj.GetComponent<AudioSource>().outputAudioMixerGroup = audioMixerGroup;
        //obj.transform.position = this.transform.position;
        obj.GetComponent<AudioSource>().Play();
        Object.Destroy(obj, 1f);
    }
}
