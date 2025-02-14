using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().CurrentHealth += 20;
            Destroy(gameObject);
            AudioManager.PlayFromResources(Sound.cookies,5,Random.Range(0.9f,1.1f));
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
    }
}