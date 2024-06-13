using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private Camera _cam;
    [SerializeField]
    private Text interactableNameText;
    [SerializeField]
    private Torch _carriedTorch;
    [SerializeField]
    private Potion _carriedPotion;


    private Outline _currentOutline;
    private bool _playerHoldingItem = false;
    private Torch _pickedUpTorch;
    private Potion _pickedUpPotion;

/*    //Wwise
    [SerializeField]
    private AK.Wwise.Event playerInterActionPlayEvent;*/

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
        HandleDroppingItem();
    }

    private void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
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

    private void HandleDroppingItem()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_playerHoldingItem)
            {
                if (_carriedTorch != null)
                {
                    DropItem();
                }
            }
        }
    }

    public void PickUpItem(GameObject item)
    {
        Torch torch = item.GetComponent<Torch>();
        if (torch != null && !_playerHoldingItem)
        {
            _playerHoldingItem = true;

            _pickedUpTorch = torch;
            _pickedUpTorch.gameObject.SetActive(false);
            _carriedTorch.gameObject.SetActive(true);

            // Wwise
            // AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Equipping_Torch", gameObject);
            // playerInterActionPlayEvent.Post(gameObject);

            return;
        }

        Potion potion = item.GetComponent<Potion>();
        if (potion != null && !_playerHoldingItem)
        {
            _playerHoldingItem = true;

            _pickedUpPotion = potion;
            _pickedUpPotion.gameObject.SetActive(false);
            _carriedPotion.gameObject.SetActive(true);
            _carriedPotion.potionState = potion.potionState;

            Debug.Log("Picked up " + _carriedPotion.potionState + " Potion");

            return;
        }
    }

    public void DropItem()
    {
        _playerHoldingItem = false;

        if (_pickedUpTorch != null)
        {
            _pickedUpTorch.gameObject.SetActive(true);
            _carriedTorch.SetTorchState(Torch.TorchState.Unlit);
            _carriedTorch.gameObject.SetActive(false);
        }

        if (_pickedUpPotion != null)
        {
            _pickedUpPotion.gameObject.SetActive(true);
            _carriedPotion.SetPotionState(Potion.PotionState.Empty);
            _carriedPotion.gameObject.SetActive(false);
        }


/*        //Wwise
        AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Dropping_Torch", gameObject);
        playerInterActionPlayEvent.Post(gameObject);*/
    }

    public Torch GetCarriedTorch()
    {
        return _carriedTorch;
    }

    public Potion GetCarriedPotion()
    {
        return _carriedPotion;
    }

    public void CombineTorch(Torch torch)
    {
        if (_playerHoldingItem && !_carriedPotion.gameObject.activeSelf)
        {
            if (_carriedTorch.torchState == Torch.TorchState.Red && torch.torchState == Torch.TorchState.Blue || _carriedTorch.torchState == Torch.TorchState.Blue && torch.torchState == Torch.TorchState.Red)
            {
                _carriedTorch.SetTorchState(Torch.TorchState.Purple);
                Debug.Log("Player Torch: Purple");

/*                //Wwise
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Combining_Torch", gameObject);
                playerInterActionPlayEvent.Post(gameObject);*/
            }
            if (_carriedTorch.torchState == Torch.TorchState.Red && torch.torchState == Torch.TorchState.Yellow || _carriedTorch.torchState == Torch.TorchState.Yellow && torch.torchState == Torch.TorchState.Red)
            {
                _carriedTorch.SetTorchState(Torch.TorchState.Orange);
                Debug.Log("Player Torch: Orange");

                /*                //Wwise
                                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Combining_Torch", gameObject);
                                playerInterActionPlayEvent.Post(gameObject);*/
            }
            if (_carriedTorch.torchState == Torch.TorchState.Yellow && torch.torchState == Torch.TorchState.Blue || _carriedTorch.torchState == Torch.TorchState.Blue && torch.torchState == Torch.TorchState.Yellow)
            {
                _carriedTorch.SetTorchState(Torch.TorchState.Green);
                Debug.Log("Player Torch: Purple");

                /*                //Wwise
                                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Combining_Torch", gameObject);
                                playerInterActionPlayEvent.Post(gameObject);*/
            }

            if (_carriedTorch.torchState == Torch.TorchState.Unlit)
            {
                if (torch.torchState == Torch.TorchState.Red)
                {
                    _carriedTorch.SetTorchState(Torch.TorchState.Red);
                    Debug.Log("Player Torch: Red");

/*                    //Wwise
                    AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Other_Torch_Interaction", gameObject);
                    playerInterActionPlayEvent.Post(gameObject);*/
                }
                if (torch.torchState == Torch.TorchState.Blue)
                {
                    _carriedTorch.SetTorchState(Torch.TorchState.Blue);
                    Debug.Log("Player Torch: Blue");

/*                    //Wwise
                    AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Other_Torch_Interaction", gameObject);
                    playerInterActionPlayEvent.Post(gameObject);*/
                }
                if (torch.torchState == Torch.TorchState.Yellow)
                {
                    _carriedTorch.SetTorchState(Torch.TorchState.Yellow);
                    Debug.Log("Player Torch: Yellow");

/*                    //Wwise
                     AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Other_Torch_Interaction", gameObject);
                     playerInterActionPlayEvent.Post(gameObject);*/
                }
            }
        }
    }

    private void PlayerLineOfSight()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, 2f))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                Outline outline = interactable.GetComponent<Outline>();

                // Update the UI text with the interaction message
                if (_playerHoldingItem && outline == null)
                {
                    interactableNameText.text = "Press 'E' to interact";
                }
                if (_playerHoldingItem && outline != null)
                {
                    interactableNameText.text = "Your hand is full";
                }
                if (!_playerHoldingItem && outline == null)
                {
                    interactableNameText.text = interactable.gameObject.name;
                }
                if (!_playerHoldingItem && outline != null)
                {
                    interactableNameText.text = "Press 'E' to pick up " + interactable.gameObject.name;
                }

                // Handle the outline
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


                if (_playerHoldingItem)
                {
                    interactableNameText.text = "Press 'Q' to drop item";
                }
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


            if (_playerHoldingItem)
            {
                interactableNameText.text = "Press 'Q' to drop item";
            }
        }
    }
}
