using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public PowerUpPopUp popUp;
    private void OnMouseUp()
    {
        popUp.Show();
    }

}
