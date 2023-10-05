using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_installation : MonoBehaviour
{
    public Transform installation_Point;
    public GameObject TowerPrefab;
    public float installationRate = 1.0f;

    void Start()
    {
        InvokeRepeating("installation", 0.0f, installationRate);
    }

    public void installation()
    {
        GameObject bullet = Instantiate(TowerPrefab, installation_Point.position, Quaternion.Euler(0, 0, 0));
    }
}
