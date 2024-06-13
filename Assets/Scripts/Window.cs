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

        //Wwise
        AkSoundEngine.SetSwitch("MagicBarrierWindow", "Active", gameObject);
        AkSoundEngine.PostEvent("Play_Magic_Barrier_Window", gameObject);

    }

    public override void Interact()
    {
        if (_playerInteraction != null)
        {
            if (_playerInteraction.GetCarriedTorch() != null && _playerInteraction.GetCarriedTorch().torchState == Torch.TorchState.Purple)
            {
                Debug.Log("Window Interacted while Torch is Purple.");

                _playerInteraction.DropItem();

                //Wwise
                AkSoundEngine.PostEvent("Stop_Magic_Barrier_Window", gameObject);
                AkSoundEngine.SetSwitch("MagicBarrierWindow", "Inactive", gameObject);
                AkSoundEngine.PostEvent("Play_Magic_Barrier_Window", gameObject);

                ProgressionManager.instance.SolvePuzzleOne();

            } else if (_playerInteraction.GetCarriedTorch() != null && _playerInteraction.GetCarriedTorch().torchState != Torch.TorchState.Purple)
            {
                _playerInteraction.DropItem();

                //Wwise
                AkSoundEngine.PostEvent("Play_Wrong_Combination", gameObject);

            }
        }
    }
}
