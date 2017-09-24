using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    bool Perdiste = false;
    bool Presionaste = true;

    // Use this for initialization
    void Start()
    {
        ChangeColor(getColor());
    }

    public void ChangeColor(Color color)
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }
    // Update is called once per frame
    void Update()
    {
        var renderer = GetComponent<Renderer>();
        var color = getColor();
        transform.Rotate(new Vector3(100f,150f,0f) * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Presionaste = true;
            if (renderer.material.color == Color.red)
            {
                Perdiste = true;
                ChangeColor(Color.black);
            }
            else
            {
                if (!Perdiste)
                {
                    color = getColor();
                    ChangeColor(color);
                }
            }
        }

        if (DateTime.Now.Millisecond < 20f && !Perdiste)
        {
            if (renderer.material.color == Color.red)
            {
                ChangeColor(color);
                Presionaste = true;
            }
            else
            {
                if (!Presionaste)
                {
                    Perdiste = true;
                    ChangeColor(Color.black);
                }
            }
        }
        if (DateTime.Now.Second%2 == 0f && DateTime.Now.Millisecond > 350 && DateTime.Now.Millisecond < 400)
        {
            Presionaste = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Reiniciar();
        }

    }
    public void Reiniciar()
    {
        Perdiste = false;
        Presionaste = true;
        ChangeColor(Color.blue);
    }

    public Color getColor()
    {
        var color = new Color();
        var random = new System.Random();
        switch ((int)(random.Next(1, 9)))
        {
            case 1:
                color = Color.blue;
                break;
            case 2:
                color = Color.green;
                break;
            case 3:
                color = Color.yellow;
                break;
            case 4:
                color = Color.white;
                break;
            case 5:
                color = Color.cyan;
                break;
            case 6:
                color = Color.magenta;
                break;
            default:
                color = Color.red;
                break;
        }

        return color;
    }

}
