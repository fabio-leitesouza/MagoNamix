using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // O objeto que a câmera seguirá
    public float smoothSpeed = 5f; // A suavidade do movimento da câmera
    public Vector3 offset = new Vector3(0f, 0f, -10f); // A posição offset da câmera

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Calcula a posição desejada da câmera
        Vector3 desiredPosition = target.position + offset;

        // Interpola suavemente a posição atual da câmera em direção à posição desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
    }
}

