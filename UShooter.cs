using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UDEngine;
using UDEngine.Components;
using UDEngine.Components.Actor;
using UDEngine.Components.Bullet;
using UDEngine.Components.Collision;
using UDEngine.Components.Pool;
using UDEngine.Components.Shooter;
using UDEngine.Internal;

namespace UDEngine.Components.Shooter {
	/// <summary>
	/// Shooter.
	/// Shooter's job is simple: SHOOT bullet OUT
	/// It does NOT care about anything related to motion. It ONLY cares about the interval between each shot
	/// It will always shoot towards its own UP direction
	/// </summary>
	public class UShooter : MonoBehaviour {

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		public UShooter Shoot() {
			return this;
		}

		private IEnumerator _ShootCoroutine() {
			yield break;
		}


		public UShooter UseCustomShootCoroutine() {
			return this;
		}
	}
}
