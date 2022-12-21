using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private float timeBetweenJump = 2f;
    [SerializeField] private float jumpAmount = 5f;
    [SerializeField] private float gravityScale = 5f;
    [SerializeField] private Rigidbody RB;
    private float timeElapsed = 0f;
    // Update is called once per frame

    private void FixedUpdate() {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > timeBetweenJump) {
            RB.AddForce(Vector2.up * jumpAmount, ForceMode.Impulse);
            timeElapsed = 0;
        }
        RB.AddForce(Physics.gravity * (gravityScale - 1) * RB.mass);    
    }
}
