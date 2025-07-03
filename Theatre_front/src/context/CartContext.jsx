import { createContext, useContext, useEffect, useState } from "react";
import { getUser } from "../API/user"; // adjust path as needed

const CartContext = createContext();
export const useCart = () => useContext(CartContext);

export default function CartProvider({ children }) {
  const [cartItems, setCartItems] = useState([]);
  const [userId, setUserId] = useState(null);

  // ✅ Step 1: Fetch user ID on first load
  useEffect(() => {
    const fetchUserId = async () => {
      try {
        const user = await getUser();
        setUserId(user.id); // Make sure this matches your backend's user object
      } catch (err) {
        console.error("CartContext: Failed to fetch user:", err.message);
      }
    };

    fetchUserId();
  }, []);

  // ✅ Step 2: Load cart from localStorage for that user
  useEffect(() => {
    if (userId) {
      const stored = localStorage.getItem(`cart_${userId}`);
      if (stored) {
        setCartItems(JSON.parse(stored));
      }
    }
  }, [userId]);

  // ✅ Step 3: Save cart to localStorage on changes
  useEffect(() => {
    console.log("Saving cart:", cartItems, "for user:", userId);
    if (userId) {
      localStorage.setItem(`cart_${userId}`, JSON.stringify(cartItems));
    }
  }, [cartItems, userId]);

  // ✅ Add item to cart
  const addToCart = (item) => {
    setCartItems((prev) => [...prev, item]);
  };

  // ✅ Calculate total price
  const total = cartItems.reduce((sum, item) => sum + item.price * item.count, 0);

  return (
    <CartContext.Provider value={{ cartItems, addToCart, total, setCartItems }}>
      {children}
    </CartContext.Provider>
  );
}
