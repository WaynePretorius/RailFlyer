using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Tooltip("In m/s")] [SerializeField] private float XSpeed;
    [Tooltip("In m/s")] [SerializeField] private float YSpeed;

    [SerializeField] private float clampZoneX = 8f;
    [SerializeField] private float clampZoneY = 6f;
    [SerializeField] private float positionPitchFactor = -5f;
    [SerializeField] private float positionYawFactor = 5f;
    [SerializeField] private float positionRollFactor = -15f;
    [SerializeField] private float controlPitchFactor = -30f;

    private float horizontalThrow;
    private float verticalThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();
        ControlPitchAndYaw();
    }

    private void MoveShip()
    {
        float newXPos = CalculateNewPosX();
        float newYPos = CalculateNewYPos();

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    private float CalculateNewPosX()
    {
        horizontalThrow = Input.GetAxis(Tags.INPUT_HORIZONTAL);
        float xOffset = horizontalThrow * XSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawXPos, -clampZoneX, clampZoneX);
        return newXPos;
    }

    private float CalculateNewYPos()
    {
        verticalThrow = Input.GetAxis(Tags.INPUT_VERTICAL);
        float yOffset = verticalThrow * YSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float newYPos = Mathf.Clamp(rawYPos, -clampZoneY, clampZoneY);
        return newYPos;
    }

    private void ControlPitchAndYaw()
    {
        float positionPitch = transform.localPosition.y * positionPitchFactor;
        float controlPitch = verticalThrow * controlPitchFactor;
        float pitch = positionPitch + controlPitch;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = horizontalThrow * positionRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
