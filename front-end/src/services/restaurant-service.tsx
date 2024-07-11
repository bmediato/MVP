import axios from "axios";
import { Restaurant } from "../models/restaurant.model";

const API_URL = "http://localhost:11015/api/v1/restaurants";

interface GetAllParams {
  name?: string;
  category?: string;
}

export const restaurantService = {
  GetAll: async (params?: GetAllParams): Promise<Restaurant[] | null> => {
    try {
      const response = await axios.get(API_URL, { params });
      return response.data as Restaurant[];
    } catch (error) {
      console.error("Error fetching items:", error);
      throw error;
    }
  },

  getById: async (id: string): Promise<Restaurant | null> => {
    try {
      const response = await axios.get(`${API_URL}/${id}`);
      return response.data as Restaurant;
    } catch (error) {
      if (axios.isAxiosError(error) && error.response?.status === 404) {
        return null;
      }
      console.error(`Error fetching item with ID ${id}:`, error);
      throw error;
    }
  }
};
