using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Barrier script, used on barriers which block the player from interacting with objects or getting more information for other puzzles
public class Barrier : Interactable
{
    private enum BarrierType { BarrierWindow, BarrierFire, BarrierDoor, BarrierMirror };
    [SerializeField]
    private BarrierType barrierType;

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

    // Handle interaction with player depending on the type of barrier
    // If it's the BarrierWindow, we check for the correct torch color
    // If it's the BarrierFire, we check for the correct bucket state
    public override void Interact()
    {
        if (_playerInteraction != null)
        {
            if (_playerInteraction.GetCarriedBucket() != null && _playerInteraction.GetCarriedBucket().bucketState == Bucket.BucketState.Filled && barrierType == BarrierType.BarrierFire)
            {
                Debug.Log("Barrier Interacted while Bucket is Filled.");
                ProgressionManager.instance.SolvePuzzleThree();
                _playerInteraction.DropItem();
            }

            if (_playerInteraction.GetCarriedTorch() != null && _playerInteraction.GetCarriedTorch().torchState == Torch.TorchState.Purple && barrierType == BarrierType.BarrierWindow)
            {
                Debug.Log("Barrier Interacted while Torch is Purple.");
                ProgressionManager.instance.SolvePuzzleOne();
                _playerInteraction.DropItem();

                //Wwise
                AkSoundEngine.PostEvent("Stop_Magic_Barrier_Window", gameObject);
                AkSoundEngine.SetSwitch("MagicBarrierWindow", "Inactive", gameObject);
                AkSoundEngine.PostEvent("Play_Magic_Barrier_Window", gameObject);
            }
        }
    }
}
