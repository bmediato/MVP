import React, { createContext, useState, useContext, ReactNode, useEffect } from "react";
import { userService } from "../services/user-service";
import { User } from "../models/login.model";

interface LoginParams {
  email: string;
  password: string;
}

interface UserContextType {
  user: User | null;
  login: (loginParams: LoginParams) => Promise<void>;
  logout: () => void;
}

const UserContext = createContext<UserContextType | undefined>(undefined);

export const useUserContext = () => {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error("useUserContext must be used within a UserProvider");
  }
  return context;
};

export const UserProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [user, setUser] = useState<User | null>(() => {
    const storedUser = localStorage.getItem('user');
    return storedUser ? JSON.parse(storedUser) : null;
  });

  useEffect(() => {
    if (user) {
      localStorage.setItem('user', JSON.stringify(user));
    } else {
      localStorage.removeItem('user');
    }
  }, [user]);

  const login = async (loginParams: LoginParams): Promise<void> => {
    try {
      const loggedInUser = await userService.login(loginParams);
      setUser(loggedInUser);
    } catch (error) {
      console.error("Error logging in:", error);
      throw error;
    }
  };

  const logout = () => {
    setUser(null);
  };

  return (
    <UserContext.Provider value={{ user, login, logout }}>
      {children}
    </UserContext.Provider>
  );
};
