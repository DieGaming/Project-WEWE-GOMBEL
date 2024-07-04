using UnityEngine;

public class HeadBobAndStabilizer : MonoBehaviour
{
    public float bobSpeed = 14f;  // Speed of the bobbing effect
    public float bobAmount = 0.05f;  // Amount of bobbing
    public float stabilizationSpeed = 5f;  // Speed of stabilization
    public Camera playerCamera;

    private float defaultPosY = 0;
    private float timer = 0;
    private Vector3 originalLocalPosition;

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
        defaultPosY = playerCamera.transform.localPosition.y;
        originalLocalPosition = playerCamera.transform.localPosition;
    }

    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            // Player is moving
            timer += Time.deltaTime * bobSpeed;
            playerCamera.transform.localPosition = new Vector3(originalLocalPosition.x, 
                                                               defaultPosY + Mathf.Sin(timer) * bobAmount, 
                                                               originalLocalPosition.z);
        }
        else
        {
            // Player is not moving
            timer = 0;
            playerCamera.transform.localPosition = new Vector3(originalLocalPosition.x, 
                                                               Mathf.Lerp(playerCamera.transform.localPosition.y, defaultPosY, Time.deltaTime * bobSpeed), 
                                                               originalLocalPosition.z);
        }
    }

    void LateUpdate()
    {
        playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, originalLocalPosition, Time.deltaTime * stabilizationSpeed);
    }
}
