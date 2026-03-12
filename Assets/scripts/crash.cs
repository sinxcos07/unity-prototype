using UnityEngine;
using UnityEngine.SceneManagement;  

public class crash : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem crasheffect;
    playercontrol playercont;
    void Start()
    {
        playercont = FindFirstObjectByType<playercontrol>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("floor");
        if (collision.gameObject.layer == layerIndex)
        {
            playercont.DisableControl();
            crasheffect.Play();
            Invoke("ReloadScene",delay);  

        }

    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
