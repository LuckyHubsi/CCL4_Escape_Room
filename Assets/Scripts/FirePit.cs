using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePit : Interactable
{
    private PlayerInteraction _playerInteraction;

    private string _firePitState = "Unlit";

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

        UpdateFirePitAppearance();
    }

    public override void Interact()
    {
        SetFirePitState(_playerInteraction.GetCarriedTorch().torchState.ToString());
    }

    public void SetFirePitState(string newState)
    {
        _firePitState = newState;
        UpdateFirePitAppearance();
    }

    public string GetFirePitState()
    {
        return _firePitState;
    }

    private void UpdateFirePitAppearance()
    {
        if (allParticles == null)
        {
            return;
        }

        Color particleColor = Color.white;

        switch (_firePitState)
        {
            case "Unlit":
                // Set unlit appearance (e.g., disable particle systems)
                allParticles.Stop(true);
                return;
            case "Red":
                particleColor = Color.red;
                break;
            case "Blue":
                particleColor = Color.blue;
                break;
            case "Yellow":
                particleColor = Color.yellow;
                break;
            case "Purple":
                particleColor = new Color(0.5f, 0, 0.5f); // Purple
                break;
            case "Green":
                particleColor = Color.green;
                break;
            case "Orange":
                particleColor = new Color(1f, 0.5f, 0);
                break;
        }

        // Set the particle system colors
        var main1 = sparksParticles.main;
        main1.startColor = particleColor;

        var main2 = fireParticles.main;
        main2.startColor = particleColor;

        // Start the particle systems if they are not playing
        allParticles.Play();
    }
}
