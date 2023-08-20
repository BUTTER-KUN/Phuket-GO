using UnityEngine;

public class RadialMenuSpin : MonoBehaviour
{
    public Transform buttonGroup;
    public float spinSpeed = 50.0f;

    private Vector3 mouseStartPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMouse = Input.mousePosition - mouseStartPosition;
            float rotationAmount = -deltaMouse.x * spinSpeed * Time.deltaTime;

            buttonGroup.Rotate(Vector3.forward, rotationAmount);

            mouseStartPosition = Input.mousePosition;
        }
    }
}