using UnityEngine;

public class ActivateHearts : MonoBehaviour
{
    public GameObject hearts; // Referência ao GameObject Hearts
    public float activationInterval = 20f; // Intervalo de ativação em segundos
    private int heartIndex = 1; // Índice do coração atual

    // Método chamado quando o script é inicializado
    void Start()
    {
        // Inicia a repetição da função ActivateHeart
        InvokeRepeating("ActivateHeart", 0f, activationInterval);
    }

    // Método para ativar um coração a cada intervalo
    void ActivateHeart()
    {
        // Obtém o nome do coração atual baseado no índice
        string heartName = "Heart" + heartIndex;

        // Encontra o GameObject do coração atual dentro do Hearts
        Transform heartTransform = hearts.transform.Find(heartName);

        // Verifica se o coração atual foi encontrado
        if (heartTransform != null)
        {
            // Ativa o GameObject do coração atual
            heartTransform.gameObject.SetActive(true);

            // Incrementa o índice para apontar para o próximo coração
            heartIndex++;

        }
    }
}
