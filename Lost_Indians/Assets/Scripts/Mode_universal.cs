using UnityEngine;

public class Mode_universal : MonoBehaviour
{

    private Animator anim;
   
    public MoveTopDown moviTopDown;
    public Movi_2 movi_Plataform;    
    public Rigidbody2D Rigidbody2D;
    public bool plataform = false;
    public int modoAtivo = 0;

    private void Start()
    {
        AtualizarMovimentacao();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       
    }

    public void TrocarModo(int novoModo)
    {
        if (novoModo == modoAtivo) return; // evita trocas desnecess�rias
        {
            modoAtivo = novoModo;
            AtualizarMovimentacao();           
        }
    }

    public void AtualizarMovimentacao()
    {
        bool isTopDown = (modoAtivo == 0); // jogo de boleanas
        moviTopDown.enabled = isTopDown;
        movi_Plataform.enabled = !isTopDown;
        if(isTopDown == true)
        {
            Rigidbody2D.gravityScale = 0;
            Rigidbody2D.linearVelocity = Vector2.zero;
            plataform = false;
        }
        else 
        {
            Rigidbody2D.gravityScale = 1;
            Rigidbody2D.linearVelocity = Vector2.zero;
            plataform = true;
        }
        anim.SetBool("Plataform", plataform);


    }       
    }
