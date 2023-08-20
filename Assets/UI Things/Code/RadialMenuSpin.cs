using UnityEngine;

public class RadialMenuSpin : MonoBehaviour
{
    public Transform buttonGroup;
    public float spinSpeed = 10.0f;

    private Vector3 mouseStartPosition;
    private float rotationAmount;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMouse = Input.mousePosition - mouseStartPosition;
            float deltaAngle = Mathf.Atan2(deltaMouse.y, deltaMouse.x) * Mathf.Rad2Deg;

            float newRotationAmount = deltaAngle * spinSpeed * Time.deltaTime;
            rotationAmount += newRotationAmount;

            buttonGroup.rotation = Quaternion.Euler(0, 0, rotationAmount);

            mouseStartPosition = Input.mousePosition;
        }
    }
}
