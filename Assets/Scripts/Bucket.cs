using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : Interactable
{
    public enum BucketState { Empty, Filled };
    [SerializeField]
    public BucketState bucketState = BucketState.Empty;

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

    public override void Interact()
    {
        _playerInteraction.PickUpItem(this.gameObject);
    }

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
