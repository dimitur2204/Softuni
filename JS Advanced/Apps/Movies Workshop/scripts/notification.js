const errorNotification = document.querySelector('#errorBox');
const infoNotification = document.querySelector('#infoBox');
const loadingNotification = document.querySelector('#loadingBox');
export const showError = (message) => {
	errorNotification.children[0].innerHTML = message;
	errorNotification.style.display = 'block';
};
errorNotification.addEventListener('click', () => {
	errorNotification.style.display = 'none';
});
export const showInfo = (message) => {
	infoNotification.children[0].innerHTML = message;
	infoNotification.style.display = 'block';
	setTimeout(() => {
		infoNotification.style.display = 'none';
	}, 3000);
};
export const showLoading = () => {
	loadingNotification.style.display = 'block';
};
export const closeLoading = () => {
	loadingNotification.style.display = 'none';
};
