using UnityEngine;

public class ProjectileHolder : MonoBehaviour {

    [SerializeField] int childrenMax;

    void Start() {        
    }

    void Update() {
        if (transform.childCount <= childrenMax) {
            return;
        }
        for (int i = 0; i < (transform.childCount - childrenMax); i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

}
