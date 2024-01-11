using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AU_PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody myRB;
    Transform myAvatar;
    Animator animator;

    //Playermovement
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;

    //Interaction
    [SerializeField] InputAction MOUSE;
    Vector2 mousePositionInput;
    Camera myCamera;
    [SerializeField] InputAction INTERACTION;
    [SerializeField] LayerMask interactLayer;
    float scaleX;

    private void Awake()
    {
        INTERACTION.performed += Interact;
    }

    private void OnEnable()
    {
        WASD.Enable();
        MOUSE.Enable();
        INTERACTION.Enable();
    }

    private void OnDisable()
    {
        WASD.Disable(); 
        MOUSE.Disable();
        INTERACTION.Disable(); 
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody>();
        myAvatar = transform.GetChild(0);
        scaleX = transform.localScale.x;
    }
    private void Update()
    {
        movementInput = WASD.ReadValue<Vector2>();

/*        if (movementInput.x != 0)
        {
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);

        }*/
        animator.SetFloat("Speed", movementInput.magnitude);

        mousePositionInput = MOUSE.ReadValue<Vector2>();

        //flip animation
        if(myRB.velocity.x != 0) {
        Vector3 scale = transform.localScale;
        scale.x = scaleX * (myRB.velocity.x >= 0 ? 1 : -1);
        transform.localScale = scale;
        }
    }
    private void FixedUpdate()
    {
        myRB.velocity = movementInput * movementSpeed;
        
    }

    void Interact(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Here");
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(mousePositionInput);
            
            if (Physics.Raycast(ray, out hit, interactLayer)) {
            if (hit.transform.tag == "Interactable")
                {
                    if (!hit.transform.GetChild(0).gameObject.activeInHierarchy)
                        return;
                    AU_Interactable temp = hit.transform.GetComponent<AU_Interactable>();
                    temp.PlayMiniGame();
                }
                 
            }

        }
    }
}
