using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public float Velocidade = 20;
    public float TempoDeVida = 2.0f; // Tempo em segundos antes de destruir a magia.
    
    private float tempoDecorrido = 0.0f;

    void FixedUpdate()
    {
        // Move a magia na direção do eixo forward.
        transform.Translate(Vector3.forward * Velocidade * Time.fixedDeltaTime);

        // Atualiza o tempo decorrido.
        tempoDecorrido += Time.fixedDeltaTime;

        // Destrua a magia quando o tempo de vida expirar.
        if (tempoDecorrido >= TempoDeVida)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.CompareTag("Enemy"))
        {
            Destroy(objetoDeColisao.gameObject);
        }

        // Sempre destrua a magia quando atingir algo.
        Destroy(gameObject);
    }
}
