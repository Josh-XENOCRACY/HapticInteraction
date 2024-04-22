using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballObject;
    [SerializeField] private Transform spawnPoint;
    
    private XRSimpleInteractable _button;
    // Start is called before the first frame update
    void Start() {
       _button = GetComponent<XRSimpleInteractable>();
       _button.activated.AddListener(x => Spawn()); //if this doesn't work then try on selected rather than activated.
    }

    // Update is called once per frame
    public void Spawn() {
        Instantiate(ballObject, spawnPoint.position, Quaternion.identity);
    }
}
