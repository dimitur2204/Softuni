function solve() {
    let dict = {};
    let args = [...arguments];
    for (let argument of args) {
        if (typeof argument == "object") {
            console.log(typeof argument + ": ");
            argument = '';
        }
        else{
            console.log(typeof argument + ": " + argument);
        }
        if (dict.hasOwnProperty(typeof argument)) {
            dict[typeof argument]++;
        }
        else
        {
            dict[typeof argument] = 1; 
        }
    }
    for (const key in dict) {
            const element = dict[key];
            console.log(key + " = " + element);   
    }
}
solve({ name: 'bob'}, 3.333, 9.999);