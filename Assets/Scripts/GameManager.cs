using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private Dictionary<string, Vector3> _originalPositions = new Dictionary<string, Vector3>();

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add a method to store original positions
    public void StoreOriginalPosition(string objectId, Vector3 position)
    {
        if (!_originalPositions.ContainsKey(objectId))
        {
            _originalPositions.Add(objectId, position);
        }
        else
        {
            _originalPositions[objectId] = position;
        }
    }

    // Add a method to reset object position
    public void ResetObjectPosition(GameObject obj)
    {
        string objectId = obj.name; // You can use a unique identifier for the object
        if (_originalPositions.ContainsKey(objectId))
        {
            obj.transform.position = _originalPositions[objectId];
        }
        else
        {
            Debug.LogError("Original position not found for object: " + objectId);
        }
    }

    // Add a method to load positions from JSON
    public void LoadPositionsFromJSON(string json)
    {
        // Implement your JSON parsing logic here to load positions
    }
}