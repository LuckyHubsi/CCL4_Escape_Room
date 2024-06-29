using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Interactable
{
    public enum TorchState { Unlit, Red, Blue, Yellow, Purple, Green, Orange }
    [SerializeField]
    public TorchState torchState = TorchState.Unlit;

    private PlayerInteraction _playerInteraction;

    #region Particle Reference
    [SerializeField]
    private ParticleSystem sparksParticles;
    [SerializeField]
    private ParticleSystem fireParticles;
    [SerializeField]
    private ParticleSystem allParticles;
    #endregion

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (_playerInteraction == null)
        {
            Debug.LogError("PlayerInteraction script not found in the scene.");
        }

        UpdateTorchAppearance();
    }

    // Checks if the torch the player interacted with is unlit or not
    // If yes, the player can pick it up
    // If not, the CombineTorch() function of the player gets called
    public override void Interact()
    {
        if (torchState == TorchState.Unlit)
        {
            _playerInteraction.PickUpItem(this.gameObject);
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

    // Updates torch appearance based on the torch state
    private void UpdateTorchAppearance()
    {
        if (sparksParticles == null || fireParticles == null)
        {
            return;
        }

        Color particleColor = Color.white;

        switch (torchState)
        {
            case TorchState.Unlit:
                // Set unlit appearance (disable particle systems)
                allParticles.Stop(true);
                return;
            case TorchState.Red:
                particleColor = Color.red;
                break;
            case TorchState.Blue:
                particleColor = Color.blue;
                break;
            case TorchState.Yellow:
                particleColor = Color.yellow;
                break;
            case TorchState.Purple:
                particleColor = new Color(0.5f, 0, 0.5f); // Purple
                break;
            case TorchState.Green:
                particleColor = Color.green;
                break;
            case TorchState.Orange:
                particleColor = new Color(1f, 0.5f, 0); // Orange
                break;
        }

        // Set the particle system colors
        var main1 = sparksParticles.main;
        main1.startColor = particleColor;

        var main2 = fireParticles.main;
        main2.startColor = particleColor;

        // Start the particle systems if they are not playing
        allParticles.Play();
        sparksParticles.Play();
        fireParticles.Play();
    }
}
