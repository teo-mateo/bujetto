/**
 * Created by Heapzilla on 10/8/2016.
 */

export default class Category{
    constructor(id, name, selected, onToggleSelection){
        this.id = id;
        this.name = name;
        this.selected = selected;
        this.onToggleSelection = onToggleSelection;
    }

    toggleSelection(id){
        this.selected = !this.selected;
        if(this.onToggleSelection !== undefined){
            this.onToggleSelection(this.id);
        }
    }

}