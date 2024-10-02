using UnityEngine;

public class Crosshair : MonoBehaviour {

    RectTransform rectTransform;
    PlayerAim playerAim;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        playerAim = GameGlobal.game.Player.GetComponent<PlayerAim>();
    }

    void Update() {
        Vector2 pos = playerAim.getAimPoint();
        rectTransform.position = new Vector3(pos.x, pos.y, 0f);
    }

}
