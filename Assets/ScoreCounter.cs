using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int _score;
    
    private void OnTriggerEnter(Collider other)
    {
        _score++;
        text.text = _score.ToString();
    }
}
