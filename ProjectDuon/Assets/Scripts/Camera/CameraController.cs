using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class CameraController : MonoBehaviour {

    DimensionManager dimensionManager;
    GameObject mark;
    GameObject luna;

    public float size = 22.5f;
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    bool initiated = false;
    public bool isFollowingPlayer = true;

    public bool bindHorMovement = false;
    public float minX = 0;
    public float maxX = 0;

    public bool bindVerMovement = false;
    public float minY = 0;
    public float maxY = 0;



    // Use this for initialization
    void Start()
    {
        /*
        transform.position = target.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        targetPos = transform.position;
        */
        dimensionManager = GameObject.Find("GeneralManager").GetComponent<DimensionManager>();
        mark = GameObject.Find("Mark");
        luna = GameObject.Find("Luna");
    }

    void Update()
    {
        GetComponent<Camera>().orthographicSize = size;

        /*
        if (bindHorMovement)
        {
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
        }

        if (bindVerMovement)
        {
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
            }
            else if (transform.position.y < minY)
            {
                transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            }
        }
        */

    }

    void LateUpdate()
    {
        if (bindHorMovement)
        {
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
        }

        if (bindVerMovement)
        {
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
            }
            else if (transform.position.y < minY)
            {
                transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            }
        }
    }

   
    void FixedUpdate()
    {
        if (isFollowingPlayer)
        {
            if (dimensionManager.currentDimension == Dimension.DIMENSION_A)
            {
                target = mark;
            }
            else
            {
                target = luna;
            }
        }

        if (target)
        {
            if (!initiated)
            {
                transform.position = target.transform.position;
                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                targetPos = transform.position;
                initiated = true;
            }
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 30f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }

        if (bindHorMovement)
        {
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
        }

        if (bindVerMovement)
        {
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
            }
            else if (transform.position.y < minY)
            {
                transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            }
        }
    }


}
