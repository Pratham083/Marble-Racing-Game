using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform target;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    private void FixedUpdate() {
        HandleTranslation();
        HandleRotation();
    }
    private void HandleRotation() {

        Vector3 direction = target.position - cam.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, rotation, rotationSpeed*Time.deltaTime);

    }
    private void HandleTranslation() {
        Vector3 targetPosition = target.TransformPoint(offset);
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, targetPosition, 
            ref velocity, translateSpeed*Time.deltaTime);
    }
}
