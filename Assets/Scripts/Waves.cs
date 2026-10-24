using UnityEngine;
using System.Collections;

public class Waves : MonoBehaviour
{
    public Vector3 movementOffset = new Vector3(5f, 0f, 0f);
    public float moveSpeed = 2f;
    public float startDelay = 2f;
    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + movementOffset;
        StartCoroutine(StartMoving());
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            yield return StartCoroutine(MoveToPosition(endPosition));
            yield return StartCoroutine(MoveToPosition(startPosition));
        }
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;
    }
}