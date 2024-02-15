using UnityEngine;

public class BarreiraMaster : MonoBehaviour
{
    // Referências aos objetos de música e efeitos sonoros
    public GameObject musicObject;
    public GameObject musicAttackObject;
    public GameObject dragonFlyAudioObject;
    public GameObject dragonCanvas;

    public static bool playerInside = false;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        // Obtém o componente BoxCollider2D no Awake
        boxCollider = GetComponent<BoxCollider2D>();

        // Definir volumes iniciais
        SetInitialVolumes();
    }

    void Start()
    {
        playerInside = false;
    }

    // Chamado quando algo entra na área de colisão
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou na área é o jogador
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            dragonCanvas.SetActive(true);
            SetNewsVolumes();

            // Chama a função para desativar o trigger após 3 segundos
            Invoke("DisableTriggerAfterDelay", 1f);
        }
    }

    // Função para desativar o trigger após um atraso
    private void DisableTriggerAfterDelay()
    {
        boxCollider.isTrigger = false;
    }

    // Função para definir os volumes iniciais dos objetos de áudio
    private void SetInitialVolumes()
    {
        if (musicObject != null)
        {
            musicObject.GetComponent<AudioSource>().volume = 0.4f;
        }

        if (musicAttackObject != null)
        {
            musicAttackObject.GetComponent<AudioSource>().volume = 0.0f;
        }

        if (dragonFlyAudioObject != null)
        {
            dragonFlyAudioObject.GetComponent<AudioSource>().volume = 0.0f;
        }
    }

    private void SetNewsVolumes()
    {
        if (musicObject != null)
        {
            musicObject.GetComponent<AudioSource>().volume = 0.0f;
        }

        if (musicAttackObject != null)
        {
            musicAttackObject.GetComponent<AudioSource>().volume = 0.3f;
        }

        if (dragonFlyAudioObject != null)
        {
            dragonFlyAudioObject.GetComponent<AudioSource>().volume = 0.7f;
        }
    }
}
