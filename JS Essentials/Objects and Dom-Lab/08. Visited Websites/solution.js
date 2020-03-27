function solve() {
  let siteElements = document.getElementsByClassName("link-1");
  for (let siteElement in siteElements) {
    siteElements[siteElement].addEventListener("click", (e) =>{
      let paragraph = e
      .currentTarget
      .getElementsByTagName("p")[0];
      let text = paragraph.textContent;
      let textParts = text.split(" ");
      let clicks = Number(textParts[1]);
      clicks++;
      textParts[1] = clicks;
      paragraph.textContent = textParts.join(" ");
    });
  }
}