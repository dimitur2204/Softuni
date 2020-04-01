function solve() {
   let products = [];
   let totalPrice = 0;
   let addButtons = document.getElementsByClassName("add-product");
   let textArea = document.getElementsByTagName("textarea")[0];
   let checkoutButton = document.getElementsByClassName("checkout")[0];
   for (let button in addButtons) {
      addButtons[button].addEventListener("click", e=>{
         let productDiv = e
         .currentTarget
         .parentElement
         .parentElement;
         let price = 
         productDiv
         .getElementsByClassName("product-line-price")[0]
         .innerHTML;
         let productName = 
         productDiv.getElementsByClassName("product-title")[0]
         .innerHTML;
         if (!(products.includes(productName))) {
            products.push(productName);
         }
         totalPrice += Number(price);
         let text = `Added ${productName} for ${price} to the cart.\n`;
         textArea.innerHTML += text;
      });
   }
   checkoutButton.addEventListener("click", e =>{
      
      textArea.innerHTML += `You bought ${products.join(", ")} for ${totalPrice.toFixed(2)}.`;
      for (let button in addButtons) {
         addButtons[button].disabled = true;
      }
      checkoutButton.disabled = true;
   });
}