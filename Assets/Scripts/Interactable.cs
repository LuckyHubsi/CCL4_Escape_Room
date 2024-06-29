using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interactable base class, which all interactable objects inherit from
public class Interactable : MonoBehaviour
{
    // A virtual method that can be overridden by derived classes to define specific interaction behavior
    public virtual void Interact() { }
}
