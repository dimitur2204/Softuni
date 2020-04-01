function solve() {
   let table = document.getElementsByTagName("table")[0];
   let rows = table.getElementsByTagName("tr");
   let inputDiv = document.getElementById("searchField");
   let button = document.getElementById("searchBtn");
   button.addEventListener("click", e =>{
      
      for (let index = 2; index < rows.length; index++) {
         const row = rows[index];
         row.className = "";         
      }
      for (let index = 2; index < rows.length; index++) {
         const row = rows[index];
         let cells = row.getElementsByTagName("td");
         for (const cell of cells) {
            if(cell.innerHTML.includes(inputDiv.value)){
               row.className = "select";
            }
         }
      }
      inputDiv.value = "";
   });
}