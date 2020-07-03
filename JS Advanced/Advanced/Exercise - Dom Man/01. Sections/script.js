function create(words) {
   const contentDiv = document.querySelector('#content');
   for (const word of words) {
      const div = document.createElement('div');
      const p = document.createElement('p');
      p.innerText = word;
      p.style.display = 'none';
      div.addEventListener('click',(e)=>{
         e.currentTarget.children[0].style.display = '';
      });
      div.appendChild(p);
      contentDiv.appendChild(div);
   }
}