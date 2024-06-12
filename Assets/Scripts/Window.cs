using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactable
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
            if (_playerInteraction.GetCarriedTorch() != null && _playerInteraction.GetCarriedTorch().torchState == Torch.TorchState.Purple)
            {
                Debug.Log("Window Interacted while Torch is Purple.");

                _playerInteraction.DropItem();

                GameManager.instance.puzzleOneSolved = true;

/*                //Wwise
                AkSoundEngine.PostEvent("Stop_Magic_Barrier_Window", gameObject);
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Window_Rune_Gone", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);*/
            }
        }
    }
}
