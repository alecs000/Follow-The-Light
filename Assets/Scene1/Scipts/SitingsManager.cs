using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class SitingsManager : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    [SerializeField] Text musicTixt;
    [SerializeField] Text effectsTixt;
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
    public void ChangeValume(float Volue)
    {
        Debug.Log(Volue);
        effectsTixt.text = (Convert.ToInt32(Volue * 100)).ToString()+"%";
        Mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, Volue));
    }
    public void ChangeMusic(float Volue)
    {
        musicTixt.text = (Convert.ToInt32(Volue * 100)).ToString() + "%";
        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, Volue));
    }
}
