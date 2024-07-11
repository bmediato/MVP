import React from "react";
import { useNavigate } from "react-router-dom";
import "./RestaurantCard.css";
import { Restaurant } from "../../../models/restaurant.model";

function RestaurantCard({
  restaurantsData,
}: {
  restaurantsData: Restaurant[] | null;
}) {
  const navigate = useNavigate();

  const handleClick = (restaurantId: string): void => {
     navigate(`/restaurante/${restaurantId}`);
  };

  return (
    <div className="restaurant-card-container">
      {restaurantsData && restaurantsData.length > 0 ? (
        restaurantsData.map((restaurant) => (
          <div
            className="restaurant-card"
            key={restaurant.id}
            onClick={() => handleClick(restaurant.id)}
          >
            <img
              className="restaurant-card-wallpaper"
              src={restaurant.banner}
              alt={restaurant.name}
            />
            <img
              className="restaurant-card-logo"
              src={restaurant.logo}
              alt={restaurant.name}
            />
            <div className="restaurant-card-content">
              <h1 className="restaurant-card-title">{restaurant.name}</h1>
              <p>{restaurant.description}</p>
            </div>
          </div>
        ))
      ) : (
        <div className="no-restaurants">
          <p>Nenhum restaurante encontrado.</p>
        </div>
      )}
    </div>
  );
}

export default RestaurantCard;
