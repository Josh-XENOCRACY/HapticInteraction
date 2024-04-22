using UnityEngine;

public class Shootable : MonoBehaviour {
    
    [SerializeField] private float health;
    private bool _dead;
    public void takeDamage(float dmg) {
        health -= dmg;
        if (health < 1) {
            if (_dead == false) {
                gameObject.SetActive(false);
                _dead = true;
            } else {
                _dead = false;
                health = 2; //base - 1 since it's already been shot once since being re-activated!
            }
        }
        
    }
}
