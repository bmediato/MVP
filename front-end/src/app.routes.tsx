import React from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import RestaurantDetails from "./pages/restaurant-details/restaurantDetails";
import HomeApp from "./pages/home-app/homeApp";
import Login from "./pages/login/Login";

const PrivateRoute: React.FC<{ element: React.ReactNode }> = ({ element }) => {
  const isAuthenticated = localStorage.getItem("user") !== null;

  if (!isAuthenticated) {
    return <Navigate to="/" replace />;
  }

  return <>{element}</>;
};

const AppRouter: React.FC = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route element={<PrivateRoute element={<HomeApp />} />} path="/home" />
        <Route
          element={<PrivateRoute element={<RestaurantDetails />} />}
          path="/restaurante/:id"
        />
      </Routes>
    </BrowserRouter>
  );
};

export default AppRouter;
