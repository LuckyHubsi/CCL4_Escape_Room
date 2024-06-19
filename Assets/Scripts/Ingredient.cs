using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Interactable
{
    public enum IngredientState { Empty, BatWing, Eye, FroshTongue, Tooth_Wrong, Tooth_Correct }
    [SerializeField]
    public IngredientState ingredientState = IngredientState.Empty;

    [SerializeField]
    private Material matLid_Bat;
    [SerializeField]
    private Material matLid_Eye;
    [SerializeField]
    private Material matLid_Tongue;
    [SerializeField]
    private Material matLid_ToothWrong1;
    [SerializeField]
    private Material matLid_ToothWrong2;
    [SerializeField]
    private Material matLid_ToothRight;

    [SerializeField]
    private Material mat_Bat;
    [SerializeField]
    private Material mat_Eye;
    [SerializeField]
    private Material mat_Tongue;
    [SerializeField]
    private Material mat_Tooth;

    [SerializeField]
    private Mesh bat;
    [SerializeField]
    private Mesh eye;
    [SerializeField]
    private Mesh tongue;
    [SerializeField]
    private Mesh tooth;

    private PlayerInteraction _playerInteraction;

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (_playerInteraction == null)
        {
            Debug.LogError("PlayerInteraction script not found in the scene.");
        }
    }

    public override void Interact()
    {
        _playerInteraction.PickUpItem(this.gameObject);
    }

    public void SetIngredientState(IngredientState newState)
    {
        ingredientState = newState;
    }

    private void UpdateIngredientAppearance()
    {
        switch (ingredientState)
        {
            case IngredientState.Empty:
                return;
            case IngredientState.BatWing:
                this.gameObject.GetComponent<Renderer>().material = matRed;
                break;
            case IngredientState.Eye:
                this.gameObject.GetComponent<Renderer>().material = matBlue;
                break;
            case IngredientState.FroshTongue:
                this.gameObject.GetComponent<Renderer>().material = matYellow;
                break;
            case IngredientState.Tooth_Wrong:
                this.gameObject.GetComponent<Renderer>().material = matPurple;
                break;
            case IngredientState.Tooth_Correct:
                this.gameObject.GetComponent<Renderer>().material = matGreen;
                break;
        }
    }
}
