using System.Collections;
using UnityEngine;

public class GooseHunger : MonoBehaviour
{
    [Tooltip("The amount of hunger that will decay each tick.")]
    [SerializeField] private int _decayRate = 5;

    [Tooltip("The amount of hunger that will be replenished each tick while eating.")]
    [SerializeField] private int _replenishRate = 5;

    [Tooltip("When _currentHunger <= _hungerThreshold the goose will look to find food" +
        "in the bowl if it is available")]
    [SerializeField] private int _hungerThreshold = 50;

    [SerializeField] private int _startingHunger = 100;
    [SerializeField] private float _currentHunger;

    private Coroutine _decrementRoutine;
    private Coroutine _incrementRoutine;

    public bool IsEating;

    public bool IsGooseHungry() => _currentHunger <= _hungerThreshold;

    private void Start()
    {
        _currentHunger = _startingHunger;

        // The goose will start losing hunger as soon as the game starts.
        StartHungerDecay();
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

    /*
     *  This Coroutine increments the hunger of the goose by the _replenishRate once every second.
     *  There needs to be enough food in the bowl to eat, if there is not the coroutine will end and the 
     *  DecrementHunger Coroutine will be resumed.
     *  Likewise, once the goose is full hunger will begin decrementing again.
     */
    private IEnumerator IncrementHunger()
    {
        IsEating = true;
        while (true)
        {
            if (_currentHunger > _startingHunger - _replenishRate)
            {
                Debug.Log("The Goose is full.");
                IsEating = false;
                _incrementRoutine = null;
                StartHungerDecay();
                yield break;
            }

            bool canEat = FoodBowlManager.Instance.RemoveFoodFromBowl(_replenishRate);

            if (!canEat)
            {
                Debug.Log("Not enough food in the bowl to eat.");
                IsEating = false;
                _incrementRoutine = null;
                StartHungerDecay();
                yield break;
            }

            _currentHunger += _replenishRate;
            yield return new WaitForSeconds(1f);
        }
    }

    public void StartHungerDecay()
    {
        _decrementRoutine ??= StartCoroutine(DecrementHunger());
    }

    public void StopHungerDecay()
    {
        if (_decrementRoutine != null)
        {
            StopCoroutine(_decrementRoutine);
            _decrementRoutine = null;
        }

    }

    public void StartHungerReplenish()
    {
        _incrementRoutine ??= StartCoroutine(IncrementHunger());
    }

    public void StopHungerReplenish()
    {
        if (_incrementRoutine != null)
        {
            StopCoroutine(_incrementRoutine);
            _incrementRoutine = null;
        }

    }


}
