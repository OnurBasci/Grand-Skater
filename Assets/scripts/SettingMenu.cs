using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer music_mixer;
    public AudioMixer sound_mixer;
    public Slider music_slider;
    public Slider sound_slider;

    public void Awake()
    {
        music_mixer.GetFloat("volume", out float value1);
        music_slider.value = value1;
        sound_mixer.GetFloat("effects", out float value2);
        sound_slider.value = value2;
    }
    public void setMusic(float value)
    {
        music_mixer.SetFloat("volume", value);
    }
    public void setsound(float value)
    {
        sound_mixer.SetFloat("effects", value);
    }
}
