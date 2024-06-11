using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TorchData_Loader : MonoBehaviour
{
    public GameObject[] torches; // Reference to the torch game objects in the scene

    private void Start()
    {
        LoadTorchData();
    }

    public void LoadTorchData()
    {
        string filePath = Path.Combine(Application.dataPath, "Data", "torchData.json");

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            List<TorchData> torchDataList = JsonUtility.FromJson<TorchDataList>(dataAsJson).torches;

            // Randomize the order of torch data
            torchDataList.Shuffle();

            // Set torches to the randomized colors
            for (int i = 0; i < torchDataList.Count; i++)
            {
                Torch torch = torches[i].GetComponent<Torch>();
                if (torch != null)
                {
                    // Map color string to TorchState enum
                    Torch.TorchState state = TorchStateFromString(torchDataList[i].color);
                    torch.SetTorchState(state);
                }
            }
        }
        else
        {
            Debug.LogError("Torch data file not found at path: " + filePath);
        }
    }


    // Map color string to TorchState enum
    Torch.TorchState TorchStateFromString(string color)
    {
        switch (color.ToLower())
        {
            case "red":
                return Torch.TorchState.Red;
            case "blue":
                return Torch.TorchState.Blue;
            case "yellow":
                return Torch.TorchState.Yellow;
            default:
                return Torch.TorchState.Unlit;
        }
    }
}

[System.Serializable]
public class TorchData
{
    public string color;
}

[System.Serializable]
public class TorchDataList
{
    public List<TorchData> torches;
}

public static class ListExtensions
{
    // Extension method to shuffle a list
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}