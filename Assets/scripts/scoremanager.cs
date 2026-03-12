using TMPro;    
using UnityEngine;

public class scoremanager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoretext;
    int score = 0;
    
    public void addscore (int addscore)
    {
        score += addscore;
        scoretext.text = "Score " + score;

    }
    
}
