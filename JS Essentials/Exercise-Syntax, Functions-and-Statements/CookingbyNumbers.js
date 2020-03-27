function solve(input) {
  // •	chop - divide the number by two
  // •	dice - square root of number
  // •	spice - add 1 to number
  // •	bake - multiply number by 3
  // •	fillet - subtract 20% from number
  let number = Number(input.shift());
  let commands = input;
  for (const command in commands) {
    if (commands[command] == "chop") {
      number /= 2;
      console.log(Math.round(number));
    } else if (commands[command] == "dice") {
      number **= 0.5;
      console.log(Math.round(number));
    } else if (commands[command] == "spice") {
      number += 1;
      console.log(Math.round(number));
    } else if (commands[command] == "bake") {
      number *= 3;
      console.log(Math.round(number));
    } else if (commands[command] == "fillet") {
      number *= 80 / 100;
      console.log(Math.round(number));
    }
  }
}
solve(["9", "dice", "spice", "chop", "bake", "fillet"]);
