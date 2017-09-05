using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using UDEngine.Components.Bullet;

namespace UDEngine.Components.Shooter {
	public class UShootEvent : UnityEvent<UBulletObject> {
		// unabstract the class
	}
}
