using UnityEngine;

public class TargetScoring : MonoBehaviour
{
    public Animator targetAnimator;
    public GameObject Player;
    public GameObject explosionFirePrefab;

    void OnCollisionEnter(Collision collision)
    {

        ThrowObject throwObject = collision.gameObject.GetComponent<ThrowObject>();

        if (throwObject != null)
        {
            Vector3 playerPosition = Player.transform.position;


            float distance = Vector3.Distance(playerPosition, transform.position);

            int scoreValue = Mathf.RoundToInt(distance);


            GameManager.instance.AddScore(scoreValue);

            if (targetAnimator != null)
            {
                targetAnimator.SetTrigger("IsHit");
            }

            Vector3 particleSpawnPosition = new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z);
            GameObject explosion = Instantiate(explosionFirePrefab, particleSpawnPosition, Quaternion.identity);

            Destroy(collision.gameObject,0.5f);
            Destroy(explosion, 3f);

        }
    }
}
