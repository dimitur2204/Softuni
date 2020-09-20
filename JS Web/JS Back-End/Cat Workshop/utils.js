const getType = (url) => {
	if (url.endsWith('css')) {
		return 'text/css';
	} else if (url.toLowerCase().endsWith('html')) {
		return 'text/html';
	} else if (url.toLowerCase().endsWith('js')) {
		return 'application/javascript';
	} else if (url.toLowerCase().endsWith('png')) {
		return 'image/png';
	} else if (url.toLowerCase().endsWith('ico')) {
		return 'image/ico';
	} else if (url.toLowerCase().endsWith('jpg')) {
		return 'image/jpg';
	} else if (url.toLowerCase().endsWith('jpeg')) {
		return 'image/jpeg';
	}
};
module.exports = {
	getType,
};
