using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CameraController : MonoBehaviour {

    [Space]
    [Header("Target")]
    [Range(0, 1)] public float deadZoneFactor = 0.7f;
    private Transform target;
    private SpriteRenderer spr;
    [Range(0, 1)] public float smoothFactor = 0.1f;

    [Space]
    [Header("Camera")]
    Vector3 cameraInitialPosition;

    private float dzH, dzW;
    private float halfSizeTarget;

    private float shakeAmount = 0.2f;
    private float shakeDuration = 0.2f;

    private float zoomSpeed = 8.0f;
    private float maxZoomIn = 5.0f;
    private float maxZoomOut = 8.5f;



    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Character").transform;

        dzH = Camera.main.orthographicSize * deadZoneFactor;
        dzW = dzH * Camera.main.aspect;

        halfSizeTarget = 32;

        spr = target.gameObject.GetComponent<SpriteRenderer>();
        halfSizeTarget = spr.bounds.size.x * 0.5f;
    }

    void Update()
    {
        float deltaX, deltaY;
        deltaY = deltaX = 0;

        if (!IsInDeadZone(ref deltaX, ref deltaY))
        {
            Vector3 newPos = transform.position + new Vector3(deltaX, deltaY, 0);
            transform.position = Vector3.Lerp(transform.position, newPos, smoothFactor);
        }

        Inputs();

    }

    void Inputs()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Dpad Vertical") >0) // ZOOM IN
        {
            if (Camera.main.orthographicSize > maxZoomIn)
                Camera.main.orthographicSize = Camera.main.orthographicSize - zoomSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetAxis("Dpad Vertical") < 0) // ZOOM OUT
        {
            if (Camera.main.orthographicSize < maxZoomOut)
                Camera.main.orthographicSize = Camera.main.orthographicSize + zoomSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.F)) //Explosión
        {
            ShakeCamera();
        }
    }

    private bool IsInDeadZone(ref float deltaX, ref float deltaY)
    {
        deltaY = deltaX = 0;
        Bounds cameraBounds = new Bounds(transform.position, new Vector3(2f * (dzW + halfSizeTarget), 2f * (dzH + halfSizeTarget), 100f));
        if (!cameraBounds.Contains(target.position))
        {
            Vector3 cp = cameraBounds.ClosestPoint(target.position);
            deltaX = target.position.x - cp.x;
            deltaY = target.position.y - cp.y;
            return false;
        }
        return true;
    }


    //FuncionesExplosión

    public void ShakeCamera()
    {
        cameraInitialPosition = Camera.main.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.02f);
        Invoke("StopCameraShaking", shakeDuration);
    }
    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeAmount * 2 - shakeAmount;
        float cameraShakingOffsetY = Random.value * shakeAmount * 2 - shakeAmount;
        Vector3 cameraIntermediatePosition = Camera.main.transform.position;
        cameraIntermediatePosition.x += cameraShakingOffsetX;
        cameraIntermediatePosition.y += cameraShakingOffsetY;
        Camera.main.transform.position = cameraIntermediatePosition;
    }
    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        Camera.main.transform.position = cameraInitialPosition;
    }




    //DESCOMENTAR PARA VER AREA DE LA CAMARA EN EL EDITOR
    /*private void OnDrawGizmosSelected()
    {
        dzH = Camera.main.orthographicSize * deadZoneFactor;
        dzW = dzH * Camera.main.aspect;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(2 * dzW, 2 * dzH, 10f));
    }*/



}
