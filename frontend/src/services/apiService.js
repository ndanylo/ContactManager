import axios from "axios";
import config from "../config.json";

const API_URL = config.API_URL;

const apiService = {
  async createContact(contact) {
    try {
      const response = await axios.post(API_URL, contact);
      return response.data;
    } catch (error) {
      throw error.response.data;
    }
  },

  async uploadCsv(formData) {
    try {
      const response = await axios.post(`${API_URL}/upload-csv`, formData, {
        headers: { "Content-Type": "multipart/form-data" },
      });
      return response.data;
    } catch (error) {
      throw error.response.data;
    }
  },

  async updateContact(contact) {
    try {
      const response = await axios.put(`${API_URL}/${contact.id}`, contact);
      return response.data;
    } catch (error) {
      throw error.response.data;
    }
  },

  async deleteContact(id) {
    try {
      await axios.delete(`${API_URL}/${id}`);
    } catch (error) {
      throw error.response.data;
    }
  },

  async getAllContacts() {
    try {
      const response = await axios.get(API_URL);
      return response.data;
    } catch (error) {
      throw error.response.data;
    }
  },

  async getContactById(id) {
    try {
      const response = await axios.get(`${API_URL}/${id}`);
      return response.data;
    } catch (error) {
      throw error.response.data;
    }
  },
};

export default apiService;
