using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public float velocidadeMovimento = 2.0f;
    public float distanciaPerseguicao = 5.0f;
    public int dano = 10;
    public float intervaloDano = 2.0f; // Intervalo de tempo entre aplicações de dano.

    private Transform jogador;
    private Animator animador;
    private bool playerNearby = false;
    private bool primeiroDano = true; // Controla se o primeiro dano já foi aplicado.
    private float tempoUltimoDano = 0.0f; // Armazena o tempo da última aplicação de dano.

    private Vector3 direcaoAleatoria;
    private float tempoVagar;
    public int damage = 10;
    public int Life = 100;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        animador = GetComponent<Animator>();
        tempoVagar = Random.Range(1.0f, 4.0f);
        EscolherNovaDirecaoAleatoria();
    }

    private void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.position);
        if (distancia < distanciaPerseguicao)
        {
            playerNearby = true;
            Vector3 direcao = (jogador.position - transform.position).normalized;
            transform.Translate(direcao * velocidadeMovimento * Time.deltaTime);
            AtualizarAnimacao(direcao);

            // Verifique a distância e aplique o dano.
            if (distancia < 1.5f)
            {
                if (primeiroDano)
                {
                    // Aplica o primeiro dano imediatamente.
                    AplicarDanoAoJogador();
                    primeiroDano = false;
                }
                else if (Time.time - tempoUltimoDano >= intervaloDano)
                {
                    // Aplica dano adicional somente se o intervalo de tempo tiver passado.
                    AplicarDanoAoJogador();
                    tempoUltimoDano = Time.time; // Atualize o tempo da última aplicação de dano.
                }
            }
        }
        else
        {
            playerNearby = false;
            Vagar();
        }
    }

    private void AtualizarAnimacao(Vector3 direcao)
    {
        animador.SetFloat("MovimentoX", direcao.x);
        animador.SetFloat("MovimentoY", direcao.y);
    }

    private void Vagar()
    {
        tempoVagar -= Time.deltaTime;

        if (tempoVagar <= 0)
        {
            EscolherNovaDirecaoAleatoria();
            tempoVagar = Random.Range(1.0f, 4.0f);
        }

        transform.Translate(direcaoAleatoria * velocidadeMovimento * Time.deltaTime);
        AtualizarAnimacao(direcaoAleatoria);
    }

    private void EscolherNovaDirecaoAleatoria()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        direcaoAleatoria = new Vector3(x, y, 0).normalized;
        AtualizarAnimacao(direcaoAleatoria);
    }

    private void AplicarDanoAoJogador()
    {
        if (playerNearby)
        {
            PlayerController playerScript = Player.GetComponent<PlayerController>();
            playerScript.TakesDamage(damage);
        }
    }
    public void TakeDamage (int dama)
    {
        Life -= dama;     
       
        if (Life <= 0)
            {
                Destroy(gameObject);
            }
    }
}
