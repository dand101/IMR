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
    }

    void OnGrab(XRBaseInteractor interactor)
    {

    }

    void OnRelease(XRBaseInteractor interactor)
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(interactor.attachTransform.forward * throwForce, ForceMode.Impulse);
        }
    }

    
}
