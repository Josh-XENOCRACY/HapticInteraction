using UnityEngine;
public class GameManager : MonoBehaviour {
   [SerializeField] private GameObject player;
   public void TeleportTo(Transform target) {
      player.transform.position = target.position;
   } 
}
