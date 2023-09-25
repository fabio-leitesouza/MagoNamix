using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float velocidadeMovimento = 2.0f; // Velocidade de movimento do inimigo.
    public float distanciaPerseguicao = 5.0f; // Distância para começar a perseguir o jogador.
    public int dano = 10; // Dano causado pelo inimigo ao jogador.

    private Transform jogador; // Referência ao transform do jogador.
    private Animator animador; // Referência ao componente Animator do inimigo.
    private bool playerNearby = false; // Indica se o jogador está próximo.

    private Vector3 direcaoAleatoria; // Direção aleatória para o vagar.
    private float tempoVagar; // Tempo para o vagar.

    private void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform; // Encontre o jogador por meio da tag "Player".
        animador = GetComponent<Animator>(); // Obtenha o componente Animator do inimigo.
        tempoVagar = Random.Range(1.0f, 4.0f); // Defina um tempo inicial para o vagar.
        EscolherNovaDirecaoAleatoria(); // Inicialmente, escolha uma direção aleatória para o vagar.
    }

    private void Update()
    {
        // Verifique a distância entre o inimigo e o jogador.
        float distancia = Vector3.Distance(transform.position, jogador.position);

        if (distancia < distanciaPerseguicao)
        {
            playerNearby = true;
            Vector3 direcao = (jogador.position - transform.position).normalized;
            transform.Translate(direcao * velocidadeMovimento * Time.deltaTime);
            AtualizarAnimacao(direcao);
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
        // Se o inimigo não está perseguindo o jogador, ele vai vagar.
        tempoVagar -= Time.deltaTime;

        if (tempoVagar <= 0)
        {
            EscolherNovaDirecaoAleatoria();
            tempoVagar = Random.Range(1.0f, 4.0f); // Defina um novo tempo para o vagar.
        }

        // Movimentar o inimigo na direção aleatória.
        transform.Translate(direcaoAleatoria * velocidadeMovimento * Time.deltaTime);

        // Atualizar as animações de acordo com a direção do movimento.
        AtualizarAnimacao(direcaoAleatoria);
    }

    private void EscolherNovaDirecaoAleatoria()
    {
        // Escolha uma nova direção aleatória.
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        direcaoAleatoria = new Vector3(x, y, 0).normalized;

        // Atualize as animações com base na direção aleatória.
        AtualizarAnimacao(direcaoAleatoria);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se o inimigo colidir com o jogador e o jogador estiver próximo, cause dano ao jogador.
        if (other.CompareTag("Player") && playerNearby)
        {
            // Coloque aqui o código para causar dano ao jogador.
            // Por exemplo, você pode chamar uma função do jogador para aplicar o dano.
            // jogador.GetComponent<Jogador>().AplicarDano(dano);
            
        }
    }
}
