// -- init

﻿string secret = "hydrochlorid";
bool[] guesses = new bool['z'-'a']; // false -> has not been guessed

// helpers

int char2int (char c) {
  return c-'a';
}

char int2char (int i) {
  return (char)(((int)'a')+i);
}

void print_status () {
  Console.Write("Word: ");
  for (int i=0 ; i<secret.Length ; i++) {
    char c = secret[i];
    Console.Write(( guesses[char2int(c)] ? c : '*'));
  }
  Console.WriteLine("");
}

// -- main

while (true) {
  print_status();
  
  Console.WriteLine("Give us a guess: ");
  string? input = Console.ReadLine();
  if (input==null || input.Length!=1) {
    Console.WriteLine("Error: Input should be 1 long");
    continue;
  }
  char c = Char.ToLower(input[0]);
  if (c<'a' || c>'z') {
    Console.WriteLine("Only letters acceptable");
    continue;
  }
  Console.WriteLine(c);
  
  guesses[char2int(c)] = true;
}

