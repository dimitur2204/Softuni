import * as load from './loadCanvas.js';
const BASE_URL = `https://api.backendless.com/64D49FD7-3150-FCD4-FF27-7B76EF40E400/A2772637-7B80-47ED-B650-C17BE1C4B72B/data/wildwest`;
const canvas = document.querySelector('#canvas');
const saveBtn = document.querySelector('#save');
const reloadBtn = document.querySelector('#reload');
const addBtn = document.querySelector('#addPlayer');
const playersDiv = document.getElementById('players');
async function startGame(e) {
	canvas.style.display = '';
	saveBtn.style.display = '';
	reloadBtn.style.display = '';
	const playerDiv = e.currentTarget.parentElement;
	const player = await fetch(BASE_URL + `/${playerDiv.key}`).then((res) =>
		res.json()
	);
	load.loadCanvas(player);
	const savePlayer = async () => {
		await fetch(BASE_URL + `/${player.objectId}`, {
			method: 'PUT',
			body: JSON.stringify(player),
		});

		clearInterval(document.getElementById('canvas').intervalId);

		canvas.style.display = 'none';
		saveBtn.style.display = 'none';
		reloadBtn.style.display = 'none';
		loadPlayers();
	};
	const reloadPlayer = async () => {
		player.bullets = 6;
		player.money -= 60;
	};
	reloadBtn.addEventListener('click', reloadPlayer);
	saveBtn.addEventListener('click', savePlayer);
}
const deletePlayer = async (e) => {
	const playerDiv = e.currentTarget.parentElement;
	const id = playerDiv.key;
	fetch(BASE_URL + `/${id}`, {
		method: 'DELETE',
	});
	playerDiv.remove();
};
async function loadPlayers() {
	playersDiv.textContent = 'LOADING...';
	const players = await fetch(BASE_URL).then((res) => res.json());
	playersDiv.textContent = '';
	players.forEach((p) => {
		const playerDiv = document.createElement('div');
		playerDiv.classList.add('player');
		const nameDiv = document.createElement('div');
		nameDiv.textContent = `Name:${p.name}`;
		const moneyDiv = document.createElement('div');
		moneyDiv.textContent = `Money:${p.money}`;
		const bulletsDiv = document.createElement('div');
		bulletsDiv.textContent = `Bullets:${p.bullets}`;
		const playBtn = document.createElement('button');
		playBtn.textContent = 'Play';
		playBtn.addEventListener('click', startGame);
		const deleteBtn = document.createElement('button');
		deleteBtn.textContent = 'Delete';
		deleteBtn.addEventListener('click', deletePlayer);
		playerDiv.appendChild(nameDiv);
		playerDiv.appendChild(moneyDiv);
		playerDiv.appendChild(bulletsDiv);
		playerDiv.appendChild(playBtn);
		playerDiv.appendChild(deleteBtn);
		playerDiv.key = p.objectId;
		playersDiv.appendChild(playerDiv);
	});
}
async function addPlayer() {
	const playerInput = document.querySelector('#addName');
	if (playerInput.value === '') {
		alert('Cannot add a player without a name');
		return;
	}
	const player = {
		name: playerInput.value,
	};
	fetch(BASE_URL, {
		method: 'POST',
		body: JSON.stringify(player),
	});
	playerInput.value = '';
	loadPlayers();
}
async function attachEvents() {
	loadPlayers();
	addBtn.addEventListener('click', addPlayer);
	saveBtn.addEventListener('click', savePlayer);
}
attachEvents();
