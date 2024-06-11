using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Camera _cam;
    [SerializeField]
    private Torch _carriedTorch;

    private void Awake()
    {
        _cam = GetComponentInChildren<Camera>();
        if (_cam == null)
        {
            Debug.LogError("Camera not found on player.");
        }
    }

    private void Update()
    {
        HandleInteraction();
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
}
