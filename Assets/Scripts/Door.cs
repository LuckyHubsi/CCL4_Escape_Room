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
                Debug.Log("SESAME OPEN");
                //Wwise
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Use_Key", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);

                _playerInteraction.DropItem();
                ScenesManager.Instance.LoadSceneAsync();
                ProgressionManager.instance.SolvePuzzleOne();

                WitchManager.instance.PlayerExitedBox();

            }
            else
            {
                AkSoundEngine.PostEvent("Play_Door_Closed", gameObject);
            }
        }
    }
}
