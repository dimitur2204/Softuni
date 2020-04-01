function solve() {
   var sendButton = document.getElementById("send");
   var textDiv = document.getElementById("chat_input");
   var chatDiv = document.getElementById("chat_messages");
   sendButton.addEventListener("click", function (){
      var newMessageDiv = document.createElement("div");
      newMessageDiv.className = "message my-message";
      newMessageDiv.innerHTML = textDiv.value;
      chatDiv.appendChild(newMessageDiv);
      textDiv.value = "";
   });
}


