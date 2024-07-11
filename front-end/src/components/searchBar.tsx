import React, { useState } from 'react';
import { useRestaurantContext } from '../context/RestaurantContext';
import './searchBar.css'

function SearchBar() {
  const { fetchRestaurants } = useRestaurantContext();
  const [searchTerm, setSearchTerm] = useState('');

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };

  const handleKeyDown = async (event: React.KeyboardEvent<HTMLInputElement>) => {
    if (event.key === 'Enter') {
      try {
        await fetchRestaurants({ name: searchTerm });
      } catch (error) {
        console.error('Error searching restaurants:', error);
      }
    }
  };

  const handleButtonClick = async () => {
    try {
      await fetchRestaurants({ name: searchTerm });
    } catch (error) {
      console.error('Error searching restaurants:', error);
    }
  };

  const handleClearClick = async () => {
    setSearchTerm('');
    try {
      await fetchRestaurants({});
    } catch (error) {
      console.error('Error fetching all restaurants:', error);
    }
  };

  return (
    <div className="search-bar-container">
      <input
        id="search-bar"
        type="text"
        name="search-bar"
        placeholder="Busque por item ou restaurante"
        value={searchTerm}
        onChange={handleInputChange}
        onKeyDown={handleKeyDown}
        className="search-input"
      />
      <button className="search-button" onClick={handleButtonClick}>Buscar</button>
      <button className="search-clear-button" onClick={handleClearClick}>Limpar</button>
    </div>
  );
}

export default SearchBar;
