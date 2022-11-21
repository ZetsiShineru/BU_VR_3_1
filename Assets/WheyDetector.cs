using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class WheyDetector : MonoBehaviour
{
    [SerializeField] private string targetTag = "Untagged";

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            WheyController whc = other.GetComponentInParent<WheyController>();
            if (whc != null)
            {
                if (whc.isGrab)
                {
                    Rigidbody rb = other.GetComponentInParent<Rigidbody>();
                    if (rb != null)
                    {
                        Destroy(rb.gameObject);
                        GameManager.Instance.AddScore();
                        print("Collected Whey!");
                    }
                }
            }

        }
    }
}
