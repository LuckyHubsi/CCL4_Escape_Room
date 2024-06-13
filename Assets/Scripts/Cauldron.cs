using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : Interactable
{
    private string[] _cauldronInventory = new string[3];
    private int _currentCauldronInventoryIndex = 0;
    [SerializeField]
    private ParticleSystem firePit;

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
                AddItemToCauldron(carriedPotion.gameObject);
                _playerInteraction.DropItem();
            }

            Ingredient carriedIngredient = _playerInteraction.GetCarriedIngredient();
            if (carriedIngredient != null && carriedIngredient.isActiveAndEnabled)
            {
                AddItemToCauldron(carriedIngredient.gameObject);
                _playerInteraction.DropItem();
            }
        }
    }

    private void AddItemToCauldron(GameObject item)
    {
        Potion potion = item.GetComponent<Potion>();
        Ingredient ingredient = item.GetComponent<Ingredient>();

        if (potion != null)
        {
            _cauldronInventory[_currentCauldronInventoryIndex] = potion.potionState.ToString();
            Debug.Log("Added " + potion.potionState + " to the cauldron");
        }
        else if (ingredient != null)
        {
            _cauldronInventory[_currentCauldronInventoryIndex] = ingredient.ingredientState.ToString();
            Debug.Log("Added " + ingredient.ingredientState + " to the cauldron");
        }
        else
        {
            Debug.LogWarning("Item does not have a Potion or Ingredient component.");
            return; // Exit the method if the item is neither a Potion nor an Ingredient
        }

        Debug.Log(_cauldronInventory[_currentCauldronInventoryIndex]);

        _currentCauldronInventoryIndex++;

        // Check if the cauldron inventory is full (i.e., has 3 items)
        if (_currentCauldronInventoryIndex >= _cauldronInventory.Length)
        {
            CheckRecipe();
            ClearCauldronInventory();
        }
    }

    private void CheckRecipe()
    {
        // Define the correct recipes
        List<Dictionary<string, int>> correctRecipes = new List<Dictionary<string, int>>
        {
            new Dictionary<string, int>
            {
                { "Red", 1 },
                { "Blue", 1 },
                { "Yellow", 1 }
            },
            new Dictionary<string, int>
            {
                { "Tooth_Correct", 1 },
                { "Eye", 1 },
                { "BatWing", 1 }
            },
            // Add more recipes as needed
        };

        // Count the occurrences of each potion type in the cauldron inventory
        Dictionary<string, int> cauldronContents = new Dictionary<string, int>();
        foreach (var item in _cauldronInventory)
        {
            if (!string.IsNullOrEmpty(item))
            {
                if (cauldronContents.ContainsKey(item))
                {
                    cauldronContents[item]++;
                }
                else
                {
                    cauldronContents[item] = 1;
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
        }
        else
        {
            Debug.Log("Incorrect recipe.");
            // Add any additional logic for an incorrect recipe here
        }

        // Clear the inventory regardless of the result
        _cauldronInventory = new string[3];
    }

    private void ClearCauldronInventory()
    {
        // Clear the cauldron inventory
        for (int i = 0; i < _cauldronInventory.Length; i++)
        {
            _cauldronInventory[i] = "";
        }
        _currentCauldronInventoryIndex = 0;
    }
}
