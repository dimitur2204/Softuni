function solve(input) {
  let x1 = input.shift();
  let y1 = input.shift();
  let x2 = input.shift();
  let y2 = input.shift();
  function check(x1, y1, x2, y2) {
    if (Number.isInteger(Math.sqrt((x2-x1)**2 +(y2-y1)**2))) {
      return true;
    }
    return false;
  }
  if (check(x1, y1, 0, 0)) {
    console.log(`{${x1}, ${y1}} to {${0}, ${0}} is valid`);
  }
  else{
    console.log(`{${x1}, ${y1}} to {${0}, ${0}} is invalid`);
  }

  if (check(x2, y2, 0, 0)) {
    console.log(`{${x2}, ${y2}} to {${0}, ${0}} is valid`);
  }
  else{
    console.log(`{${x2}, ${y2}} to {${0}, ${0}} is invalid`);
  }

  if (check(x1, y1, x2, y2)) {
      console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
  }
  else{
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
  }
}
solve([2, 1, 1, 1]);
