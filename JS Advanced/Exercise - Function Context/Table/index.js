function solve(){
   //#413f5e
   function getChildren(n, skipMe){
      var r = [];
      for ( ; n; n = n.nextSibling ) 
         if ( n.nodeType == 1 && n != skipMe)
            r.push( n );        
      return r;
  };
  
  function getSiblings(n) {
      return getChildren(n.parentNode.firstChild, n);
  }
   const tbody = document.querySelector('tbody');
   console.log(tbody);
   tbody.addEventListener('click', changeStyle);
   function changeStyle(e) {
      const target = e.target;  
      const targetParent =  target.parentNode;
      if (target.tagName == 'TD' && targetParent.style.backgroundColor !== 'rgb(65, 63, 94)') {
         getSiblings(targetParent).map(removeStyles);   
         targetParent.style.backgroundColor = '#413f5e';
      }
      else{
   targetParent.style.backgroundColor = '';
      };
   }
   function removeStyles(element) {
      element.style.backgroundColor = '';
   }
}
