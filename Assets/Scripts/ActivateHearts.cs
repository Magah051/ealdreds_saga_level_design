using UnityEngine;

public class ActivateHearts : MonoBehaviour
{
    public GameObject hearts; // Refer�ncia ao GameObject Hearts
    public float activationInterval = 20f; // Intervalo de ativa��o em segundos
    private int heartIndex = 1; // �ndice do cora��o atual

    // M�todo chamado quando o script � inicializado
    void Start()
    {
        // Inicia a repeti��o da fun��o ActivateHeart
        InvokeRepeating("ActivateHeart", 0f, activationInterval);
    }

    // M�todo para ativar um cora��o a cada intervalo
    void ActivateHeart()
    {
        // Obt�m o nome do cora��o atual baseado no �ndice
        string heartName = "Heart" + heartIndex;

        // Encontra o GameObject do cora��o atual dentro do Hearts
        Transform heartTransform = hearts.transform.Find(heartName);

        // Verifica se o cora��o atual foi encontrado
        if (heartTransform != null)
        {
            // Ativa o GameObject do cora��o atual
            heartTransform.gameObject.SetActive(true);

            // Incrementa o �ndice para apontar para o pr�ximo cora��o
            heartIndex++;

        }
    }
}
