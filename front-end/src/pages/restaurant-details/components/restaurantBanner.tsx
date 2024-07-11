import React from "react";
import "./restaurantBanner.css";
import { Restaurant } from "../../../models/restaurant.model";
import { useNavigate } from "react-router-dom";
import BackArrow from '../../../assets/back-arrow.png';
function RestaurantBanner({ restaurant }: { restaurant: Restaurant | null }) {
  const navigate = useNavigate();

  const handleClick = (): void => {
    navigate(`/home`);
 };

   return (
    <div className="restaurant-banner-container">
      <img className="restaurant-wallpaper" src={restaurant?.banner} alt="" />
      <img onClick={handleClick} className="restaurant-arrow-back" src={BackArrow} alt="" />
      <img className="restaurant-logo" src={restaurant?.logo} alt="" />
      <div className="restaurant-text">
        <h1>{restaurant?.name}</h1>
        <span>{restaurant?.description}</span>
        <span>{restaurant?.address}</span>
        <span>{restaurant?.phoneNumber}</span>
      </div>
    </div>
  );
}

export default RestaurantBanner;
