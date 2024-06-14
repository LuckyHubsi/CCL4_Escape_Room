using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private PlayerInteraction _playerInteraction;

    void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (_playerInteraction == null)
        {
            Debug.LogError("PlayerInteraction script not found in the scene.");
        }
    }

    public override void Interact()
    {
        if (_playerInteraction != null)
        {
            if (_playerInteraction.GetCarriedKey() != null && _playerInteraction.GetCarriedKey().keyState == Key.KeyState.Active)
            {
                //Wwise
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Use_Key", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
                ScenesManager.Instance.LoadSceneAsync();
            }
        }
    }
}
