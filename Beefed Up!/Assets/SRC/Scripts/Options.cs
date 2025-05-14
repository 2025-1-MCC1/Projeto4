using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    [SerializeField]
    GameObject painelinicio, painelOption;
    // Este método será chamado quando o jogador clicar em "Jogar"
    public void options()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DesativaPainel()
    {
        painelinicio.SetActive(false);
        painelOption.SetActive(true);
       
    }
    public void AtivaPainel()
    {
        painelinicio.SetActive(true);
        painelOption.SetActive(false);

    }
}
