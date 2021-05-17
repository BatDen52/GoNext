using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Boat>(out Boat boat))
        {
            boat.transform.position = _transform.position;
        }
    }
}
