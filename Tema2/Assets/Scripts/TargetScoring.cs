using UnityEngine;

public class TargetScoring : MonoBehaviour
{
    public int scoreValue = 10;

    void OnCollisionEnter(Collision collision)
    {

        ThrowObject throwObject = collision.gameObject.GetComponent<ThrowObject>();

        if (throwObject != null)
        {

            GameManager.instance.AddScore(scoreValue);
        }
    }
}
