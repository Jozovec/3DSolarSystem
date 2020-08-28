using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

public class CameraMovement : MonoBehaviour
{
    public Transform cam;

    public Slider position;
    public Slider zoom;

    public float positionSpeed = 15f;
    public float zoomSpeed = 10f;

    public float precisePositionSpeed = 2f;
    public float preciseZoomSpeed = 5f;

    public Material skybox;

    public TMP_Text kilometers;
    public TMP_Text miles;
    public TMP_Text astronomicalUnits;
    public TMP_Text lightyears;

    public Animations animations;

    private void Start()
    {
        position.value = 0f;
        zoom.value = 0f;

        positionChange();
        zoomChange();
    }

    private void Update()
    {
        // W S A D
        if (Input.GetKey(KeyCode.W))
        {
            zoom.value += zoomSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            zoom.value -= zoomSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position.value -= positionSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.value += positionSpeed * Time.deltaTime;
        }

        // Arrows
        if (Input.GetKey(KeyCode.UpArrow))
        {
            zoom.value += preciseZoomSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            zoom.value -= preciseZoomSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.value -= precisePositionSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.value += precisePositionSpeed * Time.deltaTime;
        }

        // Q E
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animations.triggerControls();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animations.triggerPlanets();
        }

        // Anti collision
        if (position.value <= 500f)
        {
            zoom.maxValue = remap(position.value, 0f, 500f, 50000f, 100000f);
        }
    }
    public void positionChange()
    {
        float newPosition = remap(position.value, 0f, 100000f, 0f, 60000);
        cam.position = new Vector3(newPosition, 0f, cam.position.z);
        RenderSettings.skybox.SetFloat("_Rotation", remap(position.value, 0f, 100000f, 0f, 20f));

        kilometers.text = toHundreds(6000000000f) + " km";
        miles.text = toHundreds(3500000000f) + " mi";
        astronomicalUnits.text = toMicros(40f) + " au";
        lightyears.text = toMicros(0.00065f) + " ly";
    }

    public void zoomChange()
    {
        float newZoom = remap(zoom.value, 0f, 100000f, -50f, -1f);
        cam.position = new Vector3(cam.position.x, 0f, newZoom);
    }

    private float remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    private string toHundreds(float maximal)
    {
        return remap(position.value, 0f, 100000f, 0f, maximal).ToString("000 000 000 000");
    }

    private string toMicros(float maximal)
    {
        return remap(position.value, 0f, 100000f, 0f, maximal).ToString("000.000 000 000");
    }
}
