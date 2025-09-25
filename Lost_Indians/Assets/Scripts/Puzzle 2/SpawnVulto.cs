using UnityEngine;

public class SpawnVulto : MonoBehaviour
{
    [Header("Configuração do Spawn")]
    public GameObject squarePrefab; 
    public float intervalo = 10f;   
    public float duracao = 3f;      
    public float distancia = 1f;    
 
    private float timer = 0f;
    private Vector2 lastMoveDir = Vector2.up; 
 
    void Update()
    {
        Vector2 inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (inputDir != Vector2.zero)
        {
            if (Mathf.Abs(inputDir.x) > Mathf.Abs(inputDir.y))
                lastMoveDir = new Vector2(Mathf.Sign(inputDir.x), 0);
            else
                lastMoveDir = new Vector2(0, Mathf.Sign(inputDir.y));
        }
        timer += Time.deltaTime;
        if (timer >= intervalo)
        {
            Spawn();
            timer = 0f;
        }
    }
 
    void Spawn()
    {
        Vector3 spawnPos = transform.position + (Vector3)(lastMoveDir * distancia);
        GameObject obj = Instantiate(squarePrefab, spawnPos, Quaternion.identity);
        obj.transform.SetParent(transform);
        Destroy(obj, duracao);
    }
}