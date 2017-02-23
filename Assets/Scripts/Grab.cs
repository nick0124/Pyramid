using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {

    public LineRenderer dragLine;
    public float dragSpeed = 10;
    Rigidbody2D grabbedObject = null;
    SpringJoint2D springJoint = null;
    DistanceJoint2D distanceJoint = null;
    public bool springJointActive = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
            Vector2 dir = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir);

            if (hit != null && hit.collider != null)
            {
                if (hit.collider.GetComponent<Rigidbody2D>() != null)
                {
                    grabbedObject = hit.collider.GetComponent<Rigidbody2D>();
                    if (springJointActive)
                    {
                        springJoint = grabbedObject.gameObject.AddComponent<SpringJoint2D>();
                        springJoint.anchor = grabbedObject.transform.InverseTransformPoint(hit.point);
                        springJoint.dampingRatio = 2;
                        springJoint.enableCollision = true;
                    }
                    else
                    {
                        distanceJoint = grabbedObject.gameObject.AddComponent<DistanceJoint2D>();
                        distanceJoint.anchor = grabbedObject.transform.InverseTransformPoint(hit.point);
                        distanceJoint.distance = 0;
                        distanceJoint.maxDistanceOnly = true;
                        distanceJoint.enableCollision = true;
                    }
                    dragLine.enabled = true;
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (springJointActive)
                Destroy(springJoint);
            else
                Destroy(distanceJoint);
            grabbedObject = null;
            dragLine.enabled = false;
        }
        if (springJointActive)
        {
            if (springJoint != null)
            {
                Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
                springJoint.connectedAnchor = mousePos2D;
            }
        }
        else
        {
            if (distanceJoint != null)
            {
                Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
                distanceJoint.connectedAnchor = mousePos2D;
            }
        }
	}
    /*
    void FixedUpdate()
    {
         Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);


        if(grabbedObject!=null)
        {
            Vector2 dir = mousePos2D - grabbedObject.position;
            dir *= dragSpeed;
            
            grabbedObject.velocity = dir;
        }
    }
     */

    void LateUpdate()
    {
        Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

        if (grabbedObject != null)
        {
            if (springJointActive)
            {
                Vector3 worldAnchor = grabbedObject.transform.TransformPoint(springJoint.anchor);
                dragLine.SetPosition(0, new Vector3(worldAnchor.x, worldAnchor.y, -1));
                dragLine.SetPosition(1, new Vector3(springJoint.connectedAnchor.x, springJoint.connectedAnchor.y, -1));
            }
            else
            {
                Vector3 worldAnchor = grabbedObject.transform.TransformPoint(distanceJoint.anchor);
                dragLine.SetPosition(0, new Vector3(worldAnchor.x, worldAnchor.y, -1));
                dragLine.SetPosition(1, new Vector3(distanceJoint.connectedAnchor.x, distanceJoint.connectedAnchor.y, -1));
            }
        }
         
    }
}
