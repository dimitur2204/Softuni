function solve() {
   let playersCardsDiv = document.getElementsByClassName("cards")[0];
   let playersCards = playersCardsDiv.getElementsByTagName("img");
   let resultDiv = document.getElementById("result");  
   let turnCounter = 0;
   let firstCard;
   for (const card of playersCards) {
      card.addEventListener("click",function(){
         let cardSource = card.getAttribute("src");
         cardSource = "images/whiteCard.jpg";
         let player1Span = resultDiv.getElementsByTagName("span")[0];
         let player2Span = resultDiv.getElementsByTagName("span")[2];
         let historyDiv = document.getElementById("history");
         card.setAttribute("src",cardSource);
         if (card.parentElement.id == "player1Div") {            
            player1Span.innerHTML += card.getAttribute("name");
         }
         else{           
            player2Span.innerHTML += card.getAttribute("name");
         }
         if (turnCounter == 0) {
            firstCard = card;
            turnCounter++;
         }
         else{
            let firstCardValue = Number(firstCard.getAttribute("name"));
            let secondCardValue = Number(card.getAttribute("name"));      
            if (firstCardValue > secondCardValue) {
               card.style.border = "2px solid red";
               firstCard.style.border = "2px solid green";
            }
            else{
               card.style.border = "2px solid green";
               firstCard.style.border = "2px solid red";
            }
            turnCounter=0;
            //[{top side card name} vs {bottom side card name} ]
            historyDiv.innerHTML+=`[${player1Span.innerHTML} vs ${player2Span.innerHTML}]`;
            player1Span.innerHTML = "";
            player2Span.innerHTML = "";
         }
      });
   }
}