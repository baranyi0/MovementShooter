using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    LineRenderer lineRenderer;

    Vector3 point;

    public LayerMask interactable;

    public Transform _camera, player;

    SpringJoint joint;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Grapple();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Stop();
        }
    }

    void Grapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.position, _camera.forward, out hit, 50))
        {
            point = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();

            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = point;

            float dist = Vector3.Distance(player.position, point);

            joint.maxDistance = dist * 0.8f;
            joint.minDistance = dist * 0.25f;

            joint.spring = 5;
            joint.damper = 5;
            joint.massScale = 5;

            lineRenderer.positionCount = 2;
        }
    }

    void Stop()
    {
        lineRenderer.positionCount = 0;

        Destroy(joint);
    }

    void Line()
    {
        if (!joint)
        {
            return;
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, point);
    }

    void LateUpdate()
    {
        Line();
    }
}
