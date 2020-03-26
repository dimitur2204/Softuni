function solve(steps,footprint,speed){
let distance = steps * footprint;
let metersPerSecond = speed / 3.6;
let time = distance/metersPerSecond;
let seconds = time;
let minutes = 0;
let hours = 0;
minutes+=Math.floor(distance/500);
while(seconds >= 60){
seconds-=60;
minutes++;
}
while(minutes >= 60){
minutes-=60;
hours++;
}
const zeroPad = (num, places) => String(num).padStart(places, '0');
console.log(`${zeroPad(hours,2)}:${zeroPad(minutes,2)}:${zeroPad(Math.round(seconds),2)}`);
}
solve(4000, 0.60, 5);