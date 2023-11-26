using UnityEngine;

public class ArmaBranca : MonoBehaviour
{
    [SerializeField] float minimum;
    [SerializeField] float maximum;
    [SerializeField] float t;
    [SerializeField] float speed;
    [SerializeField] bool ativar = false;
    [SerializeField] int dano;
    [SerializeField] Quaternion rotate;

    private void Update()
    {

        // if (Input.GetKeyDown(KeyCode.Mouse0))
        // {


        //}
        // if (ativar)
        //  {
        //t = t + 1 * speed * Time.deltaTime;
        //transform.rotation = Quaternion.Euler(0, Mathf.Lerp(minimum, maximum, t), 0);
        //   }
        if (transform.rotation.y >= 1)
        {
            // ativar = false;

            // transform.rotation = rotate;
            // t = 0;

        }
    }
    public void Usar()
    {
        Protagonista protagonista = GameController.instance.PlayerTransform.GetComponent<Protagonista>();
        dano = protagonista.GetDano();
        Invoke("AtavarArma", 1f);

    }
    public void AtivarArma()
    {

        Invoke("DesativarArma", 0.1f);
        // ativar = true;
    }
    public void SetDano(int valor)
    {
        dano = valor;
    }

    public float Dano { get { return dano; } }
}
