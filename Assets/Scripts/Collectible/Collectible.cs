using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject pickupEffect;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            collectibleManager.Instance.AddCollectible();

            if (pickupEffect)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}