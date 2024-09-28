using UnityEngine;

public interface IHurtable {

    void Hurt(float val);

}

public interface IKnockable {

    void Knock(Vector3 dir, float val);

}
