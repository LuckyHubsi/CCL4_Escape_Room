using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : Interactable
{
    private Potion[] _cauldronInventory = new Potion[3];
    private int _currentPotionIndex = 0;

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
        if (_playerInteraction != null)
        {
            Potion carriedPotion = _playerInteraction.GetCarriedPotion();
            if (carriedPotion != null && carriedPotion.isActiveAndEnabled)
            {
                AddPotionToCauldron(carriedPotion);
                _playerInteraction.DropItem();
            }
        }
    }

    private void AddPotionToCauldron(Potion potion)
    {
        // Add the potion to the cauldron inventory
        _cauldronInventory[_currentPotionIndex] = potion;
        _currentPotionIndex++;

        // Check if the cauldron inventory is full (i.e., has 3 potions)
        if (_currentPotionIndex >= _cauldronInventory.Length)
        {
            CheckRecipe();
            ClearCauldronInventory();
        }
    }

    private void CheckRecipe()
    {
        // Define the correct recipe (adjust as needed)
        Potion.PotionState[] correctRecipe = { Potion.PotionState.Red, Potion.PotionState.Blue, Potion.PotionState.Yellow };

        // Check if the cauldron inventory matches the correct recipe
        bool isRecipeCorrect = true;
        for (int i = 0; i < _cauldronInventory.Length; i++)
        {
            if (_cauldronInventory[i].potionState != correctRecipe[i])
            {
                isRecipeCorrect = false;
                break;
            }
        }

        if (isRecipeCorrect)
        {
            Debug.Log("Correct recipe!");
            // Add any additional logic for a correct recipe here
        }
        else
        {
            Debug.Log("Incorrect recipe.");
            // Add any additional logic for an incorrect recipe here
        }
    }

    private void ClearCauldronInventory()
    {
        // Clear the cauldron inventory
        for (int i = 0; i < _cauldronInventory.Length; i++)
        {
            _cauldronInventory[i] = null;
        }
        _currentPotionIndex = 0;
    }
}