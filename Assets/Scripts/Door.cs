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

    // If the player has the key and interacts with the door, it leads to the next scene
    public override void Interact()
    {
        if (_playerInteraction != null)
        {
            if (_playerInteraction.GetCarriedKey() != null && _playerInteraction.GetCarriedKey().keyState == Key.KeyState.Active)
            {
                WitchManager.instance.playerInBox = false;

                //Wwise
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Use_Key", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);

                _playerInteraction.DropItem();
                ScenesManager.Instance.LoadSceneAsync();
                ProgressionManager.instance.SolvePuzzleOne();
            }
            else
            {
                //Wwise
                AkSoundEngine.PostEvent("Play_Door_Closed", gameObject);
            }
        }
    }
}
