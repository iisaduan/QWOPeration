
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Attributes")]
    private bool doMovement = true;
    public float panSpeed = 30f;
    public float panBoarderThickness = 10f;
    public float scrollSpeed = 5f;

    [Header("Clamp features")]
    public float minY = 10f;
    public float maxY = 80f;
    public float minX = 0f;
    public float maxX = 80f;
    public float minZ = -32f;
    public float maxZ = 64f;


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

        // escape key = no more movement - does this
        if(Input.GetKeyDown (KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }

        ASDWControls();

        ZoomControls();

        ClampControl();
    }

    /* ASDWControls() 
     *
     * controls asdw movement with asdw keys
     *
     * also will pan if near edge of screen
     * 
     */
    void ASDWControls()
    {
        // move up
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBoarderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        // move down
        if (Input.GetKey("s") || Input.mousePosition.y <= panBoarderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        // move right
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoarderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        // move left
        if (Input.GetKey("a") || Input.mousePosition.x <= panBoarderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
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
