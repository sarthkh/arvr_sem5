using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Networking;
using System.Xml;
using TMPro;
using System;
using System.Net;
using UnityEditor;

public class First : MonoBehaviour
{
    public VirtualButtonBehaviour btn_1;
    public VirtualButtonBehaviour btn_2;
    public Sprite sprite_on;
    public Sprite sprite_off;
    public GameObject btn_1_sprite;
    public GameObject btn_2_sprite;
    public bool btn_1_state = false, btn_2_state = false, ret_state = false;
    public string url;
    public GameObject bulb_on;
    public GameObject bulb_off;

    IEnumerator GetRequest(string uri)
    {
        Debug.Log(uri);

        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            // Allow insecure connections (not recommended for production)

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else if (webRequest.result == UnityWebRequest.Result.Success)
            {
                // Request was successful
                string responseText = webRequest.downloadHandler.text;
                Debug.Log("Response: " + responseText);

                // You can parse and work with the response data here
            }
        }
    }

    void Start()
    {
        btn_1.RegisterOnButtonPressed(OnButtonPressed_on);
        btn_2.RegisterOnButtonPressed(OnButtonPressed_off);

    }


    public void OnButtonPressed_on(VirtualButtonBehaviour Vb_on)
    {
        SpriteRenderer spriteRenderer = btn_1_sprite.GetComponent<SpriteRenderer>();
        if (btn_1_state)
        {
            btn_1_state = false;
            spriteRenderer.sprite = sprite_off;
        }
        else
        {
            btn_1_state = true;
            spriteRenderer.sprite = sprite_on;
        }
        Debug.Log("LED IS ON");
        sel_gate();
    }

    public void OnButtonPressed_off(VirtualButtonBehaviour Vb_off)
    {
        SpriteRenderer spriteRenderer = btn_2_sprite.GetComponent<SpriteRenderer>();
        if (btn_2_state)
        {
            btn_2_state = false;
            spriteRenderer.sprite = sprite_off;
        }
        else
        {
            btn_2_state = true;
            spriteRenderer.sprite = sprite_on;
        }
        Debug.Log("LED IS OFF");

        sel_gate();
    }
    public void sel_gate()
    {
        swipe gate_type = FindObjectOfType<swipe>();
        switch (gate_type.gate_id)
        {
            case 0:
                ret_state = btn_1_state && btn_2_state;
                // Debug.Log("AND");
                break;
            case 1:
                ret_state = btn_1_state && btn_2_state;
                ret_state = !ret_state;
                // Debug.Log("NAND");
                break;
            case 2:
                ret_state = btn_1_state || btn_2_state;
                // Debug.Log("OR");
                break;
            case 3:
                ret_state = btn_1_state || btn_2_state;
                ret_state = !ret_state;
                // Debug.Log("NOR");
                break;
            case 4:
                ret_state = btn_1_state ^ btn_2_state;
                // Debug.Log("XOR");
                break;
            case 5:
                ret_state = !btn_1_state;
                //Debug.Log("NOT");
                break;


        }
        handle_get();
        bulb_trig();
        Debug.Log("Here3");
    }
    public void handle_get()
    {
        string url_comp;
        Debug.Log("Here");
        if (btn_1_state)
            url_comp = url + "1/on";
        else
            url_comp = url + "1/off";
        StartCoroutine(GetRequest(url_comp));
        Debug.Log("here2");

        if (btn_2_state)
            url_comp = url + "2/on";
        else
            url_comp = url + "2/off";
        StartCoroutine(GetRequest(url_comp));
        if (ret_state)
            url_comp = url + "3/on";
        else
            url_comp = url + "3/off";
        StartCoroutine(GetRequest(url_comp));
    }
    public void bulb_trig()
    {
        bulb_off.SetActive(!ret_state);
        bulb_on.SetActive(ret_state);
    }
}
