using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
/*            else if (_playerInteraction.GetCarriedTorch() != null && _playerInteraction.GetCarriedTorch().torchState != Torch.TorchState.Purple && barrierType == BarrierType.BarrierWindow)
            {
                _playerInteraction.DropItem();

                //Wwise
                AkSoundEngine.PostEvent("Play_Wrong_Combination", gameObject);
            }*/
        }
    }
}
