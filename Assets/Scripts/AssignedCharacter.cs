using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class AssignedCharacter : MonoBehaviour, IPointerDownHandler
{
	#region PUBLIC_VARIABLES

	public PlayerCharacter character;
	public TMP_Text _nameText;
	public TMP_Text _bonusText;

	[TextArea]
	public string _bonus;
	public string _name;


	public void OnPointerDown(PointerEventData pointerEventData)
	{
		//Output the name of the GameObject that is being clicked
		_nameText.text = _name;
		_bonusText.text = _bonus;
	}

	#endregion

}

