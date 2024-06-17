using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PotionData_Loader
{
    public static void LoadPotionhData(GameObject[] potions)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "JSON", "potionData.json");

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            List<PotionData> potionDataList = JsonUtility.FromJson<PotionDataList>(dataAsJson).potions;

            // Randomize the order of torch data
            potionDataList.Shuffle();

            // Set torches to the randomized colors
            for (int i = 0; i < potionDataList.Count; i++)
            {
                Potion potion = potions[i].GetComponent<Potion>();
                if (potion != null)
                {
                    // Map color string to TorchState enum
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

    // Map color string to TorchState enum
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


