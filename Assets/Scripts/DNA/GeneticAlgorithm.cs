using System.Collections;
using System.Collections.Generic;
using System;

public class GeneticAlgorithm<T> 
{
    public List<DNA<T>> Population { get; private set; }
    public int Generation { get; private set; }
    public float MutationRate;
    public float BestFitness { get; private set; }
    public T[] BestGenes { get; private set; }

    private Random _random;
    private float _fitnessSum;

    public GeneticAlgorithm(int populationSize, int dnaSize, Random random, Func<T> getRandomGene, Func<float, int> fitnessFunction, float mutaionRate = 0.01f)
    {
        Generation = 1;
        MutationRate = mutaionRate;
        Population = new List<DNA<T>>();
        _random = random;

        for (int i = 0; i < populationSize; i++)
        {
            Population.Add(new DNA<T>(dnaSize, random, getRandomGene, fitnessFunction, shouldInitGenes: true));
        }

    }

    public void NewGeneration()
    {
        if(Population.Count <= 0)
            return;
        
        CalculateFitness();
        List<DNA<T>> newPopulation = new List<DNA<T>>();

        for (int i = 0; i < Population.Count; i++)
        {
            DNA<T> parent1 = ChooseParent();
            DNA<T> parent2 = ChooseParent();

            DNA<T> child = parent1.Crossover(parent2);
            child.Mutate(MutationRate);
            
            newPopulation.Add(child);
        }

        Population = newPopulation;
        Generation++;
    }

    public void CalculateFitness()
    {
        _fitnessSum = 0;
        DNA<T> best = Population[0];
        
        for (int i = 0; i < Population.Count; i++)
        {
            _fitnessSum += Population[i].CalculateFitness(i);

            if(Population[i].Fitness > best.Fitness)
            {
                best = Population[i];   
            }
        }

        BestFitness = best.Fitness;
        best.Genes.CopyTo(BestGenes, 0);
    }

    private DNA<T> ChooseParent()
    {
        double randomNumber = _random.NextDouble() * _fitnessSum;
        
        for (int i = 0; i < Population.Count; i++)
        {
            if(randomNumber < Population[i].Fitness)
            {
                return Population[i];
            }
            randomNumber -= Population[i].Fitness;
        }

        return null;    
    }
}
