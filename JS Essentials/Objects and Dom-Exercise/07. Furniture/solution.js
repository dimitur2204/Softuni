function solve() {
let objectsArea = document.getElementsByTagName("textarea")[0];
let generateBtn = document.getElementsByTagName("button")[0];
let tableBody = document
.getElementsByTagName("table")[0]
.getElementsByTagName("tbody")[0];
let boughtProducts = [];
let totalPrice = 0;
let totalDecFactor = 0;
let buyButton = document.getElementsByTagName("button")[1];
let outputArea = document.getElementsByTagName("textarea")[1];
generateBtn.addEventListener("click", e=>{
    let objects = objectsArea.value;
    objects = JSON.parse(objects);
    for (const object of objects) {
      let name = object.name;
      let img = object.img;
      let price = object.price;
      let decFactor = object.decFactor;      
      let newRow = document.createElement("tr");
      newRow.insertCell(0);
      newRow.insertCell(0);
      newRow.insertCell(0);
      newRow.insertCell(0);
      newRow.insertCell(0);
      let cells = newRow.getElementsByTagName("td");
      let checkbox1 = document.createElement("input");
      checkbox1.setAttribute("type","checkbox");
      let img1 = document.createElement("img");
      img1.setAttribute("src",img);
      console.log(newRow);
      let imgCell = cells[0];
      let nameCell = cells[1];
      let priceCell = cells[2];
      let decFactorCell = cells[3];
      let markCell = cells[4];
      imgCell.appendChild(img1);
      markCell.appendChild(checkbox1);
      markCell.getElementsByTagName("input")[0]
      .disabled = false;
      imgCell.getElementsByTagName("img")[0]
      .setAttribute("src",img);
      nameCell.innerText = name;
      priceCell.innerText = price;
      decFactorCell.innerText = decFactor;
      tableBody.appendChild(newRow);
    }
  }); 
  buyButton.addEventListener("click", e=>{
    let checkboxes = document.getElementsByTagName("input");
    for (const checkbox of checkboxes) {
      if (checkbox.checked == true) {
        let row = checkbox.parentElement.parentElement.getElementsByTagName("td");
        boughtProducts.push(row[1].innerHTML);
        totalPrice += Number(row[2].innerHTML);
        totalDecFactor += Number(row[3].innerHTML);
      }
    }
    outputArea.innerHTML += `Bought furniture: ${boughtProducts.join(", ")}\n`;
    outputArea.innerHTML += `Total price: ${totalPrice.toFixed(2)}\n`;
    outputArea.innerHTML += `Average decoration factor: ${totalDecFactor/boughtProducts.length}` 
  });
}