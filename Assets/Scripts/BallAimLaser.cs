using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAimLaser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float laserWidth;
    public float laserMaxLength;
    public BallControll ballControll;
    LayerMask layerMask;
    Vector3[] initLaserPosition;

    // Start is called before the first frame update
    void Start()
    {
        ballControll = GetComponent<BallControll>();
        initLaserPosition = new Vector3[2] { Vector3.zero, Vector3.zero };
        lineRenderer.SetPosition(0,initLaserPosition[0]);
        lineRenderer.SetPosition(1, initLaserPosition[1]);
        lineRenderer.SetWidth(laserWidth, laserWidth);
        layerMask = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && ballControll.aiming)
        {
            ShootLaserFromTargetPosition(transform.position, ballControll.dir, ballControll.distance);
            lineRenderer.enabled = true;
            //Debug.Log("Enabled");
        } else if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
            lineRenderer.SetPosition(0, initLaserPosition[0]);
            lineRenderer.SetPosition(1, initLaserPosition[1]);
        }
    }

    void ShootLaserFromTargetPosition(Vector2 targetPosition, Vector2 direction, float lenght)
    {
        Ray2D ray = new Ray2D(targetPosition, direction);
        RaycastHit2D raycastHit;
        Vector2 endPosition = targetPosition + (direction * lenght);

        raycastHit = Physics2D.Raycast(targetPosition, direction, lenght, layerMask);
        if (raycastHit.collider != null)
            endPosition = raycastHit.point;

        Vector3 fixedStart = new Vector3(targetPosition.x, targetPosition.y, -0.1f);
        Vector3 fixedEnd = new Vector3(endPosition.x, endPosition.y, -0.1f);

        lineRenderer.SetPosition(0, fixedStart);
        lineRenderer.SetPosition(1, fixedEnd);
    }
}
