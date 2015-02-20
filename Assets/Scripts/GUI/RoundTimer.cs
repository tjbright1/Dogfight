using UnityEngine;
using System.Collections;
using UnityUtilLib;

/// <summary>
/// Round timer.
/// </summary>
[RequireComponent(typeof(GUIText))]
public class RoundTimer : MonoBehaviour {

	/// <summary>
	/// The game controller.
	/// </summary>
	[SerializeField]
	private PhantasmagoriaGameController gameController;

	/// <summary>
	/// The color of the flash.
	/// </summary>
	[SerializeField]
	private Color flashColor;

	/// <summary>
	/// The flash interval.
	/// </summary>
	[SerializeField]
	private CountdownDelay flashInterval;

	/// <summary>
	/// The flash threshold.
	/// </summary>
	[SerializeField]
	private float flashThreshold;

	private Color normalColor;
	private bool flashState;
	private GUIText label;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {
		label = guiText;
		normalColor = label.color;
		flashState = false;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {
		int timeSec = Mathf.FloorToInt (gameController.RemainingRoundTime);
		int seconds = timeSec % 60;
		int minutes = timeSec / 60;
		label.text = minutes.ToString ("D2") + ":" + seconds.ToString ("D2");;
		if (timeSec < flashThreshold) {
			if(flashInterval.Tick(Time.deltaTime)) {
				label.color = (flashState) ? flashColor : normalColor;
				flashState = !flashState;
			}
		} else {
			label.color = normalColor;
			flashState = false;
			flashInterval.ForceReady();
		}
	}
}
