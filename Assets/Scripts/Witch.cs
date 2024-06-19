using System.Collections;
using UnityEngine;

public class WitchBehavior : MonoBehaviour
{
    public Animator animator;
    public Transform cauldronPosition;
    public Transform walkStartPoint;
    public Transform walkEndPoint;
    public Material matTransition;
    public Material matMirror;
    public GameObject mirror;

    private float idleTime;
    private float pouringTime = 3f;
    private float walkTime = 2f; // This time is used to calculate the speed
    private float teleportBackTime;
    private float walkSpeed = 1.5f; // Adjust the speed to match the walking animation
    private Quaternion initialRotation; // Store the initial rotation

    private void Start()
    {
        animator = GetComponent<Animator>();
        teleportBackTime = Random.Range(1f, 5f);
        initialRotation = transform.rotation; // Store the initial rotation
        StartCoroutine(WitchCycle());
    }

    private IEnumerator WitchCycle()
    {
        while (true)
        {
            // Pouring animation
            animator.Play("Pouring");
            yield return new WaitForSeconds(pouringTime);

            // Idle animation near the cauldron
            animator.Play("Idle");
            idleTime = Random.Range(3f, 5f);
            yield return new WaitForSeconds(idleTime);

            yield return StartCoroutine(Transition(0.25f));

            // Teleport to walk start point and walk to end point
            TeleportToPosition(walkStartPoint.position);
            transform.rotation = Quaternion.LookRotation(walkEndPoint.position - walkStartPoint.position); // Face the end point
            animator.Play("Walking");

            yield return StartCoroutine(WalkToPosition(walkEndPoint.position));

            // Idle animation after walking
            animator.Play("Idle");
            idleTime = Random.Range(1f, 5f); // Random idle time
            yield return new WaitForSeconds(idleTime);

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
