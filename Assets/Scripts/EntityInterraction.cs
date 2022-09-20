using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EntityInterraction : MonoBehaviour
{
    [SerializeField] InputActionReference _clickInput;

    [SerializeField] TextMeshProUGUI _focusName;
    [SerializeField] Image _cursor;

    [SerializeField] Sprite _emptyCursor;
    [SerializeField] Color _emptyColor;

    [SerializeField] Sprite _lockedCursor;
    [SerializeField] Color _lockedColor;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 2, Color.yellow);
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 2f))
        {
            if (hit.collider.TryGetComponent<IUsable>(out IUsable usableComponent))
            {
                usableComponent.Use();
                _cursor.sprite = _lockedCursor;
                _cursor.color = _lockedColor;
                _focusName.text = usableComponent.GetName();
            }
            else
            {
                _cursor.sprite = _emptyCursor;
                _cursor.color = _emptyColor;
                _focusName.text = "";
            }
        }
        else
        {
            _cursor.sprite = _emptyCursor;
            _cursor.color = _emptyColor;
            _focusName.text = "";
        }
    }
}
