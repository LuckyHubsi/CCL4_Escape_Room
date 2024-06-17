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
    [SerializeField]
    private Ingredient _carriedIngredient;
    [SerializeField]
    private Bucket _carriedBucket;
    [SerializeField]
    private Key _carriedKey;


    private Outline _currentOutline;
    private bool _playerHoldingItem = false;
    private Torch _pickedUpTorch;
    private Potion _pickedUpPotion;
    private Ingredient _pickedUpIngredient;
    private Bucket _pickedUpBucket;
    private Key _pickedUpKey;

    //Wwise Cough
    private float _initialSmokeTimer = 0;
    private float _smokeTimer = 0;
    private float _coughCounter = 0;
    private float _lastCoughTime = 0;

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
        //Wwise
        _lastCoughTime = Time.time;
    }

    private void Start()
    {
        //Wwise
        _initialSmokeTimer = Mathf.Round(GameManager.instance.GetRemainingSmokeTimer());
    }

    private void Update()
    {
        HandleInteraction();
        PlayerLineOfSight();
        HandleDroppingItem();

        //Wwise
        _smokeTimer = Mathf.Round(GameManager.instance.GetRemainingSmokeTimer());
        HandleSmokeCough();
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
                if (_carriedPotion.isActiveAndEnabled)
                {
                    //Wwise
                    AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Dropping_Potion", gameObject);
                    AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
                }

                DropItem();
                
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
            AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Equipping_Torch", gameObject);
            AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);


            return;
        }

        Potion potion = item.GetComponent<Potion>();
        if (potion != null && !_playerHoldingItem)
        {
            _playerHoldingItem = true;

            _pickedUpPotion = potion;
            _pickedUpPotion.gameObject.SetActive(false);
            _carriedPotion.gameObject.SetActive(true);
            _carriedPotion.SetPotionState(potion.potionState);

            Debug.Log("Picked up " + _carriedPotion.potionState + " Potion");

            //Wwise
            AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Equipping_Potion", gameObject);
            AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);

            return;
        }

        Ingredient ingredient = item.GetComponent<Ingredient>();
        if (ingredient != null && !_playerHoldingItem)
        {
            _playerHoldingItem = true;

            _pickedUpIngredient = ingredient;
            _pickedUpIngredient.gameObject.SetActive(false);
            _carriedIngredient.gameObject.SetActive(true);
            _carriedIngredient.SetIngredientState(ingredient.ingredientState);

            Debug.Log("Picked up " + _carriedIngredient.ingredientState + " Ingredient");

            return;
        }

        Bucket bucket = item.GetComponent<Bucket>();
        if (bucket != null && !_playerHoldingItem)
        {
            _playerHoldingItem = true;

            _pickedUpBucket = bucket;
            _pickedUpBucket.gameObject.SetActive(false);
            _carriedBucket.gameObject.SetActive(true);
            _carriedBucket.SetBucketState(bucket.bucketState);

            Debug.Log("Picked up " + _carriedBucket.bucketState + " Bucket");

            //Wwise
            AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Equip_Bucket", gameObject);
            AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);

        }

        Key key = item.GetComponent<Key>();
        if (key != null && !_playerHoldingItem)
        {
            _playerHoldingItem = true;

            _pickedUpKey = key;
            _pickedUpKey.gameObject.SetActive(false);
            _carriedKey.gameObject.SetActive(true);
            _carriedKey.SetKeyState(key.keyState);

            Debug.Log("Picked up " + _carriedKey.keyState + " Key");

            //Wwise
            AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Equipping_Key", gameObject);
            AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
            
        }
    }

    public void DropItem()
    {
        _playerHoldingItem = false;

        if (_pickedUpTorch != null)
        {
            if (_carriedTorch.isActiveAndEnabled)
            {
                //Wwise
                AkSoundEngine.PostEvent("Stop_Player_Interact", gameObject);
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Dropping_Torch", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
            }

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

        if (_pickedUpIngredient != null)
        {
            _pickedUpIngredient.gameObject.SetActive(true);
            _carriedIngredient.SetIngredientState(Ingredient.IngredientState.Empty);
            _carriedIngredient.gameObject.SetActive(false);
        }

        if (_pickedUpBucket != null)
        {
            if (_carriedBucket.isActiveAndEnabled)
            {
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Drop_Bucket", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
            }
            _pickedUpBucket.gameObject.SetActive(true);
            _carriedBucket.SetBucketState(Bucket.BucketState.Empty);
            _carriedBucket.gameObject.SetActive(false);
        }

        if (_pickedUpKey != null)
        {
            if (_carriedKey.isActiveAndEnabled)
            {
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Drop_Key", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
            }
            _pickedUpKey.gameObject.SetActive(true);
            _carriedKey.SetKeyState(Key.KeyState.inActive);
            _carriedKey.gameObject.SetActive(false);
        }

    }

    public Torch GetCarriedTorch()
    {
        return _carriedTorch;
    }

    public Potion GetCarriedPotion()
    {
        return _carriedPotion;
    }

    public Ingredient GetCarriedIngredient()
    {
        return _carriedIngredient;
    }

    public Bucket GetCarriedBucket()
    {
        return _carriedBucket;
    }

    public Key GetCarriedKey()
    {
        return _carriedKey;
    }

    public void CombineTorch(Torch torch)
    {
        if (_playerHoldingItem && !_carriedPotion.gameObject.activeSelf)
        {
            if (_carriedTorch.torchState == Torch.TorchState.Red && torch.torchState == Torch.TorchState.Blue || _carriedTorch.torchState == Torch.TorchState.Blue && torch.torchState == Torch.TorchState.Red)
            {
                _carriedTorch.SetTorchState(Torch.TorchState.Purple);
                Debug.Log("Player Torch: Purple");

                //Wwise
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Combining_Torch", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
            }
            if (_carriedTorch.torchState == Torch.TorchState.Red && torch.torchState == Torch.TorchState.Yellow || _carriedTorch.torchState == Torch.TorchState.Yellow && torch.torchState == Torch.TorchState.Red)
            {
                _carriedTorch.SetTorchState(Torch.TorchState.Orange);
                Debug.Log("Player Torch: Orange");

                //Wwise
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Combining_Torch", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
            }
            if (_carriedTorch.torchState == Torch.TorchState.Yellow && torch.torchState == Torch.TorchState.Blue || _carriedTorch.torchState == Torch.TorchState.Blue && torch.torchState == Torch.TorchState.Yellow)
            {
                _carriedTorch.SetTorchState(Torch.TorchState.Green);
                Debug.Log("Player Torch: Purple");

                //Wwise
                AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Combining_Torch", gameObject);
                AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
            }

            if (_carriedTorch.torchState == Torch.TorchState.Unlit)
            {
                if (torch.torchState == Torch.TorchState.Red)
                {
                    _carriedTorch.SetTorchState(Torch.TorchState.Red);
                    Debug.Log("Player Torch: Red");

                    //Wwise
                    AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Other_Torch_Interaction", gameObject);
                    AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
                }
                if (torch.torchState == Torch.TorchState.Blue)
                {
                    _carriedTorch.SetTorchState(Torch.TorchState.Blue);
                    Debug.Log("Player Torch: Blue");

                    //Wwise
                    AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Other_Torch_Interaction", gameObject);
                    AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
                }
                if (torch.torchState == Torch.TorchState.Yellow)
                {
                    _carriedTorch.SetTorchState(Torch.TorchState.Yellow);
                    Debug.Log("Player Torch: Yellow");

                    //Wwise
                    AkSoundEngine.SetSwitch("PlayerInteractSwitch", "Other_Torch_Interaction", gameObject);
                    AkSoundEngine.PostEvent("Play_Player_Interact", gameObject);
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

    //Wwise Coughing Sound
    private void HandleSmokeCough()
    {
        if (_smokeTimer % 20 == 0 && Time.time - _lastCoughTime > 1 && _smokeTimer != _initialSmokeTimer)
        {
            if (_coughCounter > 0 && _coughCounter < 2)
            {
                AkSoundEngine.SetSwitch("Coughing", "Medium", gameObject);
            }
            else if (_coughCounter > 1 && _coughCounter < 3)
            {
                AkSoundEngine.SetSwitch("Coughing", "Heavy", gameObject);
            }
            AkSoundEngine.PostEvent("Play_Coughing", gameObject);
            _coughCounter++;
            _lastCoughTime = Time.time;
        }
    }
}
