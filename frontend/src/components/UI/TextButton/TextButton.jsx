import React from 'react';
import './TextButton.css'

const TextButton = ({children, ...props}) => {
    return (
        <button {...props} className='textButton'>
            {children}
        </button>
      );
}
 
export default TextButton;