using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCIgnore : MonoBehaviour
{
    private static CCIgnore instance;
    public static CCIgnore Instance => instance;
    [SerializeField] private CharacterController cc;
    public Collider currentGrab;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void FixedUpdate()
    {
        if (currentGrab == null) return;
        Physics.IgnoreCollision(cc, currentGrab);
    }
}
