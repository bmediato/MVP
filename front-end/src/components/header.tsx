import React from "react";
import SearchBar from "./searchBar";
import "./header.css"
import { useUserContext } from "../context/UserContext";
import logo from '../assets/mouth.png'

function Header() {

  const { user } = useUserContext();

  const handleLogout = () => {
    localStorage.clear();  
    window.location.reload();  
  };

  return (
    <div className="header-container">
      <img src={logo} width='60px' alt="" />
       <SearchBar />
      <div>
      <p className="header-user-info">Olá {user?.name ?? 'Usuário'}, este é seu endereço ?</p>
      <p>{user?.address ?? 'Endereço não encontrado'}</p>
      <button className="header-logout-button" onClick={handleLogout}>Sair</button>
      </div>
    </div>
  );
}

export default Header;
