using UnityEngine;
using UnityEngine.SceneManagement;  

public class finishline : MonoBehaviour
{
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("player");
        if (collision.gameObject.layer == layerIndex)
        {
            finishEffect.Play();
            Invoke("ReloadScene", delayTime);

        }

              
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
