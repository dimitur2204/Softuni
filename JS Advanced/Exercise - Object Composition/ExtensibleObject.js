function createObject() {
	const obj = {
		extend,
	};
	function extend(template) {
		for (const key in template) {
			const element = template[key];
			if (typeof element == 'function') {
				Object.getPrototypeOf(obj)[key] = element;
			} else {
				obj[key] = element;
			}
		}
	}
	return obj;
}
let obj = createObject();
obj.extend({
	extensionMethod: function () {
		console.log('hello');
	},
	extensionProperty: 'someString',
});
console.log(obj);
