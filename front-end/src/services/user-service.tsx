import axios from "axios";
import { User } from "../models/login.model";

const API_URL = "http://localhost:11015/api/v1/user";  

interface Login {
  email: string;
  password: string;
}

export const userService = {
  login: async (login: Login): Promise<User> => {
    try {
      const response = await axios.post(`${API_URL}/login`, login);
      return response.data;
    } catch (error) {
      console.error("Error logging in:", error);
      throw error;
    }
  },

 };
