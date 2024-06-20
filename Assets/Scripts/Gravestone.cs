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

    public override void Interact()
    {
        if (_playerInteraction.GetCarriedRunestone().runestoneState == this.gameObject.GetComponentInChildren<Runestone>(true).runestoneState)
        {
            this.gameObject.GetComponentInChildren<Runestone>(true).gameObject.SetActive(true);
            _playerInteraction.DropItem();
            _playerInteraction.GetPickedUpRunestone().gameObject.SetActive(false);
        }
    }
}
