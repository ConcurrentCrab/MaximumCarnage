using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour {

    [SerializeField] float aimY;
    [SerializeField] float aimVel;

    Camera cam;

    Vector3 inputAim = Vector3.zero;

    void Start() {
        cam = GameGlobal.game.Cam;
    }

    void Update() {
    }

    public void processAim() {
        transform.forward = Vector3.RotateTowards(transform.forward, inputAim, aimVel, 0f);
    }

    void OnInputAimMouse(InputValue value) {
        Ray ray = cam.ScreenPointToRay(value.Get<Vector2>());
        float travel = (aimY - ray.origin.y) / Vector3.Dot(ray.direction, Vector3.up);
        Vector3 p = ray.GetPoint(travel);
        p.y = 0f;
        inputAim = (p - transform.position).normalized;
    }

    void OnInputAimController(InputValue value) {
        Vector2 dir = value.Get<Vector2>().normalized;
        inputAim = new Vector3(dir.x, 0f, dir.y);
    }

}
