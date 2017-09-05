using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

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
	/// Shoot Actor. Function similar to that of UBulletActor or inside UBulletRegionTrigger
	/// </summary>
	public class UShootActor : MonoBehaviour {

		#region UNITYFUNC
		void Awake () {
		}

		// Use this for initialization
		void Start () {
			
		}
			
		// Update is called once per frame
		void Update () {

		}
		#endregion

		#region PROP
		public UShootEvent shootEvents = null;
		public UShooter shooter = null;
		#endregion

		#region METHOD
		public UShooter GetShooter() {
			return this.shooter;
		}
		public UShootActor SetShooter(UShooter newShooter) {
			this.shooter = newShooter;
			return this;
		}

		public UShootActor AddShootEvent(UnityAction<UBulletObject> newEvent) {
			if (shootEvents == null) {
				shootEvents = new UShootEvent ();
			}
			shootEvents.AddListener (newEvent);
			return this;
		}
			
		public UShootActor InvokeShootEvents(UBulletObject shotBullet) { // This will be called in StartStage() in stages immediately on shoot
			if (shootEvents != null) {
				shootEvents.Invoke (shotBullet);
			}
			return this;
		}

		public UShootActor ClearShootEvents() {
			shootEvents = null;
			return this;
		}
		#endregion
	}
}