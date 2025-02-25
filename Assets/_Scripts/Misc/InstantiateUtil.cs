using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtil : MonoBehaviour
{
    public GameObject objectToInstantiatePrefab;



    public void InstantiateObject()
    {
        Instantiate(objectToInstantiatePrefab, transform.position, Quaternion.identity);
    }
}
