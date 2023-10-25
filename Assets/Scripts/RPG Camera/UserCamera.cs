using UnityEngine;
using System.Collections;
 
public class UserCamera : MonoBehaviour {
    [Tooltip("Target to follow")]
    [SerializeField] private Transform target;
    [Tooltip("Vertical offset adjustment")]
    [SerializeField] private float targetHeight = 1.7f;
    [Tooltip("Default Distance")]
    [SerializeField] private float distance = 12.0f;
    [Tooltip("Bring camera away from any colliding objects")]
    [SerializeField] private float offsetFromWall = 0.1f;
    [Tooltip("Maximum zoom Distance")]
    [SerializeField] private float maxDistance = 20;
    [Tooltip("Minimum zoom Distance")]
    [SerializeField] private float minDistance = 0.6f;
    [Tooltip("Orbit speed (Left/Right)")]
    [SerializeField] private float xSpeed = 200.0f;
    [Tooltip("Orbit speed (Up/Down)")]
    [SerializeField] private float ySpeed = 200.0f;
    [Tooltip("Looking up limit")]
    [SerializeField] private float yMinLimit = -80;
    [Tooltip("Looking down limit")]
    [SerializeField] private float yMaxLimit = 80;
    [Tooltip("Zoom Speed")]
    [SerializeField] private float zoomRate = 40;
    [Tooltip("Auto Rotation speed (higher = faster)")]
    [SerializeField] private float rotationDampening = 3.0f;
    [Tooltip("Auto Zoom speed (Higher = faster)")]
    [SerializeField] private float zoomDampening = 5.0f;                  
    LayerMask collisionLayers = -1;
 
    [SerializeField] private bool lockToRearOfTarget;             
    [SerializeField] private bool allowMouseInputX = true;                
    [SerializeField] private bool allowMouseInputY = true;                
    
    private float xDeg = 0.0f; 
    private float yDeg = 0.0f; 
    private float currentDistance; 
    [SerializeField] public float desiredDistance; 
    private float correctedDistance; 
    private bool rotateBehind;
    
    [SerializeField] public GameObject userModel;
    [SerializeField] public bool inFirstPerson;

    private Rigidbody _rigidbody;
        
    void Start () { 
 
        Vector3 angles = transform.eulerAngles; 
        xDeg = angles.x; 
        yDeg = angles.y; 
        currentDistance = distance; 
        desiredDistance = distance; 
        correctedDistance = distance; 
        
        // Make the rigid body not change rotation 
        if (_rigidbody) 
            _rigidbody.freezeRotation = true;
        
        if (lockToRearOfTarget)
            rotateBehind = true;
    } 
    
    void Update () {
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            
            if(inFirstPerson) {
                
                minDistance = 10;
                desiredDistance = 15;
                userModel.SetActive(true);
                inFirstPerson = false;
            }
        }
        
        if(desiredDistance == 10) {
            
            minDistance = 0;
            desiredDistance = 0;
            userModel.SetActive(false);
            inFirstPerson = true;
        }   
    }
    
    //Only Move camera after everything else has been updated
    void LateUpdate () 
    { 
 
        // Don't do anything if target is not defined 
        if (!target) 
            return;
        
        Vector3 vTargetOffset3;
 
        // If either mouse buttons are down, let the mouse govern camera position 
        if (GUIUtility.hotControl == 0)
        {
            if(Input.GetKey(KeyCode.LeftControl)) {
                
            }
            else {
                if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) 
                { 
                    //Check to see if mouse input is allowed on the axis
                    if (allowMouseInputX)
                        xDeg += Input.GetAxis ("Mouse X") * xSpeed * 0.02f; 
                    if (allowMouseInputY)
                        yDeg -= Input.GetAxis ("Mouse Y") * ySpeed * 0.02f; 
 
                } 
            }
        }
        ClampAngle (yDeg); 
        
        // Set camera rotation 
        Quaternion rotation = Quaternion.Euler (yDeg, xDeg, 0); 
        
        // Calculate the desired distance 
        desiredDistance -= Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs (desiredDistance); 
        desiredDistance = Mathf.Clamp (desiredDistance, minDistance, maxDistance); 
        correctedDistance = desiredDistance; 
        
        // Calculate desired camera position
        Vector3 vTargetOffset = new Vector3 (0, -targetHeight, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * desiredDistance + vTargetOffset); 
        
        // Check for collision using the true target's desired registration point as set by user using height 
        RaycastHit collisionHit; 
        Vector3 trueTargetPosition = new Vector3 (target.position.x, target.position.y + targetHeight, target.position.z); 
        
        // If there was a collision, correct the camera position and calculate the corrected distance 
        bool isCorrected = false; 
        if (Physics.Linecast (trueTargetPosition, position,out collisionHit, collisionLayers)) 
        { 
            correctedDistance = Vector3.Distance (trueTargetPosition, collisionHit.point) - offsetFromWall; 
            isCorrected = true;
        }
        
        // For smoothing, lerp distance only if either distance wasn't corrected, or correctedDistance is more than currentDistance 
        currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp (currentDistance, correctedDistance, Time.deltaTime * zoomDampening) : correctedDistance; 
        
        // Keep within limits
        currentDistance = Mathf.Clamp (currentDistance, minDistance, maxDistance); 
        
        // Recalculate position based on the new currentDistance 
        position = target.position - (rotation * Vector3.forward * currentDistance + vTargetOffset); 
        
        //Finally Set rotation and position of camera
        transform.rotation = rotation; 
        transform.position = position; 
    } 
 
    void ClampAngle (float angle)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
 
        yDeg = Mathf.Clamp(angle, -60, 80);
    }
 
}
