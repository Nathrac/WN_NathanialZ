using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] RealtimeAvatarManager _aM;
    [SerializeField] Realtime rt;
    [SerializeField] GameObject startToZen;
    [SerializeField] AudioSource gameIntro;

    private void Start()
    {
        _aM.avatarCreated += AvatarCreated;
    }

    private void AvatarCreated(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
    {
        if (_aM.avatars.Count == 3)
        {
            startToZen.SetActive(false);
            gameIntro.Play();
        }
    }
}
