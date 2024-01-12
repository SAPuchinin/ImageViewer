import React, { useState } from 'react';
import './ToggleButton.css'

const ToggleButton = ({state, setState, image, title}) => {
    
    const [backgroundColor, setBackgroundColor ] = useState('snow')
    
    const onClick = (e) => {
        e.stopPropagation()
        e.preventDefault()
        setState(!state)
        setBackgroundColor(state ? 'snow' : 'lightblue' )
    }

    return ( 
        <button className='toggleButton' onClick={onClick} style={{background : backgroundColor}}>
            <img src={image} title={title} alt={title}/>
        </button>
     );
}
 
export default ToggleButton;