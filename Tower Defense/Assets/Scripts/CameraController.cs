using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;

    public float PanBorderThickness = 10f;
    public InputAction CameraControls;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") )
        {
            //new Vector3(0f, 0f, 1f) * panSpeed;
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        //   if (Input.GetKey("s") || Input.mousePosition.y <=  PanBorderThickness)
        // {
        //     //new Vector3(0f, 0f, 1f) * panSpeed;
        //     transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        // }

        //   if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - PanBorderThickness)
        // {
        //     //new Vector3(0f, 0f, 1f) * panSpeed;
        //     transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        // }

        // if (Input.GetKey("a") || Input.mousePosition.x <= PanBorderThickness)
        // {
        //     //new Vector3(0f, 0f, 1f) * panSpeed;
        //     transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        // }
    }

    private void OnEnable ()
    {
        CameraControls.Enable();
    }

    private void OnDisable ()
    {
        CameraControls.Disable();
    }
}
