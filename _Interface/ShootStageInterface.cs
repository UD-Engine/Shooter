﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UDEngine;
using UDEngine.Core;
using UDEngine.Core.Shooter;

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
		// Forcefully set complete or incomplete
		// This is to fix the BAD loopType problem in UShooter
		IShootStage SetComplete(bool condition);
	}
}
