using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class IngredientData_Loader
{
    public static void LoadIngredientData(GameObject[] ingredients)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "JSON", "ingredientData.json");

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            List<IngredientData> ingredientDataList = JsonUtility.FromJson<IngredientDataList>(dataAsJson).ingredients;

            // Randomize the order of torch data
            ingredientDataList.Shuffle();

            // Set torches to the randomized colors
            for (int i = 0; i < ingredientDataList.Count; i++)
            {
                Ingredient ingredient = ingredients[i].GetComponent<Ingredient>();
                if (ingredient != null)
                {
                    // Map color string to TorchState enum
                    Ingredient.IngredientState state = IngredientStateFromString(ingredientDataList[i].type);
                    ingredient.SetIngredientState(state);
                }
            }
        }
        else
        {
            Debug.LogError("Ingredient data file not found at path: " + filePath);
        }
    }

    // Map color string to IngredientState enum
    private static Ingredient.IngredientState IngredientStateFromString(string type)
    {
        switch (type.ToLower())
        {
            case "tooth_correct":
                return Ingredient.IngredientState.Tooth_Correct;
            case "batwing":
                return Ingredient.IngredientState.BatWing;
            case "eye":
                return Ingredient.IngredientState.Eye;
            case "froshtongue":
                return Ingredient.IngredientState.FroshTongue;
            case "tooth_wrong1":
                return Ingredient.IngredientState.Tooth_Wrong1;
            case "tooth_wrong2":
                return Ingredient.IngredientState.Tooth_Wrong2;
            default:
                return Ingredient.IngredientState.Empty;
        }
    }
}

[System.Serializable]
public class IngredientData
{
    public string type;
}

[System.Serializable]
public class IngredientDataList
{
    public List<IngredientData> ingredients;
}


