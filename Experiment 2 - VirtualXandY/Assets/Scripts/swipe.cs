using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class swipe : MonoBehaviour
{
    public Color[] colors;
    public GameObject btn_2;
    public TMP_Text gate_name;
    public GameObject scrollbar, imageContent;
    private float scroll_pos = 0;
    float[] pos;
    private bool runIt = false;
    private float time;
    private Button takeTheBtn;
    int btnNumber;
    public int gate_id = 1;
    private int old_gate_id = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        if (runIt)
        {
            GecisiDuzenle(distance, pos, takeTheBtn);
            time += Time.deltaTime;

            if (time > 1f)
            {
                time = 0;
                runIt = false;
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        old_gate_id = gate_id;
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                gate_id = i;
                if (gate_id != old_gate_id)
                    handle_change(gate_id);
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                imageContent.transform.GetChild(i).localScale = Vector2.Lerp(imageContent.transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                imageContent.transform.GetChild(i).GetComponent<Image>().color = colors[1];
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        imageContent.transform.GetChild(j).GetComponent<Image>().color = colors[0];
                        imageContent.transform.GetChild(j).localScale = Vector2.Lerp(imageContent.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }


    }

    private void GecisiDuzenle(float distance, float[] pos, Button btn)
    {
        // btnSayi = System.Int32.Parse(btn.transform.name);

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[btnNumber], 1f * Time.deltaTime);

            }
        }

        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            btn.transform.name = ".";
        }

    }
    public void WhichBtnClicked(Button btn)
    {
        btn.transform.name = "clicked";
        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
            {
                btnNumber = i;
                takeTheBtn = btn;
                time = 0;
                scroll_pos = (pos[btnNumber]);
                runIt = true;
            }
        }


    }
    public void handle_change(int gate_id)
    {
        btn_2.SetActive(true);
        Debug.Log("Changed");
        switch (gate_id)
        {
            case 0:
                gate_name.text = "AND";
                break;
            case 1:
                gate_name.text = "NAND";
                break;
            case 2:
                gate_name.text = "OR";
                break;
            case 3:
                gate_name.text = "NOR";
                break;
            case 4:
                gate_name.text = "XOR";
                break;
            case 5:
                gate_name.text = "NOT";
                btn_2.SetActive(false);
                break;
        }
        First change_op = FindObjectOfType<First>();
        change_op.sel_gate();
    }
}
