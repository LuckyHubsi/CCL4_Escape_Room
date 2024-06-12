using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Interactable
{
    public enum PotionState { Empty, Red, Blue, Yellow, Purple, Green, Orange }
    [SerializeField]
    public PotionState potionState = PotionState.Empty;

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
        _playerInteraction.PickUpItem(this.gameObject);
    }

    public void SetPotionState(PotionState newState)
    {
        potionState = newState;
    }
}
