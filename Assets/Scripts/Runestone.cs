using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runestone : Interactable
{
    public enum RunestoneState { Blank, Red, Blue, Yellow, Purple, Green, Orange, Turquoise, Pink }
    [SerializeField]
    public RunestoneState runestoneState = RunestoneState.Blank;

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
    [SerializeField]
    private Material matTurquoise;
    [SerializeField]
    private Material matPink;

    private PlayerInteraction _playerInteraction;

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (_playerInteraction == null)
        {
            Debug.LogError("PlayerInteraction script not found in the scene.");
        }

        UpdateRunestoneAppearance();
    }

    public override void Interact()
    {
        if (_playerInteraction.GetCarriedRunestone().runestoneState == Runestone.RunestoneState.Blank)
        {
            _playerInteraction.PickUpItem(this.gameObject);
        }
    }

    public void SetRunestoneState(RunestoneState newState)
    {
        runestoneState = newState;
        UpdateRunestoneAppearance();
    }

    private void UpdateRunestoneAppearance()
    {
        switch (runestoneState)
        {
            case RunestoneState.Blank:
                return;
            case RunestoneState.Red:
                this.gameObject.GetComponent<Renderer>().material = matRed;
                break;
            case RunestoneState.Blue:
                this.gameObject.GetComponent<Renderer>().material = matBlue;
                break;
            case RunestoneState.Yellow:
                this.gameObject.GetComponent<Renderer>().material = matYellow;
                break;
            case RunestoneState.Purple:
                this.gameObject.GetComponent<Renderer>().material = matPurple;
                break;
            case RunestoneState.Green:
                this.gameObject.GetComponent<Renderer>().material = matGreen;
                break;
            case RunestoneState.Orange:
                this.gameObject.GetComponent<Renderer>().material = matOrange;
                break;
            case RunestoneState.Turquoise:
                this.gameObject.GetComponent<Renderer>().material = matTurquoise;
                break;
            case RunestoneState.Pink:
                this.gameObject.GetComponent<Renderer>().material = matPink;
                break;
        }
    }
}
