import React, { useEffect, useState } from "react";
import TextButton from "./UI/TextButton/TextButton";

const UploadImageForm = ({formData}) => { 

    const [name, setName] = useState('')
    const [description, setDescription] = useState('')

  
    const updateStates = () => {
        if(formData.image != null) {
            setName(formData.image.name)
            setDescription(formData.image.description)
        }
        else
        {
            setName('')
            setDescription('')
        }
    }

    useEffect(updateStates, [formData])


    const onButtonClick = async (e) => {
        e.preventDefault()

        var request = {
            name: name,
            description: description
        }

        if(formData.image == null) {
            var file = document.getElementById('selectedFile').files[0];
            request.file = file
        }
        else
        {
            request.id = formData.image.id
        }

        await formData.handle(request)
    }

    return ( 
        <form className="uploadImageForm">
            {formData.image == null && 
                <input type="file" id="selectedFile" accept="image/png, image/jpeg"/> }
            <input type="text" name="Name" placeholder="Image name" onChange={e => setName(e.target.value)} value={name}/>
            <textarea placeholder="Description" onChange={e => setDescription(e.target.value)} value={description}/>
            <TextButton onClick={onButtonClick}>{formData.buttonName}</TextButton>
        </form>
     );
}
 
export default UploadImageForm;