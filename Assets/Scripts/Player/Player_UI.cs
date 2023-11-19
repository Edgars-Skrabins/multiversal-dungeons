using System;
using System.Collections;
using System.Collections.Generic;
using MultiversalDungeons.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{

    [SerializeField] private Image m_crosshairIMG;
    
    private void Update()
    {
        MovePlayerCrosshair();
    }

    private void MovePlayerCrosshair()
    {
        m_crosshairIMG.rectTransform.position = Input.mousePosition;
    }
}
