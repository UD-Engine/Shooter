using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UDEngine;
using UDEngine.Components;
using UDEngine.Components.Shooter;

namespace UDEngine.Interface {
	/// <summary>
	/// The general interface for all shoot stages
	/// </summary>
	public interface IShootStage {
		// Set shooter so that later we can access things in the StartStage()
		IShootStage SetShooter (UShooter shooter);
		// Actual stage action
		IEnumerator StartStage ();
		// Polled condition to stall shooter going to the next stage
		bool IsComplete ();
	}
}
