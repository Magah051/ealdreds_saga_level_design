using UnityEngine;

public class BarreiraMaster : MonoBehaviour
{
    // Refer�ncias aos objetos de m�sica e efeitos sonoros
    public GameObject musicObject;
    public GameObject musicAttackObject;
    public GameObject dragonFlyAudioObject;
    public GameObject dragonCanvas;

    public static bool playerInside = false;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        // Obt�m o componente BoxCollider2D no Awake
        boxCollider = GetComponent<BoxCollider2D>();

        // Definir volumes iniciais
        SetInitialVolumes();
    }

    void Start()
    {
        playerInside = false;
    }

    // Chamado quando algo entra na �rea de colis�o
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou na �rea � o jogador
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            dragonCanvas.SetActive(true);
            SetNewsVolumes();

            // Chama a fun��o para desativar o trigger ap�s 3 segundos
            Invoke("DisableTriggerAfterDelay", 1f);
        }
    }

    // Fun��o para desativar o trigger ap�s um atraso
    private void DisableTriggerAfterDelay()
    {
        boxCollider.isTrigger = false;
    }

    // Fun��o para definir os volumes iniciais dos objetos de �udio
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
