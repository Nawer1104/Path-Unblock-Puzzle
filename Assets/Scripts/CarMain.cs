using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMain : MonoBehaviour
{
    public LayerMask layerMask; // Define which layers the ray should collide with

    public Transform target;

    public float speed;

    private bool isCompleted;

    private void Awake()
    {
        isCompleted = false;
    }

    void Update()
    {
        if (isCompleted) return;

        // Cast a ray from the current position in the direction of Vector2.right
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layerMask);

        // If the ray hits something
        if (hit.collider == null)
        {
            Vector3 destination = target.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05)
            {
                isCompleted = true;
                GameManager.Instance.CheckLevelUp();
            }
        }
    }
}
