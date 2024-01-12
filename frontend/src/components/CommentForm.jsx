import React, { useEffect, useState } from 'react';
import {dateTimeFormat} from "../utils/time";
import IconButton from './UI/IconButton/IconButton';
import IMAGES from '../img/images';
import ToggleButton from './UI/ToggleButton/ToggleButton';
import TextButton from './UI/TextButton/TextButton';

const CommentForm = ({formData, handleDelete}) => {

    const [commentText, setCommentText] = useState('')
    const [creationTime, setCreationTime] = useState('')
    const [editMode, setEditMode] = useState(false)

    const updateState = () => {
        if(formData.comment != null) {
            setCommentText(formData.comment.text)
            setCreationTime(formData.comment.creationTime)
            setEditMode(false)
        }
        else
        {
            setCommentText('')
            setCreationTime('')
            setEditMode(true)
        }
    }

    useEffect(updateState, [formData])

    const onSubmitClick = (e) => {
       e.preventDefault()
       if(formData.comment != null)
         formData.handle(formData.comment.id, commentText)
       else
         formData.handle(commentText)
       setCommentText('')
       setCreationTime('')
    }

    const onDeleteClick = (e) => {
        e.preventDefault()
        if(window.confirm('You want delete tihs comment?')) {
            handleDelete(formData.comment.id)
            setCommentText('')
            setCreationTime('')
        }
    }

    return (
        <form className="commentForm">
            <div className='comment'>
            <textarea onChange={(e) => {setCommentText(e.target.value)}} value={commentText} placeholder='Input your comment' disabled={!editMode}/>
            {formData.comment &&
                <p>Created at {dateTimeFormat(creationTime)}</p>
            }
            {editMode &&
                <TextButton onClick={onSubmitClick}>{formData.buttonName}</TextButton>
            }   
            </div>
            {formData.comment &&
            <div className='buttons'>
                <ToggleButton state={editMode} setState={setEditMode} image={IMAGES.edit} title='Edit'/>
                <IconButton onClick={onDeleteClick} image={IMAGES.delete} title='Delete'/>
            </div>}
        </form>
      );
}
 
export default CommentForm;