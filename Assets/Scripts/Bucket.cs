using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : Interactable
{
    public enum BucketState { Empty, Filled };
    [SerializeField]
    public BucketState bucketState = BucketState.Empty;

    // Reference to the "liquid" object in the bucket
    [SerializeField]
    private GameObject liquid;

    private PlayerInteraction _playerInteraction;

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (_playerInteraction == null)
        {
            Debug.LogError("PlayerInteraction script not found in the scene.");
        }

        SetBucketState(BucketState.Empty);
    }

    // Player gets reference to interacted bucket object
    public override void Interact()
    {
        _playerInteraction.PickUpItem(this.gameObject);
    }

    // Activates/Deactivates liquid object depending on the bucketState
    public void SetBucketState(BucketState newState)
    {
        bucketState = newState;

        if (bucketState == BucketState.Empty)
        {
            liquid.SetActive(false);
        }
        else
        {
            liquid.SetActive(true);
        }
    }
}
