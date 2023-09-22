using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAimScript : MonoBehaviour
{
    public Transform Player;
    public float offset = 0.5f;
    
    void Update()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        //rotação
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
