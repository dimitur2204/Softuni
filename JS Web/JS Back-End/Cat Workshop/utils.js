const getType = (url) => {
	if (url.endsWith('css')) {
		return 'text/css';
	} else if (url.endsWith('html')) {
		return 'text/html';
	} else if (url.endsWith('js')) {
		return 'application/javascript';
	} else if (url.endsWith('png')) {
		return 'image/png';
	} else if (url.endsWith('ico')) {
		return 'image/ico';
	}
};
module.exports = {
	getType,
};
