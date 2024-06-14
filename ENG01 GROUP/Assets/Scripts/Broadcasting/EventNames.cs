using UnityEngine;
using System.Collections;

/*
 * Holder for event names
 * Created By: NeilDG
 */ 
public class EventNames {
	public const string ON_UPDATE_SCORE = "ON_UPDATE_SCORE";
	public const string ON_CORRECT_MATCH = "ON_CORRECT_MATCH";
	public const string ON_WRONG_MATCH = "ON_WRONG_MATCH";
	public const string ON_INCREASE_LEVEL = "ON_INCREASE_LEVEL";

	public const string ON_PICTURE_CLICKED = "ON_PICTURE_CLICKED";


	public class ARBluetoothEvents {
		public const string ON_START_BLUETOOTH_DEMO = "ON_START_BLUETOOTH_DEMO";
		public const string ON_RECEIVED_MESSAGE = "ON_RECEIVED_MESSAGE";
	}

	public class ARPhysicsEvents {
		public const string ON_FIRST_TARGET_SCAN = "ON_FIRST_TARGET_SCAN";
		public const string ON_FINAL_TARGET_SCAN = "ON_FINAL_TARGET_SCAN";
	}

	public class ExtendTrackEvents {
		public const string ON_TARGET_SCAN = "ON_TARGET_SCAN";
		public const string ON_TARGET_HIDE = "ON_TARGET_HIDE";
		public const string ON_SHOW_ALL = "ON_SHOW_ALL";
		public const string ON_HIDE_ALL = "ON_HIDE_ALL";
		public const string ON_DELETE_ALL = "ON_DELETE_ALL";
	}

	public class X01_Events {
		public const string ON_FIRST_SCAN = "ON_FIRST_SCAN";
		public const string ON_FINAL_SCAN = "ON_FINAL_SCAN";
		public const string EXTENDED_TRACK_ON_SCAN = "EXTENDED_TRACK_ON_SCAN";
		public const string EXTENDED_TRACK_REMOVED = "EXTENDED_TRACK_REMOVED";
	}

	public class X22_Events {
		public const string ON_FIRST_SCAN = "ON_FIRST_SCAN";
		public const string ON_FINAL_SCAN = "ON_FINAL_SCAN";
		public const string EXTENDED_TRACK_ON_SCAN = "EXTENDED_TRACK_ON_SCAN";
		public const string EXTENDED_TRACK_REMOVED = "EXTENDED_TRACK_REMOVED";
	}

	public class S18_Events {
		public const string ON_FIRST_SCAN = "FIRST_TARGET_SCAN";
		public const string ON_FINAL_SCAN = "ON_FINAL_SCAN";
	}

	public class SpawnSystem
	{
		//SPHERE SPAWNING
		public const string ON_SPHERE_SPAWN = "ON_SPHERE_SPAWN";
		public const string ON_SPHERE_DESPAWN = "ON_SPHERE_DESPAWN";

		//CUBE SPAWNING
        public const string ON_CUBE_SPAWN_BUTTON_CLICKED = "ON_CUBE_SPAWN_BUTTON_CLICKED";
        public const string ON_CUBE_DESPAWN_BUTTON_CLICKED = "ON_CUBE_DESPAWN_BUTTON_CLICKED";

		//DESPAWNING
        public const string ON_DESPAWN_BUTTON_CLICKED = "ON_DESPAWN_BUTTON_CLICKED";
    }

	public class RootsFear
	{
		//successfull ice
		public const string ON_ICE_SUCCESS = "ON_ICE_SUCCESS";

        //fail ice
        public const string ON_ICE_FAIL = "ON_ICE_FAIL";

        //when customer gets mad
        public const string ON_CUSTOMER_MAD = "ON_CUSTOMER_MAD";

        //moving the ice
        public const string MOVE_TO_CHISEL = "MOVE_TO_CHISEL";
		public const string MOVE_TO_HAMMER = "MOVE_TO_HAMMER";
    }

	public class PoolSample {

		//spawning of normal ice
		public const string ON_REQUEST_POOL_PUSHED = "ON_REQUEST_POOL_PUSHED";
        public const string ON_RELEASE_POOL_PUSHED = "ON_RELEASE_POOL_PUSHED";

        //spawning of ice cubes/shards
        public const string SPAWN_PERFECT_ICE = "SPAWN_PERFECT_ICE";
        public const string SPAWN_IMPERFECT_ICE = "SPAWN_IMPERFECT_ICE";

    }
}







