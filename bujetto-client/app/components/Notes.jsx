
import React from 'react';
import Note from './Note.jsx'

// export default ({notes, onEdit}) => {
//     return (
//         <ul>
//             {notes.map(note =>
//                 <li key={note.id}>
//                     <Note task={note.task}
//                           onEdit={onEdit.bind(null, note.id)} />
//                 </li>
//             )}
//         </ul>
//     )
// }

export default class Notes extends React.Component{
    constructor(props){
        super(props);
        let a = 1;
    }
    render(){

        const notes = this.props.notes;
        const onEdit = this.props.onEdit;
        const onDelete = this.props.onDelete;

        return (
            <div>
                <ul className="notes">
                    {notes.map(note =>
                        <li className="note" key={note.id}>
                            <Note
                                task={note.task}
                                onEdit={onEdit.bind(null, note.id)}
                                onDelete={onDelete.bind(null, note.id)}
                            />
                        </li>
                    )}
                </ul>
            </div>
        )
    }
}