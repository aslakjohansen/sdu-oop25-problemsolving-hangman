string secret = "hydrochlorid";

Console.WriteLine(secret);

while (true) {
  Console.WriteLine("Give us a guess: ");
  string? input = Console.ReadLine();
  if (input==null || input.Length!=1) {
    Console.WriteLine("Error: Input should be 1 long");
    continue;
  }
  char c = input[0];
  Console.WriteLine(c);
}

