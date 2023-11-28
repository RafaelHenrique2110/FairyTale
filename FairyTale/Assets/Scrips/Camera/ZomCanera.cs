using Cinemachine;
using UnityEngine;

public class ZomCanera : MonoBehaviour
{

    public float decreaseTime = 5f; // Tempo total para diminuir o ortho size
    public float targetOrthoSize = 5f; // Tamanho ortho size final desejado

    private CinemachineVirtualCamera virtualCamera;
    private float initialOrthoSize;
   public float timer;
    public bool ativado= true;
    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        initialOrthoSize = virtualCamera.m_Lens.OrthographicSize;
        timer = 0f;
    }

    private void Update()
    {
        if (ativado)
        {
            // Verificar se o ortho size já foi diminuído completamente
            if (timer >= decreaseTime)
            {
                GameController.instance.AbilitarHud();
                GameController.instance.AtivarPlayer(true);
                ativado = false;
                return;
            }


            timer += Time.deltaTime;

            // Calcular o ortho size atual com base no tempo decorrido
            float t = timer / decreaseTime;
            float currentOrthoSize = Mathf.Lerp(initialOrthoSize, targetOrthoSize, t);

            // Atualizar o ortho size da câmera virtual
            virtualCamera.m_Lens.OrthographicSize = currentOrthoSize;
        }
      
    }
}
