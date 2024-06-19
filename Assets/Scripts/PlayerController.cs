using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    #region Camera Controls

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float fov = 60f;
    [SerializeField]
    private bool invertYAxis = false;
    [SerializeField]
    private bool enableCameraMovement = true;
    [SerializeField]
    private float sensitivity = 2f;
    [SerializeField]
    private float maxVerticalAngle = 100f;
    [SerializeField]
    private bool lockCursor = true;
    [SerializeField]
    private bool showCrosshair = true;
    [SerializeField]
    private Sprite crosshairSprite;
    [SerializeField]
    private Color crosshairTint = Color.white;

    private float _rotationY = 0.0f;
    private float _rotationX = 0.0f;

    [SerializeField]
    private Image crosshair;

    #endregion

    #region Movement Controls

    [SerializeField]
    private bool canMove = true;
    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private bool allowCrouch = true;
    [SerializeField]
    private KeyCode crouchKey = KeyCode.LeftControl;
    [SerializeField]
    private float crouchHeightScale = 0.75f;
    [SerializeField]
    private float crouchSpeedFactor = 0.5f;

    private bool _isCrouching = false;
    private Vector3 _originalScale;

    #endregion

    #region Wwise
    [SerializeField]
    private float footstepsFrequency = 125;

    private bool _footstepsIsPlaying = false;
    private float _lastFootstepTime = 0;

    #endregion*

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _originalScale = transform.localScale;

        cam.fieldOfView = fov;

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (showCrosshair)
        {
            crosshair.sprite = crosshairSprite;
            crosshair.color = crosshairTint;
        }
        else
        {
            crosshair.gameObject.SetActive(false);
        }

       //Wwise
        _lastFootstepTime = Time.time;
    }

    private void Update()
    {
        HandleCameraMovement();
        HandleCrouch();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleCameraMovement()
    {
        if (enableCameraMovement)
        {
            _rotationY += Input.GetAxis("Mouse X") * sensitivity;

            if (!invertYAxis)
            {
                _rotationX -= sensitivity * Input.GetAxis("Mouse Y");
            }
            else
            {
                _rotationX += sensitivity * Input.GetAxis("Mouse Y");
            }

            _rotationX = Mathf.Clamp(_rotationX, -maxVerticalAngle, maxVerticalAngle);

            transform.localEulerAngles = new Vector3(0, _rotationY, 0);
            cam.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
        }
    }

    private void HandleMovement()
    {
        if (canMove)
        {
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity) * movementSpeed;

            Vector3 velocity = _rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -movementSpeed, movementSpeed);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -movementSpeed, movementSpeed);
            velocityChange.y = 0;

            _rb.AddForce(velocityChange, ForceMode.VelocityChange);

            //Player Movement Sound
            if ((targetVelocity.x != 0 || targetVelocity.z != 0) && !_footstepsIsPlaying)
            {
                AkSoundEngine.PostEvent("Play_Footsteps", gameObject);
                _lastFootstepTime = Time.time;
                _footstepsIsPlaying = true;
            }
            else if (movementSpeed > 0 && Time.time - _lastFootstepTime > footstepsFrequency / movementSpeed * Time.deltaTime)
            {
                _footstepsIsPlaying = false;
            }
        }
    }

    private void HandleCrouch()
    {
        if (allowCrouch)
        {
            if (Input.GetKeyDown(crouchKey))
            {
                _isCrouching = !_isCrouching;
                if (_isCrouching)
                {
                    transform.localScale = new Vector3(_originalScale.x, crouchHeightScale, _originalScale.z);
                    movementSpeed *= crouchSpeedFactor;
                }
                else
                {
                    transform.localScale = _originalScale;
                    movementSpeed /= crouchSpeedFactor;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grass"))
        {
            AkSoundEngine.SetSwitch("Footsteps", "Grass", gameObject);
        }
    }
}
