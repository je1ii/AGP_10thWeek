using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] float force = 10f;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            Rigidbody rb = GetComponent<Rigidbody>();
            
            playerRb.AddForce(Vector3.up * force, ForceMode.Impulse);

            if (rb != null)
            {
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
                Debug.Log("Player Launched");
            }
        }
    }
}
