using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 30f, -4f);
        transform.position = target.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}