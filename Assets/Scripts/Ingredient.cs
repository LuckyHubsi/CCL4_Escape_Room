using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Interactable
{
    public enum IngredientState { Empty, BatWing, Eye, FroshTongue, Tooth_Wrong, Tooth_Correct }
    [SerializeField]
    public IngredientState ingredientState = IngredientState.Empty;

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
}
