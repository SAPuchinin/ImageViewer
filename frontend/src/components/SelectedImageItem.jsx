import React from "react";
import {dateFormat} from "../utils/time";
import IconButton from "./UI/IconButton/IconButton";
import IMAGES from "../img/images";

const SelectedImageItem = (props) => {

    const editClick = (e) => {
        e.stopPropagation()
        props.edit(props.image)
    }

    const deleteClick = (e) => {
        e.stopPropagation()
        props.delete(props.image.id)       
    }

    return (
        <div className="selectedImageItem">
            <div>
                <h3>{props.image.name}</h3>
                <plaintext>{props.image.description}</plaintext>
                <p><small>Loaded <i>{dateFormat(props.image.uploadTime)}</i></small></p>                
            </div>
            <div className="buttons">
                <IconButton onClick={editClick} image={IMAGES.edit} title="Edit image"/>
                <IconButton onClick={deleteClick} image={IMAGES.delete} title="Delete image"/>
            </div>
        </div>
    )
}

export default SelectedImageItem;