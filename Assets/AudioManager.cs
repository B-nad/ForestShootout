using UnityEngine;

public static class AudioManager
{
    public static AudioSource PlayFromResources(Sound soundFileName, float volume = 1.0f, float pitch = 1.0f, bool loop = false)
    {

        AudioClip soundClip = Resources.Load<AudioClip>($"Sound Effects/{soundFileName}");

        if (soundClip == null)
        {
            Debug.LogError($"Sound clip with name {soundFileName} not found in Resources folder.");
            return null;
        }

        GameObject soundGameObject = new GameObject(soundFileName.ToString());
        AudioSource soundSource = soundGameObject.AddComponent<AudioSource>();
        soundSource.clip = soundClip;
        soundSource.pitch = pitch;
        soundSource.volume = volume;
        soundSource.loop = loop;
        soundSource.Play();
        if (!loop) { Object.Destroy(soundGameObject, soundClip.length); }
        return soundSource;
    }
}

public enum Sound
{
    cookies,
    Attack
}