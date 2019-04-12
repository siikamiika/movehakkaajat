using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class SensorData : MonoBehaviour {
	private const string	TAG = "VisualizationSceneScript; ";
	private const bool		isLogging = false;
	private float angularCorrection = 1/(4*Mathf.PI);// make it synchronous unity

    public Vector3 angularVelocity = new Vector3();
    public Vector3 linearAcceleration = new Vector3();

	void Start () {
		// attach event
		MovesenseController.Event += OnMovesenseControllerCallbackEvent;

        // Let's just subscribe all devices if we had more than one
        foreach(var device in MovesenseDevice.Devices)
        {
            MovesenseController.Subscribe(device.Serial, SubscriptionPath.AngularVelocity, SampleRate.medium);
            MovesenseController.Subscribe(device.Serial, SubscriptionPath.LinearAcceleration, SampleRate.medium);

        }
    }

	void OnMovesenseControllerCallbackEvent(object sender, MovesenseController.EventArgs e) {
		switch (e.Type) {
		case MovesenseController.EventType.NOTIFICATION:
			for(int i = 0; i < e.OriginalEventArgs.Count; i++) {
				var ne = (NotificationCallback.EventArgs) e.OriginalEventArgs[i];
				UpdateTransform(MovesenseDevice.ContainsSerialAt(ne.Serial), ne);
			}
			break;
		}
	}
	
	private void UpdateTransform(int serialListPosition, NotificationCallback.EventArgs e) {
        // ignore magnetic field, heratrate and temperature
        float x, y, z;
		if (e.Subscriptionpath == SubscriptionPath.MagneticField || e.Subscriptionpath == SubscriptionPath.HeartRate || e.Subscriptionpath == SubscriptionPath.Temperature) {
			return;
		}

		var notificationFieldArgs = (NotificationCallback.FieldArgs) e;
		
		if (e.Subscriptionpath == SubscriptionPath.AngularVelocity) {
			z = (float)notificationFieldArgs.Values[notificationFieldArgs.Values.Length-1].z*angularCorrection;
			y = (float)notificationFieldArgs.Values[notificationFieldArgs.Values.Length-1].y*angularCorrection;
			x = (float)notificationFieldArgs.Values[notificationFieldArgs.Values.Length-1].x*angularCorrection;
            angularVelocity = new Vector3(x, y, z);

		}  else if (e.Subscriptionpath == SubscriptionPath.LinearAcceleration) {
            z = (float)notificationFieldArgs.Values[notificationFieldArgs.Values.Length - 1].z ;
            y = (float)notificationFieldArgs.Values[notificationFieldArgs.Values.Length - 1].y ;
            x = (float)notificationFieldArgs.Values[notificationFieldArgs.Values.Length - 1].x ;
            linearAcceleration = new Vector3(x, y, z);
        }
	}

}
