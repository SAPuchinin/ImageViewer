import axios from "axios"

const baseUrl = 'http://localhost:5178/ImageViewer'

export default class CommentService {
    static async AddComment(requestData) {
        return await axios.post(`${baseUrl}/comments`, 
        requestData)
    }

    static async UpdateComment(id, data) {
        return await axios.put(`${baseUrl}/comments/${id}`, data)
    }

    static async DeleteAllComments(imageid) {
        return await axios.delete(`${baseUrl}/images/${imageid}/comments`)
    }

    static async DeleteComment(id) {
        return await axios.delete(`${baseUrl}/comments/${id}`)
    }

}