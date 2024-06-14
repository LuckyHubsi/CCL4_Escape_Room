using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : Interactable
{
    private string[] _cauldronInventory = new string[3];
    private int _currentCauldronInventoryIndex = 0;

    private FirePit _firePit;

    private PlayerInteraction _playerInteraction;

    private string _lastCorrectRecipe = "";

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (_playerInteraction == null)
        {
            Debug.LogError("PlayerInteraction script not found in the scene.");
        }

        _firePit = FindObjectOfType<FirePit>();
        if (_firePit == null)
        {
            Debug.LogError("FirePit script not found in the scene.");
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

            Bucket carriedBucket = _playerInteraction.GetCarriedBucket();
            if (carriedBucket != null && carriedBucket.isActiveAndEnabled && carriedBucket.bucketState == Bucket.BucketState.Empty && _lastCorrectRecipe == "Recipe Ingredient")
            {
                carriedBucket.SetBucketState(Bucket.BucketState.Filled);

                Debug.Log("Filled Bucket");

                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Equipping_Waterbucket", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
            }

        }
    }

    private void AddItemToCauldron(GameObject item)
    {
        Potion potion = item.GetComponent<Potion>();
        if (potion != null)
        {
            _cauldronInventory[_currentCauldronInventoryIndex] = potion.potionState.ToString();
            Debug.Log("Added " + potion.potionState + " to the cauldron");

            //Wwise
            AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Using_Potion", gameObject);
            AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
        }
        else
        {
            Ingredient ingredient = item.GetComponent<Ingredient>();
            if (ingredient != null)
            {
                _cauldronInventory[_currentCauldronInventoryIndex] = ingredient.ingredientState.ToString();
                Debug.Log("Added " + ingredient.ingredientState + " to the cauldron");
            }
        }

        _currentCauldronInventoryIndex++;

        // Check if the cauldron inventory is full (i.e., has 3 items)
        if (_currentCauldronInventoryIndex >= _cauldronInventory.Length)
        {
            bool isRecipePotionsCorrect = CheckRecipePotions();
            bool isRecipeIngredientsCorrect = CheckRecipeIngredients();

            if (isRecipePotionsCorrect && _firePit.GetFirePitState() == "Green")
            {
                _lastCorrectRecipe = "Recipe Potion";
                Debug.Log("Correct recipe Potion!");
                _firePit.SetFirePitState("Unlit");

                //Wwise
                AkSoundEngine.PostEvent("Play_Successful_Combination", gameObject);

                ProgressionManager.instance.SolvePuzzleTwo();
            }
            else if (isRecipeIngredientsCorrect && _firePit.GetFirePitState() == "Orange")
            {
                _lastCorrectRecipe = "Recipe Ingredient";
                Debug.Log("Correct recipe Ingredient!");
                _firePit.SetFirePitState("Unlit");

                //Wwise
                AkSoundEngine.PostEvent("Play_Successful_Combination", gameObject);
            }
            else
            {
                Debug.Log("Incorrect recipe.");
                _firePit.SetFirePitState("Unlit");

                //Wwise
                AkSoundEngine.PostEvent("Play_Wrong_Combination", gameObject);
            }

            ClearCauldronInventory();
        }
    }

    private bool CheckRecipePotions()
    {
        Dictionary<string, int> correctRecipe = new Dictionary<string, int>
        {
            { "Red", 1 },
            { "Blue", 1 },
            { "Yellow", 1 }
        };

        return IsRecipeCorrect(correctRecipe);
    }

    private bool CheckRecipeIngredients()
    {
        Dictionary<string, int> correctRecipe = new Dictionary<string, int>
        {
            { "Tooth_Correct", 1 },
            { "Eye", 1 },
            { "BatWing", 1 }
        };

        return IsRecipeCorrect(correctRecipe);
    }

    private bool IsRecipeCorrect(Dictionary<string, int> recipe)
    {
        // Count the occurrences of each item type in the cauldron inventory
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

        // Check if the cauldron contents match the recipe
        foreach (var ingredient in recipe)
        {
            if (!cauldronContents.ContainsKey(ingredient.Key) || cauldronContents[ingredient.Key] != ingredient.Value)
            {
                return false;
            }
        }

        return recipe.Count == cauldronContents.Count;
    }

    private void ClearCauldronInventory()
    {
        for (int i = 0; i < _cauldronInventory.Length; i++)
        {
            _cauldronInventory[i] = "";
        }
        _currentCauldronInventoryIndex = 0;
    }
}
