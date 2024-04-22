using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class RespawnButton : MonoBehaviour
{
    private XRSimpleInteractable _button;
    [FormerlySerializedAs("_objects")] [SerializeField] private GameObject[] objects;
    private void Start()
    {
        _button = GetComponent<XRSimpleInteractable>();
        _button.activated.AddListener(x=> Reenable());
    }

    public void Reenable()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }
}
