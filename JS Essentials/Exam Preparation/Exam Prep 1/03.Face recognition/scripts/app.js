function getData () {
	let inputDiv = document.getElementById("input");
	let text = JSON.parse(inputDiv.getElementsByTagName("textarea")[0].value);
	let criteria = text.pop();
	let peopleIn = document.getElementById("peopleIn").getElementsByTagName("p")[0];
	let blacklist = document.getElementById("blacklist").getElementsByTagName("p")[0];
	let peopleOut = document.getElementById("peopleOut").getElementsByTagName("p")[0];
	for (const personObject of text) {
		let action = personObject.action;
		delete personObject.action;
		let stringPerson = JSON.stringify(personObject);
		console.log(stringPerson);
		console.log(peopleIn.innerHTML);
		if (action == "peopleIn") {
			peopleIn.innerHTML += stringPerson;
		}
		else if(action == "peopleOut"){
			if (!(peopleOut.innerHTML.includes(stringPerson))) {
				if (peopleIn.innerHTML.includes(stringPerson)) {
					peopleIn.innerHTML.replace(stringPerson,"")
				}
				peopleOut.innerHTML += stringPerson;
			}
		}
		else{
			blacklist.innerHTML += stringPerson;
		}
	}
}