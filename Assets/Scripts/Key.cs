using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public enum KeyState { Active, inActive };
    [SerializeField]
    public KeyState keyState;

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

    public void SetKeyState(KeyState newState)
    {
        keyState = newState;
    }
}
