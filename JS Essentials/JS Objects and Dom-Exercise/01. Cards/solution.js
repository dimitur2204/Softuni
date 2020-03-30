function solve() {
   let playersCardsDiv = document.getElementsByClassName("cards")[0];
   let playersCards = playersCardsDiv.getElementsByTagName("img");  
   for (const card of playersCards) {
      card.addEventListener("click",function(){
         let cardSource = card.getAttribute("src");
         cardSource = "images/whiteCard.jpg";
         card.setAttribute("src",cardSource);
         let  resultDiv = document.getElementById("result");
         
         if (card.parentElement.id == "player1Div") {
           let cardName = card.getAttribute("name");
           
         }
         else{

         }
      });
   }
}