using UnityEngine;

public class AttackPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
            foreach (GameObject gameObject in allGameObjects)
            {
                if (gameObject.tag == "Blood")
                {
                    gameObject.GetComponent<EnemyHealth>().damage += 20;
                }
            }
            Destroy(gameObject);
            AudioManager.PlayFromResources(Sound.cookies, 5, Random.Range(0.9f, 1.1f));
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }
}