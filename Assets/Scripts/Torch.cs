using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Interactable
{
    public enum TorchState { Unlit, Red, Blue, Yellow, Purple }
    [SerializeField]
    public TorchState torchState = TorchState.Unlit;

    private PlayerInteraction _playerInteraction;

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (_playerInteraction == null)
        {
            Debug.LogError("PlayerInteraction script not found in the scene.");
        }
        UpdateTorchAppearance();
    }

    public override void Interact()
    {
        if (torchState == TorchState.Unlit)
        {
            _playerInteraction.PickUpTorch(this);
        }
        else
        {
            _playerInteraction.CombineTorch(this);
        }
    }

    public void SetTorchState(TorchState newState)
    {
        torchState = newState;
        UpdateTorchAppearance();
    }

    private void UpdateTorchAppearance()
    {
        // Update the torch's appearance based on its state
        // For simplicity, you can enable/disable specific child objects or change materials
        switch (torchState)
        {
            case TorchState.Unlit:
                // Set unlit appearance
                break;
            case TorchState.Red:
                // Set red appearance
                break;
            case TorchState.Blue:
                // Set blue appearance
                break;
            case TorchState.Yellow:
                // Set blue appearance
                break;
            case TorchState.Purple:
                // Set purple appearance
                break;
        }
    }
}
