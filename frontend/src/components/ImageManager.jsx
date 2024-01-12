import React, { useState, useEffect } from 'react';
import ImageItem from "./ImageItem";
import UploadImageForm from "./UploadImageForm";
import ModalForm from "./UI/ModalForm/ModalForm";
import ImageService from "../API/ImageService";
//import { useFetching } from "../hooks/useFetching";
import SelectedImageItem from './SelectedImageItem';
import TextButton from './UI/TextButton/TextButton';


const ImageManager = ({currentImage, setImage}) => {
    const [images, setImages] = useState([])
    // const [fetchImages, isImageLoading, imageLoadError] = useFetching(async () => {
    //    await loadImages()
    // })
  
    useEffect( () => {
      loadImages();
    }, [])

    const [uploadFormActive, setUploadFormActive] = useState(false)
    const [uploadFormData, setUploadFormData] = useState({image: null, buttonName: '', handle: null})

    const loadImages = async () => {
      await ImageService.getImageList().then(
        (response) => {
          setImages(response.data)
        }
      )
      .catch((e) => {
        console.log(e.message)
      })
    }

    const handleCreate = async (request) =>
    {
      await ImageService.UploadImage(request).then(
        (response) => {
          setImages([...images, response.data])
        })
      .catch((e) => {
          console.log(e.message)
      })
      setUploadFormActive(false)
    }

    const  handleEdit = async (request) =>
    {
      await ImageService.UpdateImage(request.id, {name: request.name, description: request.description}).then(
        (response) => {
          if (response.data) {
            let image = images.find(i => i.id === request.id)
            image.name = request.name
            image.description = request.description
          }
        })
      .catch((e) => {
          console.log(e.message)
      })
      setUploadFormActive(false)
    }

    const  selectImage = async (imageId) => {
      await ImageService.GetImageData(imageId).then(
        (response) => {
          if(response.data != null)
          {            
              setImage(response.data)
          }
        })
        .catch((e) => {
          console.log(e.message)
      }) 
    }


    const openUploadForm = () => {
      setUploadFormData({image: null, buttonName: 'Upload', handle: handleCreate})
      setUploadFormActive(true)
    }

    const openEditForm = (image) => {
      setUploadFormData({image: image, buttonName: 'Update', handle: handleEdit})
      setUploadFormActive(true)
    }
    
    const deleteImage = async (id) => {
      if(window.confirm('You want delete this image?')) {
        await ImageService.DeleteImage(id)
        .then(
          (response) => {
            setImages(images.filter((im) => im.id !== id))
          })
        .catch((e) => {
          console.log(e.message)
        })       
      }
    }

    return ( 
        <div className='imageManager'>
            <div className="imageList">
                { Array.isArray(images) 
                ? images.map((image) => {
                  return image.id === currentImage?.id
                  ? <SelectedImageItem image={image} key={currentImage.id} edit={openEditForm} delete={deleteImage}/>
                  : <ImageItem image={image} key={image.id} onClick={selectImage} edit={openEditForm} delete={deleteImage}/>
                  })
                : null}
            </div>
            <TextButton onClick={openUploadForm}>Add Image</TextButton>
            <ModalForm active={uploadFormActive} setActive={setUploadFormActive}>
               <UploadImageForm formData={uploadFormData}/>
            </ModalForm>
        </div>
     );
}
 
export default ImageManager;