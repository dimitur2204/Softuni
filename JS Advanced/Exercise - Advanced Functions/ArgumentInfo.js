function argumentInfo(...params) {
	const arguments = {};
	for (const argument of params) {
		if (!arguments.hasOwnProperty(typeof argument)) {
			arguments[typeof argument] = 0;
		}
		arguments[typeof argument]++;
		console.log(typeof argument + ': ' + argument);
	}
	for (const [key, value] of Object.entries(arguments).sort((a, b) => {
		return b[1] - a[1];
	})) {
		console.log(key + ' = ' + value);
	}
}
argumentInfo({ name: 'bob' }, 3.333, 9.999);
