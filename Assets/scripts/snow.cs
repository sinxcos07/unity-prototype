using UnityEngine;

public class snow : MonoBehaviour
{
    [SerializeField] ParticleSystem snowParticle;
    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("floor");
        if (collision.gameObject.layer == layerIndex)
        {
            snowParticle.Play();
        }
           
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("floor");
        if (collision.gameObject.layer == layerIndex)
        {
            snowParticle.Stop();
        }


    }

}
