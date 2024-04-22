using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public Texture2D tex;
    public Vector2 texSize = new Vector2(2048, 2048);

    private void Start()
    {
        Renderer r = GetComponent<Renderer>();
        tex = new Texture2D((int)texSize.x, (int)texSize.y);
        r.material.mainTexture = tex;
    }
}
