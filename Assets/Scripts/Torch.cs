using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Interactable
{
    public enum TorchState { Unlit, Red, Blue, Yellow, Purple }
    [SerializeField]
    public TorchState torchState = TorchState.Unlit;

    private PlayerInteraction _playerInteraction;

    [SerializeField]
    private ParticleSystem sparksParticles;
    [SerializeField]
    private ParticleSystem fireParticles;
    [SerializeField]
    private ParticleSystem allParticles;

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
        if (sparksParticles == null || fireParticles == null)
        {
            return;
        }

        Color particleColor = Color.white;

        switch (torchState)
        {
            case TorchState.Unlit:
                // Set unlit appearance (e.g., disable particle systems)
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
        }

        // Set the particle system colors
        var main1 = sparksParticles.main;
        main1.startColor = particleColor;

        var main2 = fireParticles.main;
        main2.startColor = particleColor;

        // Start the particle systems if they are not playing
        allParticles.Play();
        if (!sparksParticles.isPlaying) sparksParticles.Play();
        if (!fireParticles.isPlaying) fireParticles.Play();
    }
}
