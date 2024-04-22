using System.Linq;
using UnityEngine;

public class Marker : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private int size;

    private Renderer _r;
    private Color[] _colors;
    private float _tipDist = .03f;
    private Whiteboard _wb;
    private Vector2 _touchPosition;
    private bool _activeLastFrame;
    private Vector2 _lastPos;
    private Quaternion _lastRot;
    
    private void Start() {
        _r = tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_r.material.color, size * size).ToArray();
    }

    private void Update() {
        Draw();
    }

    private void Draw() {
        if (Physics.Raycast(tip.position,transform.up, out RaycastHit hit, _tipDist)) {
            if (hit.transform.CompareTag("whiteboard")) {
                if (!_wb) {
                    _wb = hit.transform.GetComponent<Whiteboard>();
                }

                _touchPosition = new Vector2(hit.textureCoord.x, hit.textureCoord.y);
                int x = (int)(_touchPosition.x * _wb.texSize.x - (size / 2));
                int y = (int)(_touchPosition.y * _wb.texSize.y - (size / 2));

                if (y < 0 || y > _wb.texSize.y || x < 0 || x > _wb.texSize.x) return; 
                if (_activeLastFrame) {
                    transform.rotation = _lastRot;
                    _wb.tex.SetPixels(x,y,size,size,_colors);
                    for (float f = 0f; f < 1f; f += 0.02f) {
                        int lerpX = (int)Mathf.Lerp(_lastPos.x, x, f);
                        int lerpY = (int)Mathf.Lerp(_lastPos.y, y, f);
                        _wb.tex.SetPixels(lerpX,lerpY,size,size,_colors);
                    }
                    _wb.tex.Apply();
                }

                _lastPos = new Vector2(x, y);
                _lastRot = transform.rotation;
                _activeLastFrame = true;
                return;
            }
        }
        _wb = null;
        _activeLastFrame = false;
    }
}
