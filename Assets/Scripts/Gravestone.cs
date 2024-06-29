using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : Interactable
{
    private PlayerInteraction _playerInteraction;

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (_playerInteraction == null)
        {
            Debug.LogError("PlayerInteraction script not found in the scene.");
        }
    }

    // Checks if the runestone that the player is carrying has the same runestoneState as the invisible runestone on the gravestone
    // If yes, set the runestone of the gravestone to active, drop the carried runestone and disable it
    public override void Interact()
    {
        if (_playerInteraction.GetCarriedRunestone().runestoneState == this.gameObject.GetComponentInChildren<Runestone>(true).runestoneState)
        {
            //Wwise
            AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Use_Rune", gameObject);
            AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
            
            this.gameObject.GetComponentInChildren<Runestone>(true).gameObject.SetActive(true);
            _playerInteraction.DropItem();
            _playerInteraction.GetPickedUpRunestone().gameObject.SetActive(false);
        }
    }
}
