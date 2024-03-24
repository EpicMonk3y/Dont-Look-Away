using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClipping : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float radius;

    [SerializeField] private LayerMask ClippingLayerMask;
    
    [SerializeField] private AnimationCurve offsetCurve;

    private Vector3 _originalLocalPosition;

    private void Start() => _originalLocalPosition = transform.localPosition;
    

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f)), radius, out var hit, distance, ClippingLayerMask))
        {
            transform.localPosition = _originalLocalPosition - new Vector3(0.0f, 0.0f, offsetCurve.Evaluate(hit.distance / distance)); 
        }
        else
        {
            transform.localPosition = _originalLocalPosition;
        }
    }
}
