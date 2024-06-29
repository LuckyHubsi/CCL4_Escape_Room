using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PotionData_Loader
{
    // Method to load potion data from a JSON file and apply it to the provided potions
    public static void LoadPotionhData(GameObject[] potions)
    {
        // Construct the file path for the JSON data file
        string filePath = Path.Combine(Application.streamingAssetsPath, "JSON", "potionData.json");

        if (File.Exists(filePath))
        {
            // Read the JSON data from the file
            string dataAsJson = File.ReadAllText(filePath);
            // Deserialize the JSON data into a list of PotionData
            List<PotionData> potionDataList = JsonUtility.FromJson<PotionDataList>(dataAsJson).potions;

            // Randomize the order of potion data
            potionDataList.Shuffle();

            // Set potions to the randomized colors
            for (int i = 0; i < potionDataList.Count; i++)
            {
                Potion potion = potions[i].GetComponent<Potion>();
                if (potion != null)
                {
                    // Map color string to PotionState enum
                    Potion.PotionState state = PotionStateFromString(potionDataList[i].color);
                    potion.SetPotionState(state);
                }
            }
        }
        else
        {
            Debug.LogError("Potion data file not found at path: " + filePath);
        }
    }

    // Map color string to PotionState enum
    private static Potion.PotionState PotionStateFromString(string color)
    {
        switch (color.ToLower())
        {
            case "red":
                return Potion.PotionState.Red;
            case "blue":
                return Potion.PotionState.Blue;
            case "yellow":
                return Potion.PotionState.Yellow;
            case "purple":
                return Potion.PotionState.Purple;
            case "green":
                return Potion.PotionState.Green;
            case "orange":
                return Potion.PotionState.Orange;
            default:
                return Potion.PotionState.Empty;
        }
    }
}

[System.Serializable]
public class PotionData
{
    public string color;
}

[System.Serializable]
public class PotionDataList
{
    public List<PotionData> potions;
}


