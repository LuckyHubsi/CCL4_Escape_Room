using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : Interactable
{
    private Potion.PotionState[] _cauldronInventory = new Potion.PotionState[3];
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
        _cauldronInventory[_currentPotionIndex] = potion.potionState;

        Debug.Log("Added " + potion.potionState + " to the cauldron");
        Debug.Log(_cauldronInventory[_currentPotionIndex]);

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
        // Define the correct recipes
        List<Dictionary<Potion.PotionState, int>> correctRecipes = new List<Dictionary<Potion.PotionState, int>>
    {
        new Dictionary<Potion.PotionState, int>
        {
            { Potion.PotionState.Red, 1 },
            { Potion.PotionState.Blue, 1 },
            { Potion.PotionState.Yellow, 1 }
        },
        new Dictionary<Potion.PotionState, int>
        {
            { Potion.PotionState.Red, 2 },
            { Potion.PotionState.Blue, 1 }
        },
        // Add more recipes as needed
    };

        // Count the occurrences of each potion type in the cauldron inventory
        Dictionary<Potion.PotionState, int> cauldronContents = new Dictionary<Potion.PotionState, int>();
        foreach (var potionState in _cauldronInventory)
        {
            if (potionState != Potion.PotionState.Empty)
            {
                if (cauldronContents.ContainsKey(potionState))
                {
                    cauldronContents[potionState]++;
                }
                else
                {
                    cauldronContents[potionState] = 1;
                }
            }
        }

        // Check if the cauldron contents match any of the correct recipes
        bool isRecipeCorrect = false;
        foreach (var recipe in correctRecipes)
        {
            bool match = true;
            foreach (var ingredient in recipe)
            {
                if (!cauldronContents.ContainsKey(ingredient.Key) || cauldronContents[ingredient.Key] != ingredient.Value)
                {
                    match = false;
                    break;
                }
            }
            if (match && recipe.Count == cauldronContents.Count)
            {
                isRecipeCorrect = true;
                break;
            }
        }

        if (isRecipeCorrect)
        {
            Debug.Log("Correct recipe!");
            // Add any additional logic for a correct recipe here
            _cauldronInventory = new Potion.PotionState[3]; // Clear the inventory
        }
        else
        {
            Debug.Log("Incorrect recipe.");
            // Add any additional logic for an incorrect recipe here
            _cauldronInventory = new Potion.PotionState[3]; // Clear the inventory
        }
    }


    private void ClearCauldronInventory()
    {
        // Clear the cauldron inventory
        for (int i = 0; i < _cauldronInventory.Length; i++)
        {
            _cauldronInventory[i] = Potion.PotionState.Empty;
        }
        _currentPotionIndex = 0;
    }
}