using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float attackDistance = 0.25f;
    public Transform character1;
    public Transform character2;

    private Animator character1Animator;
    private Animator character2Animator;

    // Start is called before the first frame update
    void Start()
    {

        character1Animator = character1.GetComponentInChildren<Animator>();
        character2Animator = character2.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        float distanceBetweenChars = Vector3.Distance(character1.position, character2.position);

        //Debug.Log("distance is " + distanceBetweenChars);
        if (distanceBetweenChars <= attackDistance)
        {
            setAnimations(true);
        }
        else
        {
            setAnimations(false);
        }

    }

    private void setAnimations(bool value)
    {
        character1Animator.SetBool("isAttacking", value);
        character2Animator.SetBool("isAttacking", value);
    }
}
