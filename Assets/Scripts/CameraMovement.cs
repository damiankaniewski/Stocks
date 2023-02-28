using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool isZoomed;
    public GameObject canvas;

    private Vector3 initScale = new Vector3(1, 1, 1);
    private Vector3 initPosition = new Vector3(461.5f, 259.5f, 0);

    private Vector3 computerZoomScale = new Vector3(1.5f, 1.5f, 1.5f);
    private Vector3 computerZoomPosition = new Vector3(676.5f, 224.5f, 0);

    private Vector3 phoneZoomScale = new Vector3(3.3f, 3.3f, 3.3f);
    private Vector3 phoneZoomPosition = new Vector3(-533.5f, 259.5f, 0);
    
    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (isZoomed)
            {
                ResetZoom();
                //isZoomed = false;
                StartCoroutine(ZoomFalse());
            }
            else
            {
                ZoomComputer();
                //isZoomed = true;
                StartCoroutine(ZoomTrue());
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (isZoomed)
            {
                ResetZoom();
                //isZoomed = false;
                StartCoroutine(ZoomFalse());
            }
            else
            {
                ZoomPhone();
                //isZoomed = true;
                StartCoroutine(ZoomTrue());
            }
        }
    }

    void ZoomComputer()
    {
        /*canvas.transform.localScale = computerZoomScale;
        canvas.transform.position = computerZoomPosition;*/

        canvas.transform.localScale = Vector3.Lerp(canvas.transform.localScale, computerZoomScale,
            0.05f);
        canvas.transform.position = Vector3.Lerp(canvas.transform.position, computerZoomPosition,
            0.05f);
    }

    void ZoomPhone()
    {
        /*canvas.transform.localScale = phoneZoomScale;
        canvas.transform.position = phoneZoomPosition;*/

        canvas.transform.localScale = Vector3.Lerp(canvas.transform.localScale, phoneZoomScale,
            0.05f);
        canvas.transform.position = Vector3.Lerp(canvas.transform.position, phoneZoomPosition,
            0.05f);
    }

    void ResetZoom()
    {
        /*canvas.transform.localScale = initScale;
        canvas.transform.position = initPosition;*/

        canvas.transform.localScale = Vector3.Lerp(canvas.transform.localScale, initScale,
            0.05f);
        canvas.transform.position = Vector3.Lerp(canvas.transform.position, initPosition,
            0.05f);
    }

    IEnumerator ZoomTrue()
    {
        yield return new WaitForSeconds(1);
        isZoomed = true;
    }

    IEnumerator ZoomFalse()
    {
        yield return new WaitForSeconds(1);
        isZoomed = false;
    }
}