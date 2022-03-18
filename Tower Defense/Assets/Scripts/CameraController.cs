using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    public float panSpeed = 30f;

    public float PanBorderThickness = 10f;
    public InputAction CameraControls;

    public float scrollSpeed = 5f;
    public float minY = 20f;
    public float maxY = 120f;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameIsOver)
        {
            this.enabled = false;
        }

        if(Input.GetKeyDown (KeyCode.Escape))
            doMovement = !doMovement;


        if(!doMovement)
        return;


        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - PanBorderThickness )
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= PanBorderThickness)
        {
            transform.Translate(Vector3.back* panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - PanBorderThickness )
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= PanBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }



        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp (pos.y, minY, maxY);

        transform.position = pos;
        

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
