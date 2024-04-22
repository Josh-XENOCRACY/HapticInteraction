using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] private ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start() {
        XRGrabInteractable _gI = GetComponent<XRGrabInteractable>();
        _gI.activated.AddListener(x => Shoot());
    }

    public void Shoot() {
       //raycast shoot and play flash 
       Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hit);
       Shootable o = hit.transform.gameObject.GetComponentInParent<Shootable>();
       muzzleFlash.Play();
       if (o) {
           o.takeDamage(1);
       }
    }
}
