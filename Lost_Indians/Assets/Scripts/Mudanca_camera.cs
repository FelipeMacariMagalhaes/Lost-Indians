using UnityEngine;

public class Mudanca_camera : MonoBehaviour
{/*
    [Header("Limites da câmera")]
    public float maxDeslocamentoX = 3f;
    public float maxDeslocamentoY = 2f;

    [Header("Suavidade")]
    public float suavidade = 5f;

    [Header("Travas de modo")]
    public float distanciaTravamento = 0.2f;

    private Vector3 posInicial;
    private Vector3 posTravada;

    [HideInInspector]
    public bool modoTravado = false;
   
    private bool cameraEmTransicao = false;
    public Troca_player_TopDown player_TopDown;
    public Troca_playerPlataform player_Plataform;
    void Start()
    {
        posInicial = transform.position;
        posTravada = posInicial;
    }

    void Update()
    {
        Vector3 mouseDelta = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);

        if (mouseDelta.magnitude > 0.01f && !cameraEmTransicao)
        {
            Vector3 alvo = player.position + new Vector3(
                Mathf.Clamp(mouseDelta.x, -maxDeslocamentoX, maxDeslocamentoX),
                Mathf.Clamp(mouseDelta.y, -maxDeslocamentoY, maxDeslocamentoY),
                transform.position.z
            );

            transform.position = Vector3.Lerp(transform.position, alvo, Time.deltaTime * suavidade);

            if (Mathf.Abs(alvo.y - (player.position.y + maxDeslocamentoY)) < distanciaTravamento)
            {
                modoTravado = true; // TopDown
                posTravada = new Vector3(transform.position.x, player.position.y + maxDeslocamentoY, transform.position.z);
                 player_TopDown.topDown = true;
            }
            else if (Mathf.Abs(alvo.y - (player.position.y - maxDeslocamentoY)) < distanciaTravamento)
            {
                modoTravado = true; // Plataforma
                posTravada = new Vector3(transform.position.x, player.position.y - maxDeslocamentoY, transform.position.z);
                player_Plataform.plataform = true;
            }
            else
            {
                modoTravado = false;
            }
        }
        else
        {
            cameraEmTransicao = true;
            Vector3 alvo = modoTravado ? posTravada : posInicial;
            transform.position = Vector3.Lerp(transform.position, alvo, Time.deltaTime * suavidade);

            if (Vector3.Distance(transform.position, alvo) < 0.01f)
               cameraEmTransicao = false;
      */  }      
