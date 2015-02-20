using UnityEngine;
using UnityUtilLib;
using System.Collections;

public class PlayerGrazeHitbox : CachedObject {

	private AbstractPlayableCharacter player;

	void Start() {
		player = Transform.parent.GetComponent<AbstractPlayableCharacter> ();
		if (player == null) {
			Debug.LogError("PlayerGrazeHitbox should be on a child object of a GameObject with an Avatar sublcass script");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (player != null) {
			Projectile proj = other.GetComponent<Projectile>();
			if(proj != null) {
				player.Graze(proj);
			}
		}
	}

//	void OnBulletCollision(ProjectileData other) {
//		if (player != null) {
//			player.Graze();
//		}
//	}
}
