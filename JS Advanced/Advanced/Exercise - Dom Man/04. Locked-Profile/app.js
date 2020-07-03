function lockedProfile() {
    const showMoreBtns = Array.from(document.querySelectorAll('button'));
    showMoreBtns.forEach(btn => {
        
        btn.addEventListener('click',extendInfo);
    });
    function extendInfo(e) {
        const parentDiv = e
        .currentTarget
        .parentElement;
        const hiddenDiv = parentDiv.querySelector('div');
        const radioBtns = parentDiv
        .querySelectorAll('input[type = "radio"]');
        const lockedRadioBtn = radioBtns[0];
        if (e.currentTarget.innerText == 'Hide it') {
            console.log(lockedRadioBtn.checked);
            if(lockedRadioBtn.checked === false){
                e.currentTarget.innerText = 'Show more';
               hiddenDiv.style.display = 'none';
          }
        }
        else{
            console.log(hiddenDiv);
           if(lockedRadioBtn.checked === false){
                 e.currentTarget.innerText = 'Hide it';
                hiddenDiv.style.display = 'block';
           }
        }
    }
}