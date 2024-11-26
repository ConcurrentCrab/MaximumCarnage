using UnityEngine;

public static class PlaneUtils {

	public static Vector3 RaycastPoint(this Plane p, Ray r) {
		bool intersects = p.Raycast(r, out float enter);
		if (!intersects && enter == 0f) {
			return p.ClosestPointOnPlane(r.origin);
		}
		return r.GetPoint(enter);
	}

}
