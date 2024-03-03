using UnityEngine;

public class RandomBallSelector
{
    private int _max;

    public RandomBallSelector(int maxBallSize)
    {
       this._max = maxBallSize;
    }

    public int SelectRandomBallIndex()
    {
        float[] probabilities = CalculateProbabilities();
        float randomValue = Random.value;

        float cumulativeProbability = 0;
        for (int i = 0; i < _max; i++)
        {
            cumulativeProbability += probabilities[i];
            if (randomValue < cumulativeProbability)
            {
                return i;
            }
        }

        return 0;
    }

    private float[] CalculateProbabilities()
    {
        float[] probabilities = new float[_max];
        float totalProbability = 0;

        for (int i = 0; i < _max; i++)
        {
            probabilities[i] = 1.0f / (i + 1);
            totalProbability += probabilities[i];
        }

        return NormalizeProbabilities(probabilities, totalProbability);
    }

    private float[] NormalizeProbabilities(float[] probabilities, float totalProbability)
    {
        for (int i = 0; i < _max; i++)
        {
            probabilities[i] /= totalProbability;
        }
        return probabilities;
    }
}

