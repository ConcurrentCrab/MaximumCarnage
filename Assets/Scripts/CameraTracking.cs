using UnityEngine;

public class CameraTracking : MonoBehaviour {

    [SerializeField] float smoothTime;

    Transform target;
    Vector3 relativePos = Vector3.zero;
    Vector3 smoothVel = Vector3.zero;

    void Start() {
        target = GameGlobal.game.Player.transform;
        relativePos = transform.position - target.position;
    }

    void Update() {
    }

    private void FixedUpdate() {
        if (!target) {
            return;
        }
        transform.position = Vector3.SmoothDamp(transform.position, target.position + relativePos, ref smoothVel, smoothTime);
    }

}
