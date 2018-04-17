using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject PlayerModel;
    public GameObject EndlessBuilderDestroyer;
    public Transform transformtest;
    public Vector3 rotationRange = new Vector3(90, 90, 90);
    public bool backToDefPos;
    public float rotationSpeed = 10;
    public float dampingTime = 0.2f;
    public float flyingspeed;
    public bool invertedmoves = true;
    public float max_x_rotation = 45;
    public float max_y_rotation = 45;
    public float max_z_rotation = 180;

    private Vector3 m_TargetAngles;
    private Vector3 m_FollowAngles;
    private Vector3 m_FollowVelocity;
    private Quaternion m_OriginalRotation;

    // Use this for initialization
    void Start () {
        m_OriginalRotation = PlayerModel.transform.localRotation;
    }
	
	// Update is called once per frame
	void Update () {
        transformtest = PlayerModel.transform;
        if (m_TargetAngles.y > 180)
        {
            m_TargetAngles.y -= 360;
            m_FollowAngles.y -= 360;
        }
        if (m_TargetAngles.x > 180)
        {
            m_TargetAngles.x -= 360;
            m_FollowAngles.x -= 360;
        }
        if (m_TargetAngles.y < -180)
        {
            m_TargetAngles.y += 360;
            m_FollowAngles.y += 360;
        }
        if (m_TargetAngles.x < -180)
        {
            m_TargetAngles.x += 360;
            m_FollowAngles.x += 360;
        }

        m_TargetAngles.y = Mathf.Clamp(m_TargetAngles.y, -rotationRange.y * 0.5f, rotationRange.y * 0.5f);
        m_TargetAngles.x = Mathf.Clamp(m_TargetAngles.x, -rotationRange.x * 0.5f, rotationRange.x * 0.5f);

        // smoothly interpolate current values to target angles
        m_FollowAngles = Vector3.SmoothDamp(m_FollowAngles, m_TargetAngles, ref m_FollowVelocity, dampingTime);

        // update the actual gameobject's rotation
        PlayerModel.transform.localRotation = m_OriginalRotation * Quaternion.Euler(m_FollowAngles.x, m_FollowAngles.y, m_FollowAngles.z);

        // player, destroyer and builder flying forward at the speed of 'flyingspeed'
        float step = flyingspeed * Time.deltaTime;
        PlayerModel.transform.position += PlayerModel.transform.forward * step;
        EndlessBuilderDestroyer.transform.position = new Vector3(0, 0, PlayerModel.transform.position.z);



        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            // Up & Right Movement
            if (Input.GetKey("up") && !Input.GetKey("down") && !Input.GetKey("left") && Input.GetKey("right")) m_TargetAngles = new Vector3(45, 45, -90); 
            // Up & Left Movement
            else if (Input.GetKey("up") && !Input.GetKey("down") && Input.GetKey("left") && !Input.GetKey("right")) m_TargetAngles = new Vector3(45, -45, 90);
            // Up Movement
            else if (Input.GetKey("up") && !Input.GetKey("down") && !Input.GetKey("left") && !Input.GetKey("right")) m_TargetAngles = new Vector3(max_x_rotation, m_OriginalRotation.y, m_OriginalRotation.z);
            else if (Input.GetKey("up") && Input.GetKey("down") && !Input.GetKey("left") && !Input.GetKey("right")) m_TargetAngles = new Vector3(max_x_rotation, m_OriginalRotation.y, m_OriginalRotation.z);
            // Down & Right Movement
            else if (!Input.GetKey("up") && Input.GetKey("down") && !Input.GetKey("left") && Input.GetKey("right")) m_TargetAngles = new Vector3(-45, 45, -90);
            // Down & Left Movement
            else if (!Input.GetKey("up") && Input.GetKey("down") && Input.GetKey("left") && !Input.GetKey("right")) m_TargetAngles = new Vector3(-45, -45, 90);
            // Down Movement
            else if (!Input.GetKey("up") && Input.GetKey("down") && !Input.GetKey("left") && !Input.GetKey("right")) m_TargetAngles = new Vector3(-max_x_rotation, m_OriginalRotation.y, m_OriginalRotation.z);
            else if (Input.GetKey("up") && Input.GetKey("down") && !Input.GetKey("left") && !Input.GetKey("right")) m_TargetAngles = new Vector3(-max_x_rotation, m_OriginalRotation.y, m_OriginalRotation.z);
            // Right Movement
            else if (!Input.GetKey("up") && !Input.GetKey("down") && !Input.GetKey("left") && Input.GetKey("right")) m_TargetAngles = new Vector3(m_OriginalRotation.x, max_y_rotation, -max_z_rotation);
            // Left Movement
            else if (!Input.GetKey("up") && !Input.GetKey("down") && Input.GetKey("left") && !Input.GetKey("right")) m_TargetAngles = new Vector3(m_OriginalRotation.x, -max_y_rotation, max_z_rotation);
        }

        // No Movement = Back to normal rotation
        else if(backToDefPos) m_TargetAngles = new Vector3(m_OriginalRotation.x, m_OriginalRotation.y, m_OriginalRotation.z);

    
    }
}

