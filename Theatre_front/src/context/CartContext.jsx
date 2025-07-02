import { createContext, useContext, useState,useEffect } from "react";

const CartContext = createContext();

export const useCart = () => useContext(CartContext);

export default function CartProvider({ children }) {
  const [cartItems, setCartItems] = useState(() => {
    // Load from localStorage when the app starts
    const stored = localStorage.getItem("cart");
    return stored ? JSON.parse(stored) : [];
  });

  const addToCart = (item) => {
    setCartItems((prev) => [...prev, item]);
  };

  const total = cartItems.reduce(
    (sum, item) => sum + item.price * item.count,
    0
  );
  useEffect(() => {
    localStorage.setItem("cart", JSON.stringify(cartItems));
  }, [cartItems]);

  return (
    <CartContext.Provider value={{ cartItems, addToCart, total }}>
      {children}
    </CartContext.Provider>
  );
}
