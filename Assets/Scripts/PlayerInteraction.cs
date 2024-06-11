using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private Camera _cam;
    [SerializeField]
    private Torch _carriedTorch;
    [SerializeField]
    private Text interactableNameText;

    private Outline _currentOutline;
    private bool _playerHoldingItem = false;

    private void Awake()
    {
        _cam = GetComponentInChildren<Camera>();
        if (_cam == null)
        {
            Debug.LogError("Camera not found on player.");
        }

        if (interactableNameText == null)
        {
            Debug.LogError("InteractableNameText not assigned in the Inspector.");
        }
    }

    private void Update()
    {
        HandleInteraction();
        PlayerLineOfSight();
    }

    private void HandleInteraction()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, 2f))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }

    public void PickUpTorch(Torch torch)
    {
        torch.gameObject.SetActive(false);
        _carriedTorch.gameObject.SetActive(true);
        _playerHoldingItem = true;
    }

    public void CombineTorch(Torch torch)
    {
        if (_carriedTorch != null)
        {
            if (_carriedTorch.torchState == Torch.TorchState.Red && torch.torchState == Torch.TorchState.Blue || _carriedTorch.torchState == Torch.TorchState.Blue && torch.torchState == Torch.TorchState.Red)
            {
                _carriedTorch.SetTorchState(Torch.TorchState.Purple);
                Debug.Log("Player Torch: Purple");
            }

            if (_carriedTorch.torchState == Torch.TorchState.Unlit)
            {
                if (torch.torchState == Torch.TorchState.Red)
                {
                    _carriedTorch.SetTorchState(Torch.TorchState.Red);
                    Debug.Log("Player Torch: Red");
                }
                if (torch.torchState == Torch.TorchState.Blue)
                {
                    _carriedTorch.SetTorchState(Torch.TorchState.Blue);
                    Debug.Log("Player Torch: Blue");
                }
            }
        }
    }

    public Torch GetCarriedTorch()
    {
        return _carriedTorch;
    }

    private void PlayerLineOfSight()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, 2f))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                // Update the UI text with the interaction message
                if (_playerHoldingItem)
                {
                    interactableNameText.text = "Press 'E' to interact";
                }
                else
                {
                    interactableNameText.text = interactable.gameObject.name;
                }

                // Handle the outline
                Outline outline = interactable.GetComponent<Outline>();
                if (outline != null)
                {
                    // If the current outlined object is different, disable the previous outline
                    if (_currentOutline != null && _currentOutline != outline)
                    {
                        _currentOutline.enabled = false;
                    }

                    // Enable the new outline
                    outline.enabled = true;
                    _currentOutline = outline;
                }
                else if (_currentOutline != null)
                {
                    // If there's no outline on the current interactable, disable the previous outline
                    _currentOutline.enabled = false;
                    _currentOutline = null;
                }
            }
            else
            {
                // If there's no interactable, disable the previous outline and clear the text
                if (_currentOutline != null)
                {
                    _currentOutline.enabled = false;
                    _currentOutline = null;
                }
                interactableNameText.text = "";
            }
        }
        else
        {
            // If the raycast doesn't hit anything, disable the previous outline and clear the text
            if (_currentOutline != null)
            {
                _currentOutline.enabled = false;
                _currentOutline = null;
            }
            interactableNameText.text = "";
        }
    }
}
