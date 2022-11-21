using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WheyController : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable m_grab;
    public bool isGrab = false;
    public bool released = false;
    [SerializeField] private Collider col;
    private void Start()
    {
        m_grab.selectEntered.AddListener(OnGrab);
        m_grab.selectExited.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        m_grab.selectEntered.RemoveListener(OnGrab);
        m_grab.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrab = true;
        CCIgnore.Instance.currentGrab = col;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        released = true;
    }
}
