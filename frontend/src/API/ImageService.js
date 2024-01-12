import axios from "axios"

const baseUrl = 'http://localhost:5178/ImageViewer'

export default class ImageService {
    static async getImageList() {
        return await axios.get(`${baseUrl}/images`)
    }

    static async UploadImage(requestData) {
        return await axios.post(`${baseUrl}/images`, 
        requestData,
        {
            headers: {'Content-Type': 'multipart/form-data'}
        })
    }

    static async GetImageData(id) {
        return await axios.get(`${baseUrl}/images/${id}`)
    }

    static async UpdateImage(id, data) {
        return await axios.put(`${baseUrl}/images/${id}`, data)
    }

    static async DeleteImage(id) {
        return await axios.delete(`${baseUrl}/images/${id}`)
    }

}