using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Interactable
{
    public enum IngredientState { Empty, BatWing, Eye, FroshTongue, Tooth_Wrong1, Tooth_Wrong2, Tooth_Correct }
    [SerializeField]
    public IngredientState ingredientState = IngredientState.Empty;

    #region Material Reference for the Jar Lid
    [SerializeField]
    private Material matLid_Bat;
    [SerializeField]
    private Material matLid_Eye;
    [SerializeField]
    private Material matLid_Tongue;
    [SerializeField]
    private Material matLid_ToothWrong1;
    [SerializeField]
    private Material matLid_ToothWrong2;
    [SerializeField]
    private Material matLid_ToothRight;
    #endregion

    #region Material Reference for the Item inside the Jar
    [SerializeField]
    private Material mat_Bat;
    [SerializeField]
    private Material mat_Eye;
    [SerializeField]
    private Material mat_Tongue;
    [SerializeField]
    private Material mat_Tooth;
    #endregion

    #region Mesh Reference for the Item inside the Jar
    [SerializeField]
    private Mesh bat;
    [SerializeField]
    private Mesh eye;
    [SerializeField]
    private Mesh tongue;
    [SerializeField]
    private Mesh tooth;
    #endregion

    #region GameObject References
    [SerializeField]
    private GameObject lid;
    [SerializeField]
    private GameObject item;
    #endregion

    private PlayerInteraction _playerInteraction;

    private void Start()
    {
        _playerInteraction = FindObjectOfType<PlayerInteraction>();
        if (_playerInteraction == null)
        {
            Debug.LogError("PlayerInteraction script not found in the scene.");
        }
    }

    // Player gets reference to interacted ingredient object
    public override void Interact()
    {
        _playerInteraction.PickUpItem(this.gameObject);
    }

    public void SetIngredientState(IngredientState newState)
    {
        ingredientState = newState;
        UpdateIngredientAppearance();
    }

    // Update ingredient appearance (material of lid and item + mesh of item) based on the ingredient state
    private void UpdateIngredientAppearance()
    {
        switch (ingredientState)
        {
            case IngredientState.Empty:
                return;
            case IngredientState.BatWing:
                lid.GetComponent<Renderer>().material = matLid_Bat;
                item.GetComponent<MeshFilter>().mesh = bat;
                item.GetComponent<Renderer>().material = mat_Bat;
                break;
            case IngredientState.Eye:
                lid.GetComponent<Renderer>().material = matLid_Eye;
                item.GetComponent<MeshFilter>().mesh = eye;
                item.GetComponent<Renderer>().material = mat_Eye; 
                break;
            case IngredientState.FroshTongue:
                lid.GetComponent<Renderer>().material = matLid_Tongue;
                item.GetComponent<MeshFilter>().mesh = tongue;
                item.GetComponent<Renderer>().material = mat_Tongue; 
                break;
            case IngredientState.Tooth_Wrong1:
                lid.GetComponent<Renderer>().material = matLid_ToothWrong1;
                item.GetComponent<MeshFilter>().mesh = tooth;
                item.GetComponent<Renderer>().material = mat_Tooth; 
                break;
            case IngredientState.Tooth_Wrong2:
                lid.GetComponent<Renderer>().material = matLid_ToothWrong2;
                item.GetComponent<MeshFilter>().mesh = tooth;
                item.GetComponent<Renderer>().material = mat_Tooth;
                break;
            case IngredientState.Tooth_Correct:
                lid.GetComponent<Renderer>().material = matLid_ToothRight;
                item.GetComponent<MeshFilter>().mesh = tooth;
                item.GetComponent<Renderer>().material = mat_Tooth;
                break;
        }
    }
}
