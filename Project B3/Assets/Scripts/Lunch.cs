using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lunch : ScenarioBase
{
    public List<Transform> microwaves;
    List<bool> microwaveUsed;
    public Transform Fridge;
    bool FridgeUsed;
    public List<Transform> Chairs;
    List<bool> ChairUsed;
    public List<Transform> SittingSpots;
    List<bool> SittingSpotUsed;
    public Transform FoodTruck;
    bool FoodTruckUsed;
    public List<Transform> FoodTruckWait;
    List<bool> FoodTruckWaitUsed;
    public Transform InsideRally;
    public Transform OutsideRally;
    public override void StartScenario()
    {
        active = true;
        FridgeUsed = false;
        FoodTruckUsed = false;
        microwaveUsed = Enumerable.Repeat(false, microwaves.Count).ToList();
        ChairUsed = Enumerable.Repeat(false, Chairs.Count).ToList();
        SittingSpotUsed = Enumerable.Repeat(false, SittingSpots.Count).ToList();
        FoodTruckWaitUsed = Enumerable.Repeat(false, FoodTruckWait.Count).ToList();
        targets = new List<string>() { "Male 1(Clone)", "Male 2(Clone)", "Male 3(Clone)", "Male 4(Clone)", "Female 1(Clone)", "Female 2(Clone)", "Female 3(Clone)", "Female 4(Clone)" };
        npcs = GetNPCs();
        foreach (NPC npc in npcs)
        {
            npc.inScenario = true;
            StartCoroutine(GetNextGoal(npc));
        }
    }
    public override void EndScenario()
    {
        StopAllCoroutines();
        active = false;
        foreach (var npc in npcs)
        {
            npc.inScenario = false;
            npc.ChangeGoal();
        }
    }
    public override IEnumerator GetNextGoal(NPC npc)
    {
        switch (npc.lunch)
        {
            case 'G':
            case 'O':
                npc.ChangeGoal(OutsideRally);
                yield return new WaitUntil(() => Vector2.Distance(npc.transform.position, OutsideRally.position) < 1000F);
                while (true)
                {
                    if (!FoodTruckUsed)
                    {
                        npc.ChangeGoal(FoodTruck);
                        FoodTruckUsed = true;
                        yield return new WaitUntil(() => Vector2.Distance(npc.transform.position, FoodTruck.position) < 10F);
                        yield return new WaitForSeconds(5);
                        FoodTruckUsed = false;
                        for (int i = 0; i < SittingSpots.Count; i++)
                        {
                            if (!SittingSpotUsed[i])
                            {
                                npc.ChangeGoal(SittingSpots[i]);
                                SittingSpotUsed[i] = true;
                                yield return new WaitUntil(() => Vector2.Distance(npc.transform.position, SittingSpots[i].position) < 10F);
                                yield return new WaitForSeconds(10);
                                SittingSpotUsed[i] = false;
                                npc.ChangeGoal();
                                yield break;
                            }
                        }
                    }
                    for (int i = 0; i < FoodTruckWait.Count; i++)
                    {
                        if (!FoodTruckWaitUsed[i])
                        {
                            npc.ChangeGoal(FoodTruckWait[i]);
                            FoodTruckWaitUsed[i] = true;
                            yield return new WaitUntil(() => Vector2.Distance(npc.transform.position, FoodTruckWait[i].position) < 10F);
                            yield return new WaitForSeconds(Random.Range(1, 5));
                            FoodTruckWaitUsed[i] = false;
                            break;
                        }
                    }
                }
            case 'I':
            case 'B':
                bool usedfridge = false;
                bool usedmicrowave = false;
                int seat = GetChair();
                npc.ChangeGoal(InsideRally);
                yield return new WaitUntil(() => Vector2.Distance(npc.transform.position, InsideRally.position) < 100F);
                npc.ChangeGoal(Chairs[seat]);
                ChairUsed[seat] = false;
                while (true)
                {
                    if (!FridgeUsed && !usedfridge)
                    {
                        npc.ChangeGoal(Fridge);
                        usedfridge = true;
                        FridgeUsed = true;
                        yield return new WaitUntil(() => Vector2.Distance(npc.transform.position, Fridge.position) < 10F);
                        yield return new WaitForSeconds(5);
                        FridgeUsed = false;
                        npc.ChangeGoal();
                    }
                    if (usedfridge)
                    {
                        while (true)
                        {
                            for (int i = 0; i < microwaves.Count; i++)
                            {
                                if (!microwaveUsed[i])
                                {
                                    npc.ChangeGoal(microwaves[i]);
                                    microwaveUsed[i] = true;
                                    usedmicrowave = true;
                                    yield return new WaitUntil(() => Vector2.Distance(npc.transform.position, microwaves[i].position) < 10F);
                                    yield return new WaitForSeconds(5);
                                    microwaveUsed[i] = false;
                                    break;
                                }
                            }
                            if (usedmicrowave)
                            {
                                npc.ChangeGoal(Chairs[seat]);
                                yield return new WaitUntil(() => Vector2.Distance(npc.transform.position, Chairs[seat].position) < 10F);
                                yield return new WaitForSeconds(5);
                                npc.ChangeGoal();
                                yield break;
                            }
                            yield return new WaitForSeconds(Random.Range(2, 5));
                        }
                    }
                    yield return new WaitForSeconds(Random.Range(2, 5));
                }
        }
        yield break;
    }

    public int GetChair()
    {
        for (int i = 0; i < Chairs.Count; i++)
        {
            if (!ChairUsed[i])
            {
                ChairUsed[i] = true;
                return i;
            }
        }
        return -1;
    }
}