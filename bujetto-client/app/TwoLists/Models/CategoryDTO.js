export default class CategoryDTO{
    constructor(id, name, selected){
        if(!arguments.length) {
            this.id = 0;
            this.name = "";
            this.selected = false;
        } else {
            this.id = id;
            this.name = name;
            this.selected = selected;
        }
    }
}