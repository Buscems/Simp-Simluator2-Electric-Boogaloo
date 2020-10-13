using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float lookSpeed = 10;
    private Vector2 rotation = Vector2.zero;

    [SerializeField] private GameObject workHighlight;
    [SerializeField] private GameObject eGirlHighlight;

    //raycast stuff
    [SerializeField] private float rayLength;

    private bool canLook = true;

    private bool moveToWork;
    private bool moveToEGirl;
    private bool moveToPhone;
    private bool moveToNeutral;

    bool atMonitor;
    bool atPhone;

    [Header("Camera Positions")]
    public float cameraSpeed;
    public float cameraTimer;

    Vector3 lastPos;
    Quaternion lastRot;

    public Vector3 workComputerPos;
    public Quaternion workComputerRot;

    public Vector3 eGirlComputerPos;
    public Quaternion eGirlComputerRot;

    public Vector3 phonePos;
    public Quaternion phoneRot;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (canLook)
        {
            Look();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                lastPos = transform.position;
                lastRot = transform.rotation;
                cameraTimer = 0;
                canLook = false;
                moveToPhone = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            moveToEGirl = false;
            moveToWork = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            cameraTimer = 0;
            moveToNeutral = true;
        }

        cameraTimer += Time.deltaTime;

        if (moveToWork)
        {
            GoToWorkComputer();
        }

        if (moveToEGirl)
        {
            GoToEGirlComputer();
        }

        if (moveToPhone)
        {
            GoToPhone();
        }

        if (moveToNeutral)
        {
            BackToNeutralPosition();
        }

        MouseRaycast();

    }

    void GoToWorkComputer()
    {
        if(transform.position != workComputerPos && cameraTimer < cameraSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, workComputerPos, cameraTimer / cameraSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, workComputerRot, cameraTimer / cameraSpeed);
        }
        else
        {
            moveToWork = false;
            atMonitor = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void GoToEGirlComputer()
    {
        if (transform.position != eGirlComputerPos && cameraTimer < cameraSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, eGirlComputerPos, cameraTimer / cameraSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, eGirlComputerRot, cameraTimer / cameraSpeed);
        }
        else
        {
            moveToEGirl = false;
            atMonitor = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void GoToPhone()
    {
        if (transform.position != phonePos && cameraTimer < cameraSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, phonePos, cameraTimer / cameraSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, phoneRot, cameraTimer / cameraSpeed);
        }
        else
        {
            moveToPhone = false;
            atPhone = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void BackToNeutralPosition()
    {
        if (transform.position != lastPos && cameraTimer < cameraSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, lastPos, cameraTimer / cameraSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, lastRot, cameraTimer / cameraSpeed);
        }
        else
        {
            moveToNeutral = false;
            atMonitor = false;
            canLook = true;
        }
    }

    public void MouseRaycast()
    {
        //on click
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayLength))
            {
                //Debug.Log(hit.collider.name);
                string nameOfTarget = hit.collider.name;
                switch (nameOfTarget)
                {
                    case "WorkMonitor":
                        if (!atMonitor)
                        {
                            lastPos = transform.position;
                            lastRot = transform.rotation;
                            cameraTimer = 0;
                            canLook = false;
                            moveToWork = true;
                        }
                        break;
                    case "EgirlMonitor":
                        if (!atMonitor)
                        {
                            lastPos = transform.position;
                            lastRot = transform.rotation;
                            cameraTimer = 0;
                            canLook = false;
                            moveToEGirl = true;
                        }
                        break;

                    case "CabinetDoor":
                        if (hit.collider.gameObject.GetComponent<DrawerController>().CanBeInteractedWith())
                        {
                            hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Interact");
                        }
                        break;

                    case "MainDrawer":
                        if (hit.collider.gameObject.GetComponent<DrawerController>().CanBeInteractedWith())
                        {
                            hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Interact");
                        }
                        break;

                    case "SmallLeftDrawer":
                        if (hit.collider.gameObject.GetComponent<DrawerController>().CanBeInteractedWith())
                        {
                            hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Interact");
                        }
                        break;

                }
            }
        }

        //on HighlightRaycastHit hit;
        workHighlight.SetActive(false);
        eGirlHighlight.SetActive(false);
        RaycastHit hit2;
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray2, out hit2, rayLength))
        {
            string nameOfTarget = hit2.collider.name;
            switch (nameOfTarget)
            {
                case "WorkMonitor":
                    if (!atMonitor)
                    {
                        workHighlight.SetActive(true);
                    }
                    break;
                case "EgirlMonitor":
                    if (!atMonitor)
                    {
                        eGirlHighlight.SetActive(true);
                    }
                    break;
            }
        }
    }

    public void Look() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -30f, 30f);
        //transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, rotation.y * lookSpeed, 0);
    }
}
