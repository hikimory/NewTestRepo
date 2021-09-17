using System.Collections;
using System.Collections.Generic;
using System;

public class DNA<T>
{
    public T[] Genes{ get; private set; }
    public float Fitness{ get; private set; }

    private Random _random;
    private Func<T> _getRandomGene;
    Func<int, float> _fitnessFunction;

    public DNA(int size, Random random, Func<T> getRandomGene, Func<int, float> fitnessFunction, bool shouldInitGenes = true)
    {
        Genes = new T[size];
        _random = random; 
        _getRandomGene = getRandomGene;
        _fitnessFunction = fitnessFunction;

        if(shouldInitGenes)
        {
            for (int i = 0; i < Genes.Length; i++)
            { 
                Genes[i] = _getRandomGene();
            }
        }
    }

    public float CalculateFitness(int index)
    {
        Fitness = _fitnessFunction(index);
        return Fitness;
    }

    public DNA<T> Crossover(DNA<T> otherParent)
    {
        DNA<T> child = new DNA<T>(Genes.Length, _random, _getRandomGene, _fitnessFunction, shouldInitGenes: false);

        for (int i = 0; i < Genes.Length; i++)
        {
            child.Genes[i] = _random.NextDouble() < 0.5f ? Genes[i] : otherParent.Genes[i];
        }

        return child;   
    }

    public void Mutate(float mutationRate)
    {
        for (int i = 0; i < Genes.Length; i++)
        {
            if(_random.NextDouble() < mutationRate)
            {
                Genes[i] = _getRandomGene();
            }
        }
    }
}
