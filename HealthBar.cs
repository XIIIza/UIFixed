using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private Coroutine _changeHealthCorutine;

    private void OnEnable()
    {
        _player.ChangingHealth += ChangeHealth;
    }

    private void OnDisable()
    {
        _player.ChangingHealth -= ChangeHealth;
    }

    private void ChangeHealth()
    {
        if (_changeHealthCorutine != null)
        {
            StopCoroutine(_changeHealthCorutine);
        }

        _changeHealthCorutine = StartCoroutine(ChangeHealthCorutine());
    }

    private IEnumerator ChangeHealthCorutine()
    {
        var waitForSecond = new WaitForSeconds(0.05f);

        while (_slider.value != _player.Health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.Health, 1f);

            yield return waitForSecond;
        }
    }
}