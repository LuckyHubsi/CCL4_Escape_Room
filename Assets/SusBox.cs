using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusBox : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private WitchManager witchManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            witchManager.PlayerEnteredBox(); // Notify the Game Manager
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            witchManager.PlayerExitedBox(); // Notify the Game Manager
        }
    }
}
