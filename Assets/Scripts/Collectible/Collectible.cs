using UnityEngine;
using UnityEngine.Audio;

public class Collectible : MonoBehaviour
{
    public GameObject pickupEffect;
    public AudioSource pickupSound;

    private bool collected = false;

    private void Awake()
    {
        pickupSound = GetComponent<AudioSource>();
    }
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
            pickupSound.Play();
            foreach (Collider col in GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }

            foreach (Renderer rend in GetComponentsInChildren<Renderer>())
            {
                rend.enabled = false;
            }

            Destroy(gameObject, pickupSound.clip != null ? pickupSound.clip.length : 0f);
        }
    }
}