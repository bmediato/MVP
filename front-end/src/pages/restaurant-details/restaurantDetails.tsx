import React, { useEffect } from "react";
import ProductCard from "./components/productCard";
import RestaurantBanner from "./components/restaurantBanner";
import "./restaurantDetails.css";
import { useRestaurantContext } from "../../context/RestaurantContext";
import { useParams } from "react-router-dom";

function RestaurantDetails() {
  const { restaurant, getRestaurantById } = useRestaurantContext();
  const { id } = useParams<{ id: string }>();

  const fetchRestaurantDetails = async () => {
    if (!id) return;
    try {
      await getRestaurantById(id);
    } catch (error) {
      console.error("Error fetching restaurant details:", error);
    }
  };

  useEffect(() => {
    fetchRestaurantDetails();
  }, [id]);

  return (
    <div className="restaurant-details-container">
      <RestaurantBanner restaurant={restaurant} />
      {restaurant ? (
        <ProductCard products={restaurant.dishes} />
      ) : (
        <p>Carregando...</p>
      )}
    </div>
  );
}

export default RestaurantDetails;
