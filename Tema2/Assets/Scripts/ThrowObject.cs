using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowObject : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private float throwForce = 10f;
    private Animator targetAnimator;
    private Animator targetAnimator2;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
        grabInteractable.onHoverEnter.AddListener(OnHoverEnter);
        grabInteractable.onHoverExit.AddListener(OnHoverExit);

        GameObject gameObject = GameObject.Find("RightHand");
        GameObject gameObject2 = GameObject.Find("LeftHand");

        targetAnimator = gameObject.GetComponent<Animator>();
        targetAnimator2 = gameObject2.GetComponent<Animator>();

    }

    void OnGrab(XRBaseInteractor interactor)
    {
        string controllerName = interactor.gameObject.name;

        if (controllerName.Contains("Right Controller"))
        {
            targetAnimator.SetBool("isGrab", true);
            targetAnimator.SetBool("isPoint", false);

        }
        else if (controllerName.Contains("Left Controller"))
        {
            targetAnimator2.SetBool("isGrab", true);
            targetAnimator2.SetBool("isPoint", false);
        }

    }

    void OnRelease(XRBaseInteractor interactor)
    {
        string controllerName = interactor.gameObject.name;

        if (controllerName.Contains("Right Controller"))
        {
            targetAnimator.SetBool("isGrab", false);

        }
        else if (controllerName.Contains("Left Controller"))
        {
            targetAnimator2.SetBool("isGrab", false);

        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(interactor.attachTransform.forward * throwForce, ForceMode.Impulse);
        }

    }

    void OnHoverEnter(XRBaseInteractor interactor)
    {
        string controllerName = interactor.gameObject.name;

        if (controllerName.Contains("Right Controller"))
        {
            targetAnimator.SetBool("isPoint", true);

        }
        else if (controllerName.Contains("Left Controller"))
        {
            targetAnimator2.SetBool("isPoint", true);

        }
    }

    void OnHoverExit(XRBaseInteractor interactor)
    {
        string controllerName = interactor.gameObject.name;

        if (controllerName.Contains("Right Controller"))
        {
            targetAnimator.SetBool("isPoint", false);

        }
        else if (controllerName.Contains("Left Controller"))
        {
            targetAnimator2.SetBool("isPoint", false);

        }
    }



}
