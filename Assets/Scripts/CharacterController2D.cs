using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] public float forcaPulo = 400f; // Determina o quão forte é o pulo do personagem
    // 400f por padrao	
    [Range(0, .3f)] [SerializeField] public float m_MovementSmoothing = 0.05f; // Variável para suavizar a movimentação
    // 0.05f por padrão


    [SerializeField] private LayerMask m_WhatIsGround;   // Para determinar o que é chão para o personagem
	[SerializeField] private Transform m_GroundCheck;    // Objeto para designar em que posição do personagem é o chao (no caso, no pé do personagem)
	[SerializeField] private Transform m_CeilingCheck;   // Objeto para designar em que posição do personagem é o teto (no caso, a cabeça, topo do personagem)
    [SerializeField] private bool m_AirControl = false;	// Verifica se o jogador pode se mover para esquerda ou direita enquanto estiver no ar (Pulando)
    private bool olhandoDireita = true; // Serve para verificar a direção em que o jogador está olhando

    private bool m_Grounded;            // Checar se o jogador está no chão ou não

    private Rigidbody2D m_Rigidbody2D;

    const float k_GroundedRadius = .2f; // Raio do objeto que determina onde é o pé do personagem
	const float k_CeilingRadius = .2f; // Raio do objeto que determina onde é a cabeça do personagem

	private Vector3 m_Velocity = Vector3.zero;

    public UnityEvent OnLandEvent;

    private void Awake()
	{
        m_Rigidbody2D = GetComponent<Rigidbody2D>(); //Cria o objeto para a movimentação do personagem
        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
    }

    private void LateUpdate()
	{
        bool wasGrounded = m_Grounded;
		m_Grounded = false;

        // O jogador estará no chao se o objeto marcado para checar a posição do chão no personagem bate com alguma coisa associada ao chao
		// Pode ser feita por layers, basta colocar os objetos na layer  correta
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
    }

    // Recebe se o jogador está pulando ou apenas andando normalmente
    public void Move(float movimento, bool pulando)
	{
        Debug.Log("Entrou em move");
        // Se pode se mover
        if (m_AirControl)
		{
            Debug.Log("Entrou em air_control");
            // Move o personagem de acordo com sua velocidade atual
			Vector3 velocidadeAtual = new Vector2(movimento * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, velocidadeAtual, ref m_Velocity, m_MovementSmoothing);

			if (movimento > 0 && !olhandoDireita)
			{
				Flip(false); //virar para a direita
			}
			else if (movimento < 0 && olhandoDireita)
			{
				Flip(true); //virar para a esquerda
			}
        }

        // If the player should jump...
		if (m_Grounded && pulando)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, forcaPulo));
		}

    }

    // Para mudanças de direção (direita - esquerda)
    private void Flip(bool direcao)
	{
        olhandoDireita = !olhandoDireita; // Inverte o lado em que o jogador está olhando

        // Mudando a escala de 1 para -1 ou ao contrário inverte a orientação do jogador na cena
        Vector3 escala = transform.localScale;
        if(direcao)
        {
            escala.x = -1;
        }
        else
        {
            escala.x = 1;
        }

        transform.localScale = escala;
    }

}
