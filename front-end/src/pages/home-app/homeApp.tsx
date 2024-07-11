import React, { useEffect } from "react";
import RestaurantCard from "./components/RestaurantCard";
import Header from "../../components/header";
import { useRestaurantContext } from "../../context/RestaurantContext";
import './homeApp.css'

function HomeApp() {
  const { restaurants, fetchRestaurants } = useRestaurantContext();

  useEffect(() => {
    fetchRestaurants();
  }, []);

  return (
    <div className="home-app-container">
      <Header />
      <RestaurantCard restaurantsData={restaurants} />
    </div>
  );
}

export default HomeApp;
