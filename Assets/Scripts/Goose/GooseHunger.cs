using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseHunger : MonoBehaviour
{
    [Tooltip("The amount of hunger that will decay each tick.")]
    [SerializeField] private float _decayRate = 1.0f;

    [Tooltip("The amount of hunger that will be replenished each tick while eating.")]
    [SerializeField] private float _replenishRate = 5.0f;

    [SerializeField] private int _startingHunger = 100;
    [SerializeField] private float _currentHunger;

    private void Start()
    {
        _currentHunger = _startingHunger;
        StartCoroutine(DecrementHunger());
    }

    private IEnumerator DecrementHunger()
    {
        while (true)
        {
            if (_currentHunger > 0)
            {
                _currentHunger -= _decayRate;
            }
            else
            {
                Debug.Log("The Goose Starved!");
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void StopHungerDecay()
    {
        StopCoroutine(DecrementHunger());
    }

    public void StartHungerDecay()
    {
        StartCoroutine(DecrementHunger());
    }
}
