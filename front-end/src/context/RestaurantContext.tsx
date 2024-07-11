import React, { createContext, useState, useContext, ReactNode } from "react";
import { Restaurant } from "../models/restaurant.model";
import { restaurantService } from "../services/restaurant-service";

interface GetAllParams {
  name?: string;
  category?: string;
}

interface RestaurantContextType {
  restaurants: Restaurant[] | null;
  restaurant: Restaurant | null;
  fetchRestaurants: (params?: GetAllParams) => Promise<void>;
  getRestaurantById: (id: string) => Promise<void>;
}

const RestaurantContext = createContext<RestaurantContextType | undefined>(
  undefined
);

export const useRestaurantContext = () => {
  const context = useContext(RestaurantContext);
  if (!context) {
    throw new Error(
      "useRestaurantContext must be used within a RestaurantProvider"
    );
  }
  return context;
};

export const RestaurantProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  const [restaurants, setRestaurants] = useState<Restaurant[] | null>(null);
  const [restaurant, setRestaurant] = useState<Restaurant | null>(null);

  const fetchRestaurants = async (params?: GetAllParams): Promise<void> => {
    try {
      const data = await restaurantService.GetAll(params);
      setRestaurants(data);
    } catch (error) {
      console.error("Error fetching items:", error);
      throw error;
    }
  };

  const getRestaurantById = async (id: string): Promise<void> => {
    try {
      const restaurant = await restaurantService.getById(id);
      setRestaurant(restaurant);
    } catch (error) {
      console.error(`Error fetching restaurant with id ${id}:`, error);
      throw error;
    }
  };

  return (
    <RestaurantContext.Provider
      value={{ restaurants, restaurant, fetchRestaurants, getRestaurantById }}
    >
      {children}
    </RestaurantContext.Provider>
  );
};
