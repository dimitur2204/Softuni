function encodeAndDecodeMessages() {
	const encodeAndDecodeBtns = document.querySelectorAll('button');
	const encodeAndDecodeText = document.querySelectorAll('textarea');
	const encodeArea = encodeAndDecodeText[0];
	const decodeArea = encodeAndDecodeText[1];
	const encodeBtn = encodeAndDecodeBtns[0];
	const decodeBtn = encodeAndDecodeBtns[1];
	encodeBtn.addEventListener('click', encodeMsg);
	decodeBtn.addEventListener('click', decodeMsg);
	function encodeMsg(e) {
		const initialMsg = encodeArea.value;
		let encodedMsg = '';
		for (let index = 0; index < initialMsg.length; index++) {
			encodedMsg += String.fromCharCode(initialMsg.charCodeAt(index) + 1);
		}
		decodeArea.value = encodedMsg;
		encodeArea.value = '';
	}
	function decodeMsg(e) {
		const encodedMsg = decodeArea.value;
		let decodedMsg = '';
		for (let index = 0; index < encodedMsg.length; index++) {
			decodedMsg += String.fromCharCode(encodedMsg.charCodeAt(index) - 1);
		}
		decodeArea.value = decodedMsg;
	}
}
