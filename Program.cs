// -- init

﻿string secret = "hydrochlorid";
bool[] guesses = new bool['z'-'a']; // false -> has not been guessed
int lives = 10;

// helpers

int char2int (char c) {
  return c-'a';
}

char int2char (int i) {
  return (char)(((int)'a')+i);
}

void print_status () {
  // guesses
  Console.Write("Guesses: ");
  for (int i=0 ; i<guesses.Length ; i++) {
    if (guesses[i]) {
      Console.Write(int2char(i));
    }
  }
  Console.WriteLine("");
  
  // secret
  Console.Write("Word: ");
  for (int i=0 ; i<secret.Length ; i++) {
    char c = secret[i];
    Console.Write(( guesses[char2int(c)] ? c : '*'));
  }
  Console.WriteLine("");
  
  // lives left
  Console.WriteLine(lives+" lives left");
}

bool done () {
  for (int i=0 ; i<secret.Length ; i++) {
    char c = secret[i];
    if (!guesses[char2int(c)]) return false;
  }
  return true;
}

bool guess_in_secret (int guess) {
  foreach (char c in secret) {
    if (char2int(c) == guess) return true;
  }
  return false;
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
  
  int guess = char2int(c);
  if (guesses[guess]==false && !guess_in_secret(guess)) lives--;
  guesses[guess] = true;
  
  if (done()) {
    Console.WriteLine("Yay!");
    break;
  }
  
  if (lives==0) {
    Console.WriteLine("Oh nooo!!!");
    break;
  }
}

