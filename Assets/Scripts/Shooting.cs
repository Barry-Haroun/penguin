using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float singDistance;
    [SerializeField] private float singRadius;
    [SerializeField] private GameObject singVolume;
    [SerializeField] private GameObject singRay;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SingleSinging();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            MultipleSinging();
        }

        singRay.SetActive(Input.GetKey(KeyCode.Z));
        singVolume.SetActive(Input.GetKey(KeyCode.X));
    }

    private void SingleSinging()
    {
        RaycastHit hit;
        bool result = Physics.Raycast(transform.position, transform.forward, out hit, singDistance);

        if (result)
        {
            Health health = hit.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(50);
            }
        }
    }

    private void MultipleSinging()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, singRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<Health>() != null)
            {
                Health health = hitCollider.GetComponent<Health>();
                health.TakeDamage(10);
            }
        }
    }
}