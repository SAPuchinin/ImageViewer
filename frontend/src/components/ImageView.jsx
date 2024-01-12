import React, { useEffect, useRef, useState } from 'react';
import ModalForm from './UI/ModalForm/ModalForm';
import Comments from './Comments';
import CommentForm from './CommentForm';
import CommentService from '../API/CommentService';
import ToggleButton from './UI/ToggleButton/ToggleButton';
import IMAGES from '../img/images';
import IconButton from './UI/IconButton/IconButton';

const ImageView = ({image}) => {

    const [imageSrc, setImageSrc] = useState('')
    const [imageSize, setImageSize] = useState({'width':0, 'height': 0})
    const [addingComment, setAddingComment] = useState(false)
    const [commentFormActive, setCommentFormActive] = useState(false)
    const [commentFormData, setCommentFormData] = useState({comment: null, buttonName: '', handle: null})
    const [comments, setComments] = useState([])

    var clickedPoint = null

    const imgRef = useRef()
    const areaRef = useRef()

    const resizeHandler = () => {
        if(image?.data != null) {
            setImageSize({'width': imgRef.current.width, 'height': imgRef.current.height})
        }
      };

    useEffect(() => {
        const imageElement = imgRef?.current;
    
        if (!imageElement) 
            return
        
        const observer = new ResizeObserver(resizeHandler)
        observer.observe(imageElement);
        return () => {
          observer.disconnect();
        };
      }, [])

    const getImageSrc = () => {
        if(image?.data != null)
        {
            const url = 'data:' + image.type + ';base64,' + image.data
            let img = new Image()
            img.onload = () => {
                const areaWidth = areaRef.current.offsetWidth
                const areaHeight = areaRef.current.offsetHeight
                const imageWidth = img.width
                const imageHeight = img.height                
                var width = img.width
                var height = img.height 
                if(imageWidth > areaWidth) {
                    if (imageHeight > areaHeight) {
                        const xRatio = imageWidth / areaWidth
                        const yRatio = imageHeight / areaHeight
                        if(xRatio > yRatio) {
                            width = areaWidth
                            height = imageHeight / xRatio
                        }
                        else {
                            width = imageWidth / yRatio
                            height = areaHeight
                        }
                    }
                    else {
                        const xRatio = imageWidth / areaWidth
                        width = areaWidth
                        height = imageHeight / xRatio
                    }
                }
                else if (imageHeight > areaHeight) {
                    const yRatio = imageHeight / areaHeight
                    width = imageWidth / yRatio
                    height = areaHeight
                }
                setImageSize({'width': width, 'height': height})
                setImageSrc(url)  
                setComments(image.comments) 
            }
            img.src = url                     
        }
    }

    useEffect(getImageSrc, [image])

    const onImageClick = (e) => {
        e.stopPropagation()
        if(addingComment) {
            const x = (e.clientX - e.target.offsetParent.offsetLeft) / imageSize.width
            const y = (e.clientY - e.target.offsetParent.offsetTop) / imageSize.height
            clickedPoint = ({x: x, y: y})
            setCommentFormData({comment: null, buttonName: 'Add', handle: handleAddComment})
            setCommentFormActive(true);

        }
    }

    const handleAddComment = async (commentText) => {
        const createCommentRequest = {
            imageId: image.id,
            text: commentText,
            left: clickedPoint.x,
            top: clickedPoint.y
        }
        await CommentService.AddComment(createCommentRequest).then(
            (response) => {  
                setComments([...comments, response.data])
            }
        )
        .catch((e) => {
            console.log(e.message)
        })
        setCommentFormActive(false);
    }

    const handleUpdateComment = async (commentId, commentText) => {
        await CommentService.UpdateComment(commentId, {text: commentText}).then(
            (response) => {
                if (response.data) {
                    var comment = comments.find(c => c.id === commentId)
                    comment.text = commentText
                }
            }
        )
        .catch((e) => {
            console.log(e.message)
        })
        setCommentFormActive(false);
    }

    const selectComment = (e) => {
        e.stopPropagation();
        
        const comment = comments.find(c => c.id === e.target.id)
        setCommentFormData({comment: comment, buttonName : 'Update', handle : handleUpdateComment})
        setCommentFormActive(true);
    }

    const handleDelete = async (commenId) =>{
        await CommentService.DeleteComment(commenId).then(
            (response) => {
                setComments(comments.filter(c => c.id !== commenId))
            }
        )
        .catch((e) => {
            console.log(e.message)
        })
        setCommentFormActive(false);
    }

    const deleteAllComments = async () => {
        if(window.confirm('You want remove all comments for this image?'))
        {
            await CommentService.DeleteAllComments(image.id).then(
                (response) => {
                    setComments([])
                }
            )
            .catch((e) => {
                console.log(e.message)
            }) 
        }
    }
    return (         
        <div className='imageView'>
            <div className='imageToolbar'>
                <ToggleButton state={addingComment} setState={setAddingComment} image={IMAGES.addComment} title='Adding comments'/>
                <IconButton image={IMAGES.deleteAll} title='Delete all comments' onClick={deleteAllComments} disabled={!(image?.comments.length > 0)}/>
            </div>
            <div className='imageArea' ref={areaRef}>
  
                <img ref={imgRef} src={imageSrc} onClick={onImageClick} />
 
                {comments.length > 0 &&
                    <Comments comments={comments} imageSize={imageSize} selectComment={selectComment}/>
                }
                </div>
            
            <ModalForm active={commentFormActive} setActive={setCommentFormActive}>
                <CommentForm formData={commentFormData} handleDelete={handleDelete}/>
            </ModalForm>
        </div>
     );
}
 
export default ImageView;