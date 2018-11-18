using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tiboo
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource m_audioSource;

        public AudioClip m_hello;
        public AudioClip m_whereToGo;
        public AudioClip m_greenRabbit;
        public AudioClip m_blueRabbit;
        public AudioClip m_redMouse;
        public AudioClip m_yellowMouse;
        public AudioClip m_thouShaltPass;
        public AudioClip m_thouShaltNotPass;
        public AudioClip m_yourTurn;
        public AudioClip m_openWall;
        public AudioClip m_closedWall;
        public AudioClip m_rabbitHole;
        public AudioClip m_mouseHole;
        public AudioClip m_magicDoor;
        public AudioClip m_border;

        public Dictionary<SoundMixer.SoundFX, AudioClip> m_clips;

        private List<SoundMixer.SoundFX> m_soundsToPlay;

        void Start()
        {
            m_clips = new Dictionary<SoundMixer.SoundFX, AudioClip>
            {
                { SoundMixer.SoundFX.HELLO, m_hello },
                { SoundMixer.SoundFX.BLUE_RABBIT, m_blueRabbit },
                { SoundMixer.SoundFX.GREEN_RABBIT, m_greenRabbit },
                { SoundMixer.SoundFX.RED_MOUSE, m_redMouse },
                { SoundMixer.SoundFX.YELLOW_MOUSE, m_yellowMouse },
                { SoundMixer.SoundFX.THOU_SHALT_PASS, m_thouShaltPass },
                { SoundMixer.SoundFX.THOU_SHALT_NOT_PASS, m_thouShaltNotPass },
                { SoundMixer.SoundFX.WHERE_TO_GO, m_whereToGo },
                { SoundMixer.SoundFX.OPEN_WALL, m_openWall },
                { SoundMixer.SoundFX.CLOSED_WALL, m_closedWall },
                { SoundMixer.SoundFX.RABBIT_HOLE, m_rabbitHole },
                { SoundMixer.SoundFX.MOUSE_HOLE, m_mouseHole },
                { SoundMixer.SoundFX.MAGIC_DOOR, m_magicDoor },
                { SoundMixer.SoundFX.BORDER, m_border },
            };
            m_soundsToPlay = new List<SoundMixer.SoundFX>();
        }

        public void PlayAllSounds(List<SoundMixer.SoundFX> sounds)
        {
            m_soundsToPlay.AddRange(sounds);
        }

        public bool Done()
        {
            return (m_soundsToPlay.Count == 0) && (!m_audioSource.isPlaying);
        }

        void Update()
        {
            if (m_audioSource.isPlaying)
            {
                Debug.Log("Playing clip " + m_audioSource.clip.name);
                return;
            }
            if (m_soundsToPlay.Count > 0)
            {
                try
                {
                    Debug.Log("Next sound to play : " + m_soundsToPlay[0]);
                    m_audioSource.clip = m_clips[m_soundsToPlay[0]];
                    Debug.Log("Starting clip " + m_audioSource.clip.name);
                    m_audioSource.Play();
                    m_soundsToPlay.RemoveAt(0);
                }
                catch (NullReferenceException)
                {
                    Debug.LogError("Unable to find sound for key " + m_soundsToPlay[0]);
                    m_soundsToPlay.RemoveAt(0);
                }
            }
        }
    }
}