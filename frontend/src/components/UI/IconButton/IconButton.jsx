import React from 'react';
import './IconButton.css'

const IconButton = (props) => {
    return ( 
        <button className='iconButton' onClick={props.onClick} disabled={props.disabled} >
            <img src={props.image} title={props.title} alt={props.title} />
        </button>
     );
}
 
export default IconButton;