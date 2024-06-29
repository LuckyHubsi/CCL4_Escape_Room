using System.Collections;
using UnityEngine;

public class WitchBehavior : MonoBehaviour
{
    #region Reference Objects
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform cauldronPosition;
    [SerializeField]
    private Transform walkStartPoint;
    [SerializeField]
    private Transform walkEndPoint;
    [SerializeField]
    private Material matTransition;
    [SerializeField]
    private Material matMirror;
    [SerializeField]
    private GameObject mirror;
    #endregion

    public bool isWatching; // Boolean to control watching state
    public int currentWitchState = 0;

    private float pouringAnimationDuration = 4.542f;
    private float walkTime = 2f; // This time is used to calculate the speed
    private float teleportBackTime;
    private Quaternion initialRotation; // Store the initial rotation
    private float idleAnimationDuration = 3; // Duration of the idle animation
    private WitchManager witchManager; // Reference to the WitchManager

    [SerializeField]
    private Material[] matPotion;

    [SerializeField]
    private GameObject potion;

    private void Start()
    {
        animator = GetComponent<Animator>();
        teleportBackTime = Random.Range(1f, 5f);
        initialRotation = transform.rotation; // Store the initial rotation
        witchManager = FindObjectOfType<WitchManager>(); // Get the WitchManager
        StartCoroutine(WitchCycle());
    }

    private IEnumerator WitchCycle()
    {
        while (true)
        {
            // Randomly select and assign a material from the matPotion array
            if (matPotion.Length > 0)
            {
                Material randomMaterial = matPotion[Random.Range(0, matPotion.Length)];
                potion.GetComponent<Renderer>().material = randomMaterial;
            }

            // Pouring animation
            animator.Play("Pouring");
            currentWitchState = 1;
            yield return new WaitForSeconds(pouringAnimationDuration);

            // Idle animation near the cauldron
            animator.Play("Idle");
            currentWitchState = 2;
            yield return new WaitForSeconds(idleAnimationDuration);

            yield return StartCoroutine(Transition(0.25f));

            // Teleport to walk start point and walk to end point
            TeleportToPosition(walkStartPoint.position);
            transform.rotation = Quaternion.LookRotation(walkEndPoint.position - walkStartPoint.position); // Face the end point
            animator.Play("Walking");
            currentWitchState = 3;
            yield return StartCoroutine(WalkToPosition(walkEndPoint.position));

            // Idle animation after walking for at least 3 seconds
            animator.Play("Idle");
            currentWitchState = 4;
            yield return new WaitForSeconds(idleAnimationDuration);

            // Continue idling while isWatching is true
            while (isWatching)
            {
                yield return null;
            }

            yield return StartCoroutine(Transition(0.25f));

            // Teleport back to cauldron
            TeleportToPosition(cauldronPosition.position);
            transform.rotation = initialRotation; // Reset to initial rotation
        }
    }

    private void TeleportToPosition(Vector3 position)
    {
        transform.position = position;
    }

    private IEnumerator Transition(float duration)
    {
        yield return new WaitForSeconds(duration);
        mirror.GetComponent<Renderer>().material = matTransition;
        yield return new WaitForSeconds(duration);
        mirror.GetComponent<Renderer>().material = matMirror;
    }

    private IEnumerator WalkToPosition(Vector3 endPoint)
    {
        float speed = Vector3.Distance(transform.position, endPoint) / walkTime;
        while (Vector3.Distance(transform.position, endPoint) > 0.1f) // Stop when close enough to the end point
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
            animator.Play("Walking"); // Continuously play the walking animation
            yield return null;
        }
        transform.position = endPoint; // Snap to the exact end point to avoid jittering
    }
}
