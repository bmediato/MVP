import React, { useState } from 'react';
import './Login.css';
import { useUserContext } from '../../context/UserContext';
import { useNavigate } from 'react-router-dom';
import logo from '../../assets/mouth.png';

function Login() {
  const { login } = useUserContext();
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    email: '',
    password: '',
  });
  const [error, setError] = useState<string | null>(null);

  const handleInputChange = ({ target: { value, name } }: React.ChangeEvent<HTMLInputElement>) => {
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleKeyDown = (event: React.KeyboardEvent<HTMLInputElement>) => {
    if (event.key === 'Enter') {
      handleLogin();
    }
  };

  const handleLogin = async () => {
    try {
      await login(formData);
      navigate('/home'); 
    } catch (error) {
      setError('Email ou senha incorretos. Por favor, tente novamente.'); 
      console.error('Error logging in:', error);
    }
  };

  return (
    <div className='login-container'>
       <img src={logo} width='50px' alt="" />
      <h1>Acesse seus restaurantes prediletos</h1>
      <form className='login-form'>
        <input
          type="email"
          name="email"
          placeholder="Email"
          value={formData.email}
          onChange={handleInputChange}
          onKeyDown={handleKeyDown} 
        />
        <input
          className="login-input-password"
          type="password"
          name="password"
          placeholder="Senha"
          value={formData.password}
          onChange={handleInputChange}
          onKeyDown={handleKeyDown} 
        />
        <button type="button" className="login-button-submit" onClick={handleLogin}>
          Entrar
        </button>
        {error && <p className="login-error-message">{error}</p>} 
      </form>
    </div>
  );
}

export default Login;
