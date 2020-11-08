abstract class Melon{
    
    public get elementIndex() : number {
        return this.weight * this.melonSort.length;
    }

    toString(){
        return `Element: ${this.element}
        Sort: ${this.melonSort}
        Element Index: ${this.elementIndex}
        `
    }
    
    constructor(public element:string, public weight:number,public melonSort:string) {
        
    }
}

class Watermelon extends Melon{
    constructor(weight:number,melonSort:string) {
        super('Water',weight,melonSort);
    }
}

class Firemelon extends Melon{
    constructor(weight:number,melonSort:string) {
        super('Fire',weight,melonSort);
    }
}

class Earthmelon extends Melon{
    constructor(weight:number,melonSort:string) {
        super('Earth',weight,melonSort);
    }
}

class Airmelon extends Melon{
    constructor(weight:number,melonSort:string) {
        super('Air',weight,melonSort);
    }
}


class Melolemonmelon extends Melon{
    private elements:string[] = ['Water','Fire','Earth','Air']
    morph():void{
        this.element = this.elements.shift()
        this.elements.push(this.element);
    }

    constructor(weight:number,melonSort:string) {
        super('',weight,melonSort);
        this.morph();
    }
}