function solve(input){
    function getSpeeding(speed){

        if (speed > 40)
        console.log("reckless driving");   
        else if (speed > 20)   
        console.log("excessive speeding");     
        else
        console.log("speeding")
    }
let speed = Number(input.shift());
let area = input.shift();
switch (area) {
        case "motorway":
            if (speed>130) {
                let overTheLimit = speed - 130;
                getSpeeding(overTheLimit)
            }       
        break;
        case "interstate":       
        if (speed>90) {
            let overTheLimit = speed - 90;
            getSpeeding(overTheLimit)
        }   
        break;
        case "city":       
        if (speed>50) {
            let overTheLimit = speed - 50;
            getSpeeding(overTheLimit)
        }   
        break;
        case "residential":       
        if (speed>20) {
            let overTheLimit = speed - 20;
            getSpeeding(overTheLimit)
        }   
        break;
    default:
        break;
}
}
solve([200, 'motorway'])