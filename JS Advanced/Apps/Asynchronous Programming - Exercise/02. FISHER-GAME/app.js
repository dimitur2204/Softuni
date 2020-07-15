import * as data from "./data.js";
const loadBtn = document.querySelector(".load");
const addBtn = document.querySelector(".add");
const addForm = document.querySelector("#addForm");
const catchesDiv = document.querySelector("#catches");
const getEntryInfo = (element) => {
	const angler = element.querySelector(".angler").value;
	const weight = Number(element.querySelector(".weight").value);
	const species = element.querySelector(".species").value;
	const location = element.querySelector(".location").value;
	const bait = element.querySelector(".bait").value;
	const captureTime = Number(element.querySelector(".captureTime").value);
	return {
		angler,
		weight,
		species,
		location,
		bait,
		captureTime,
	};
};
const deleteEntry = (e) => {
	const parentDiv = e.currentTarget.parentNode;
	const id = parentDiv["data-id"];
	data.deleteCatch(id);
	parentDiv.remove();
};
const updateEntry = (e) => {
	const parentDiv = e.currentTarget.parentNode;
	const updatedCatch = getEntryInfo(parentDiv);
	console.log(updatedCatch);
	data.updateCatch(parentDiv["data-id"], updatedCatch);
};
const loadEntries = async () => {
	catchesDiv.innerHTML = "";
	const entries = await data.getCatches();
	Object.entries(entries || {}).forEach(([key, entry]) => {
		const entryDiv = document.createElement("div");
		entryDiv.classList.add("catch");
		entryDiv["data-id"] = key;
		entryDiv.innerHTML = `<label>Angler</label>
        <input type="text" class="angler" value="${entry.angler}">
        <hr>
        <label>Weight</label>      
        <input type="number" class="weight" value="${entry.weight}">
        <hr>
        <label>Species</label>
        <input type="text" class="species" value="${entry.species}">
        <hr>
        <label>Location</label>
        <input type="text" class="location" value="${entry.location}">
        <hr>
        <label>Bait</label>
        <input type="text" class="bait" value="${entry.bait}">
        <hr>
        <label>Capture Time</label>
        <input type="number" class="captureTime" value="${entry.captureTime}">
        <hr>
    `;
		const updateBtn = document.createElement("button");
		updateBtn.classList.add("update");
		updateBtn.innerHTML = "UPDATE";
		const deleteBtn = document.createElement("button");
		deleteBtn.innerHTML = "DELETE";
		updateBtn.classList.add("delete");
		deleteBtn.addEventListener("click", deleteEntry);
		updateBtn.addEventListener("click", updateEntry);
		deleteBtn.classList.add("delete");
		entryDiv.appendChild(updateBtn);
		entryDiv.appendChild(deleteBtn);
		catchesDiv.appendChild(entryDiv);
	});
};
const addEntries = () => {
	const catchData = getEntryInfo(addForm);
	data.createCatch(catchData);
};
function attachEvents() {
	loadBtn.addEventListener("click", loadEntries);
	addBtn.addEventListener("click", addEntries);
}

attachEvents();
