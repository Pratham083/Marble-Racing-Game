using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoCam : MonoBehaviour
{

    /*public Transform Target;

    public Vector3 offset;
    public Vector3 eulerRotation;
    public float damper;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = eulerRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, Target.position + offset, damper * Time.time);
    }*/

    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }

}