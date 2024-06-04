using UnityEngine;

public class PortalInteraction : MonoBehaviour
{
    public AudioClip EnterPortalAudio;
    public AudioClip NotEnterPortal;
    public GameObject successParticles;
    public GameObject failParticles;
    public Animator portalAnimator; // Optional animator for portal effects

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory != null)
            {
                if (inventory.HasAllKeys())
                {
                    ActivatePortal();
                }
                else
                {
                    FailToActivatePortal();
                }
            }
        }
    }

    private void ActivatePortal()
    {
        // Play success sound
        if (EnterPortalAudio != null)
        {
            audioSource.PlayOneShot(EnterPortalAudio);
        }

        // Play portal activation animation
        if (portalAnimator != null)
        {
            portalAnimator.SetTrigger("Activate");
        }

        // Instantiate success particle effects
        if (successParticles != null)
        {
            Instantiate(successParticles, transform.position, Quaternion.identity);
        }

        // Additional logic for portal activation (e.g., teleportation) can be added here
    }

    private void FailToActivatePortal()
    {
        // Play fail sound
        if (NotEnterPortal != null)
        {
            audioSource.PlayOneShot(NotEnterPortal);
        }

        // Play portal fail animation (if any)
        if (portalAnimator != null)
        {
            portalAnimator.SetTrigger("Fail");
        }

        // Instantiate fail particle effects
        if (failParticles != null)
        {
            Instantiate(failParticles, transform.position, Quaternion.identity);
        }
    }
}
