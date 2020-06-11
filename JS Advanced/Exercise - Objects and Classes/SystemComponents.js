"use strict"
function components(input) {
    const catalogue = {};
    while (input.length > 0) {
        const systemInfo = input.shift().split(' | ');
        const system = systemInfo[0];
        const component = systemInfo[1];
        const sub = systemInfo[2];
        if (!catalogue.hasOwnProperty(system)) {
            catalogue[system] = {};
        }
        if (!catalogue[system].hasOwnProperty(component)) {
            catalogue[system][component] = [];
        }
        catalogue[system][component].push(sub);
    }
    const sortedEntries = Object.entries(catalogue).sort((a,b) =>{
        return Object.keys(b[1]).length - Object.keys(a[1]).length || a[0].localeCompare(b[0]);
    }).forEach(([system,component]) => {
        console.log(system);
        Object.entries(component).sort((a,b) =>{
            return b[1].length - a[1].length;
        }).forEach(([name,sub]) =>{
            console.log('|||' + name);
            sub.forEach((el) =>{
                console.log("||||||" + el);
            })
        });
    });
}
components(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security']
);