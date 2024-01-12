import React from 'react';

const Comments = ({comments, imageSize, selectComment}) => {

    return ( 
        <div>
            {comments.map((comment) => {
                        return (<div id={comment.id} key={comment.id} className='mark' style={{top: comment.top*imageSize.height - 5 + 'px', left: comment.left*imageSize.width -5 + 'px' }} onClick={selectComment}/>)
                    })}
        </div>
     );
}
 
export default Comments;