using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPreto : MonoBehaviour
{
    [SerializeField] private GameObject preto;
    [SerializeField] private GameObject subRay;

    RaycastHit hitRay;
    public LayerMask selectionMask;
    [SerializeField] private Transform positionRay;
    [SerializeField] private float rayDistance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            subRay.transform.LookAt(other.transform.position);
            if (Physics.Raycast(positionRay.position, subRay.transform.TransformDirection(Vector3.forward), out hitRay,rayDistance,selectionMask))
            {
                if (hitRay.collider.tag == "Player")
                {
                    preto.GetComponent<TestEnemyNavMesh>().checkPlayer = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            preto.GetComponent<TestEnemyNavMesh>().checkPlayer = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(positionRay.position, subRay.transform.TransformDirection(Vector3.forward) * rayDistance);
    }
}
