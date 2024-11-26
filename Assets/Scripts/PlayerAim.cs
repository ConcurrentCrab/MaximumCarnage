using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour {

    [SerializeField] float aimVel;
    [SerializeField] float aimY;
    [SerializeField] float aimDistController;

    Camera cam;

    PlayerDeviceBase playerDevice = new();

    void Start() {
        cam = GameGlobal.game.Cam;
    }

    void Update() {
    }

    public void processAim() {
        Vector3 aimDir = playerDevice.AimDir;
        transform.forward = Vector3.RotateTowards(transform.forward, aimDir, aimVel, 0f);
    }

    public Vector2 getAimPoint() {
        return playerDevice.AimPoint;
    }

    void OnInputAimMouse(InputValue value) {
        if (playerDevice is not PlayerDeviceMouse) {
            playerDevice = new PlayerDeviceMouse(transform, cam, aimY);
        }
        playerDevice.OnInput(value);
    }

    void OnInputAimController(InputValue value) {
        if (playerDevice is not PlayerDeviceController) {
            playerDevice = new PlayerDeviceController(transform, cam, aimY, aimDistController);
        }
        playerDevice.OnInput(value);
    }

    class PlayerDeviceBase {

        virtual public void OnInput(InputValue value) {}

        virtual public Vector3 AimDir => Vector3.zero;

        virtual public Vector2 AimPoint => Vector2.zero;

    }

    class PlayerDeviceMouse : PlayerDeviceBase {

        Transform transform;
        Camera cam;
        float aimY;

        Vector2 aimPoint = Vector2.zero;

        public PlayerDeviceMouse(Transform t, Camera c, float y) {
            cam = c;
            transform = t;
            aimY = y;
        }

        override public void OnInput(InputValue value) {
            Vector2 val = value.Get<Vector2>();
            aimPoint = val;
        }

        override public Vector3 AimDir {
            get {
                Ray ray = cam.ScreenPointToRay(aimPoint);
                Vector3 intersect = new Plane(Vector3.up, aimY).RaycastPoint(ray);
                Vector3 dir = (new Vector3(intersect.x, 0f, intersect.z) - transform.position).normalized;
                return dir;
            }
        }

        override public Vector2 AimPoint => aimPoint;

    }

    class PlayerDeviceController : PlayerDeviceBase {

        Transform transform;
        Camera cam;
        float aimY;
        float aimDist;

        Vector3 aimDir = Vector3.zero;

        public PlayerDeviceController(Transform t, Camera c, float y, float d) {
            cam = c;
            transform = t;
            aimY = y;
            aimDist = d;
        }

        override public void OnInput(InputValue value) {
            Vector2 val = value.Get<Vector2>();
            Vector3 dir = new Vector3(val.x, 0f, val.y).normalized;
            if (dir == Vector3.zero) {
                return;
            }
            aimDir = dir;
        }

        override public Vector3 AimDir => aimDir;

        override public Vector2 AimPoint {
            get {
                Vector3 relpoint = aimDir * aimDist;
                Vector3 point = new Vector3(relpoint.x, aimY, relpoint.z) + transform.position;
                Vector3 campoint = cam.WorldToScreenPoint(point);
                Vector2 pos = new Vector2(campoint.x, campoint.y);
                return pos;
            }
        }

    }

}
