using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPlacement : MonoBehaviour
{
    private Vector3 vectOffset;
    private GameObject follow;
    [SerializeField] private float speed = 3.0f;
    void Start()
    {
        follow = Camera.main.gameObject;
        vectOffset = transform.position - follow.transform.position;
    }
    void Update()
    {
        transform.position = follow.transform.position + vectOffset;
        transform.rotation = Quaternion.Slerp(transform.rotation, follow.transform.rotation, speed * Time.deltaTime);
    }
}
