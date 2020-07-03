class List{
    #array = [];
    constructor(){
        this.size = 0;
    }
    add(element){
        this.#array.push(element);
        this.#array.sort((a,b) => {
            return a-b;
        });
        this.size++;
    }
    remove(index){
        if (this.#array.length > 0 && index >= 0 && index < this.#array.length ) {
            this.#array.splice(index,1);
            this.#array.sort((a,b) => {
                return a-b;
            });
            this.size--;   
        }
    }
    get(index){
        if (index >= 0 && index < this.#array.length) {
            return this.#array[index];   
        }
    }
}
let list = new List();
list.add(5);
list.add(3);
list.remove(0);
console.log(list.size);
list.add(1);
console.log(list.size);
