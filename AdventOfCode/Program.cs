// See https://aka.ms/new-console-template for more information


//Day 1:
var caloryCalculator = new DayOne(@"C:\Users\andgrasd\OneDrive - Atea\Documents\Elf calories.txt");
var bestElf = caloryCalculator.GetElfWithTheMost();
Console.WriteLine(bestElf);
var topThreeTotal = caloryCalculator.GetTotalOfTopThree();
Console.WriteLine(topThreeTotal);

////Day 2:
//var game = new DayTwo(@"SomeInputFile");
//game.calculateTotalScore();
//var score = game.getScore();
//Console.WriteLine(score);

////Day 3:
//var rucksack = new DayThree(@"SomeInputFile");
//rucksack.CalculateBadgesTotalSum();
//rucksack.CalculateTotalRucksacksSum();
//Console.WriteLine(rucksack.GetRucksackSum());
//Console.WriteLine(rucksack.GetBadgeSum());

////Day 4:
//var cleanup = new DayFour(@"SomeInputFile");
//cleanup.CalculateOverlappingPairs();
//Console.WriteLine(cleanup.GetOverlappingPairs());
//Console.WriteLine(cleanup.GetAnyOverlap());

////Day 5:
//var supplyStackGame = new DayFive(@"SomeInputFile");
//var stacks = supplyStackGame.GetStacks();
//foreach (var stack in stacks)
//    Console.WriteLine(stack);
//Console.WriteLine();
//Console.WriteLine(supplyStackGame.Answer());


////Day 6:
//var tuner = new DaySix(@"SomeInputFile");
//tuner.FindMarker(14);
//Console.WriteLine(tuner.GetMarker());