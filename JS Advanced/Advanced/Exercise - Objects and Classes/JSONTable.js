function JSONtoTable(input) {
    let result = '<table>\n';
    while (input.length > 0) {
        const man = JSON.parse(input.shift());
        result += '<tr>\n';
        for (const key of Object.keys(man)) {
            result += '<td>' + man[key] + '</td>\n';
        }
        result += '</tr>\n';
    }
    result += '</table>';
    console.log(result);
}
JSONtoTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
);