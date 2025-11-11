using UnityEngine;
using System.Collections.Generic;

public class TeleportTrigger : MonoBehaviour
{
    public Transform[] teleportPoints;

    private bool playerInTrigger = false;
    private Vector3 currentPosition;

    private void Start()
    {
        currentPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            TeleportToRandomPoint();
        }
    }

    private void TeleportToRandomPoint()
    {
        if (teleportPoints.Length == 0) return;
        List<Transform> availablePoints = new List<Transform>();

        foreach (Transform point in teleportPoints)
        {
            if (point != null && point.position != currentPosition)
            {
                availablePoints.Add(point);
            }
        }

        if (availablePoints.Count == 0) return;

        Transform randomPoint = availablePoints[Random.Range(0, availablePoints.Count)];
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Transition.Instance.TeleportPlayer(randomPoint.position);
        }
    }
}