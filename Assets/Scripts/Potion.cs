using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Interactable
{
    public enum PotionState { Empty, Red, Blue, Yellow, Purple, Green, Orange }
    [SerializeField]
    public PotionState potionState = PotionState.Empty;

    [SerializeField]
    private Material matRed;
    [SerializeField]
    private Material matBlue;
    [SerializeField]
    private Material matYellow;
    [SerializeField]
    private Material matPurple;
    [SerializeField]
    private Material matGreen;
    [SerializeField]
    private Material matOrange;

    private PlayerInteraction _playerInteraction;

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (_playerInteraction == null)
        {
            Debug.LogError("PlayerInteraction script not found in the scene.");
        }

        UpdatePotionAppearance();
    }

    public override void Interact()
    {
        _playerInteraction.PickUpItem(this.gameObject);
    }

    public void SetPotionState(PotionState newState)
    {
        potionState = newState;
        UpdatePotionAppearance();
    }

    private void UpdatePotionAppearance()
    {
        switch (potionState)
        {
            case PotionState.Empty:
                return;
            case PotionState.Red:
                this.gameObject.GetComponent<Renderer>().material = matRed;
                break;
            case PotionState.Blue:
                this.gameObject.GetComponent<Renderer>().material = matBlue;
                break;
            case PotionState.Yellow:
                this.gameObject.GetComponent<Renderer>().material = matYellow;
                break;
            case PotionState.Purple:
                this.gameObject.GetComponent<Renderer>().material = matPurple;
                break;
            case PotionState.Green:
                this.gameObject.GetComponent<Renderer>().material = matGreen;
                break;
            case PotionState.Orange:
                this.gameObject.GetComponent<Renderer>().material = matOrange;
                break;
        }
    }
}
