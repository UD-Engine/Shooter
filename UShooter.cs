﻿using System.Collections;
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
using UDEngine.Interface;

namespace UDEngine.Components.Shooter {
	/// <summary>
	/// Shooter.
	/// Shooter's job is simple: SHOOT bullet OUT
	/// It does NOT care about anything related to motion. It ONLY cares about the interval between each shot
	/// It will always shoot towards its own UP direction
	/// </summary>
	public class UShooter : MonoBehaviour {
		#region UNITYFUNC
		void Awake () {
			if (this.stages == null) {
				this.stages = new List<IShootStage> ();
			}
		}

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}
		#endregion

		#region PROP
		public Transform trans;
		public List<IShootStage> stages;
		public UShootActor actor;
		public UBulletPoolManager bulletPoolManager; // This is used as a reference of the indices of pooled bullet (especially in Shoot Stages)
		#endregion

		#region METHOD
		public Transform GetTransform () {
			return this.trans;
		}
		public UShooter SetTransform(Transform newTransform) {
			this.trans = newTransform;
			return this;
		}

		public List<IShootStage> GetStages() {
			return this.stages;
		}
		public UShooter AddStage(IShootStage newStage) {
			newStage.SetShooter (this); // Remember to set shooter so it could be accessed in stage object
			this.stages.Add (newStage);
			return this;
		}
		public UShooter ClearStages() {
			this.stages.Clear ();
			return this;
		}

		public UShootActor GetActor() {
			return this.actor;
		}
		public UShooter SetActor(UShootActor newActor) {
			this.actor = newActor;
			return this;
		}

		public UBulletPoolManager GetBulletPoolManager() {
			return this.bulletPoolManager;
		}
		public UShooter SetBulletPoolManager(UBulletPoolManager newPoolManager) {
			this.bulletPoolManager = newPoolManager;
			return this;
		}

		public UShooter Shoot() {
			if (this.stages == null) {
				UDebug.Warning ("no shoot stages added to shooter");
				return this;
			}
			StartCoroutine (_ShootCoroutine ());
			return this;
		}

		private IEnumerator _ShootCoroutine() {
			int stageLen = this.stages.Count;

			if (stageLen == 1) { // optimize for single staged shooter
				StartCoroutine (this.stages [0].StartStage ());
			} else {
				// Loop through each stage, call their own coroutines, and wait till complete
				for (int i = 0; i < stageLen; i++) {
					IShootStage currStage = this.stages [i];
					// currStage.SetShooter (this); // Set before during adding
					StartCoroutine (currStage.StartStage ());
					yield return new WaitUntil(() => currStage.IsComplete());
				}
			}

			yield break;
		}
		#endregion
	}
}
