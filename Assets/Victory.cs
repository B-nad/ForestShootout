using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject youWonUI;
    public static Victory Instance;
    [SerializeField] private List<GameObject> outpostEnemies = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject gameObject in allGameObjects)
        {
            if (gameObject.layer == 17)
            {
                outpostEnemies.Add(gameObject);
            }
        }
    }

    public void KilledEnemy(GameObject obj)
    {
        if (outpostEnemies.Contains(obj))
        {
            outpostEnemies.Remove(obj);
            if (outpostEnemies.Count == 0)
            {
                youWonUI.SetActive(true);
            }
        }
    }
}
