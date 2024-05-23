using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace BaursakRun
{
   public class SoundManager : MonoBehaviour
   {
        [SerializeField] private AudioClip[] backSound;
        [SerializeField] private AudioSource _backGroundMusic;
        [SerializeField] private Button _firstMelody;
        [SerializeField] private Button _secondMelody;
        [SerializeField] private Button _thirdMelody;
        [SerializeField] private Toggle _music;
        [SerializeField] private Toggle _soundeffect;
        [SerializeField] private Slider _volume;
        [SerializeField] private Slider _volumeMusic;
        [SerializeField] private Slider _volumeEffect;
        [SerializeField] private AudioMixerGroup _mixer;

        private void OnEnable()
        {
            _firstMelody.onClick.AddListener(FirstMelody);
            _secondMelody.onClick.AddListener(SecondMelody);
            _thirdMelody.onClick.AddListener(ThirdMelody);
            _music.onValueChanged.AddListener(ToggleMusic);
            _soundeffect.onValueChanged.AddListener(ToggleSoundEffects);
            _volume.onValueChanged.AddListener(ChangeVolume);
            _volumeMusic.onValueChanged.AddListener(ChangeMusicVolume);
            _volumeEffect.onValueChanged.AddListener(ChangeEffectVolume);
        }
        public void FirstMelody()
        {
            _backGroundMusic.clip = backSound[0];
            _backGroundMusic.Play();
        }
        public void SecondMelody()
        {
            _backGroundMusic.clip = backSound[1];
            _backGroundMusic.Play();
        }
        public void ThirdMelody()
        {
            _backGroundMusic.clip = backSound[2];
            _backGroundMusic.Play();
        }
        public void ToggleMusic(bool enabled)
        {
            if (enabled)
            {
                _mixer.audioMixer.SetFloat("MusicVolume", 0);
            }
            else
            {
                _mixer.audioMixer.SetFloat("MusicVolume", -80);
            }
        }
        public void ToggleSoundEffects(bool enabled)
        {
            if (enabled)
            {
                _mixer.audioMixer.SetFloat("EffectsVolume", 0);
            }
            else
            {
                _mixer.audioMixer.SetFloat("EffectsVolume", -80);
            }
        }
        public void ChangeVolume(float volume)
        {
            _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, -5, volume));
        }
        public void ChangeMusicVolume(float volume)
        {
            _mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        }
        public void ChangeEffectVolume(float volume)
        {
            _mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
        }
    } 
}

