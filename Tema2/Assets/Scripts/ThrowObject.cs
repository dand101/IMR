using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowObject : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public float throwForce = 10f;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
        grabInteractable.onHoverEnter.AddListener(OnHoverEnter);
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        Debug.Log("Grabbed");
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        Debug.Log("Released");
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(interactor.attachTransform.forward * throwForce, ForceMode.Impulse);
        }
    }

    void OnHoverEnter(XRBaseInteractor interactor)
    {
        Debug.Log("Hovering over object: " + gameObject.name);
    }





}
