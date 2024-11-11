using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwitcher : MonoBehaviour
{
    [SerializeField]
    public float leftLaneZ = -2f;
    [SerializeField]
    public float rightLaneZ = 0f;

    private bool isOnRightLane = false;

    public float laneSwitchSpeed = 5f;

    void SwitchLane()
    {
        isOnRightLane = !isOnRightLane;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SwitchLane();
        }
        float targetZ = isOnRightLane ? leftLaneZ : rightLaneZ;
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, targetZ);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneSwitchSpeed * Time.deltaTime);
    }
}
