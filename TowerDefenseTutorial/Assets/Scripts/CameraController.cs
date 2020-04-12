
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Attributes")]
    public float panSpeed = 30f;
    public float panBoarderThickness = 10f;
    public float scrollSpeed = 5f;

    public Vector3 newPosition;

    public float rotationAmount = 1;
    public Quaternion newRotation = Quaternion.identity;

    [Header("Clamp features")]
    public float minY = 10f;
    public float maxY = 80f;
    public float minX = 0f;
    public float maxX = 80f;
    public float minZ = -32f;
    public float maxZ = 64f;

    
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
    }

    /* Update() - executes every frame
     *
     * controls left/right/up/down movement and scrolling
     *
     */
    void Update()
    {
        // if game is over, disable the camera
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        ASDWControls();

        ZoomControls();

        RotationControls();

        ClampControl();
    }

    /* ASDWControls() 
     *
     * controls asdw movement with asdw keys
     *
     * also will pan if near edge of screewn
     * 
     */
    void ASDWControls()
    {
        // move up
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - panBoarderThickness)
        {
            transform.Translate(new Vector3(0, 1, 1) * panSpeed * Time.deltaTime, Space.Self);
        }

        // move down
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= panBoarderThickness)
        {
            transform.Translate(new Vector3(0, -1, -1) * panSpeed * Time.deltaTime, Space.Self);
        }

        // move right
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - panBoarderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.Self);
        }

        // move left
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= panBoarderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.Self);
        }

        

    }

    /* ZoomControls()
     *
     * zooms in/out based on mouse scrolling
     * 
     */
    void ZoomControls()
    {
        // determines how to zoom in/out with 
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        transform.position = pos;


    }

    // TODO: figure out how to make camera rotate better - I'm not super into it
    
    void RotationControls()
    {
        if (Input.GetKey(KeyCode.R))
        {
            newRotation *= Quaternion.Euler(new Vector3 (0, -1, 1) * rotationAmount);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(new Vector3(0, 1, -1) * rotationAmount);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * panSpeed);

    }

    /* ClampControl()
     *
     * sets edge bounds for how user can move camera
     *
     *
     */
    void ClampControl()
    {
        // user can't infinitely pan in one direction
        Vector3 pos = transform.position;
        // sets edge  bounds - how far you can zoom in/out
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
