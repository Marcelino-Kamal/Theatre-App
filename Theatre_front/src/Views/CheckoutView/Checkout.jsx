import { useCart } from "../../context/CartContext";
import { addOrder } from "../../API/Orders";
import { getUser } from "../../API/user"; 
import { useNavigate } from "react-router-dom";

export default function Checkout() {
  const { cartItems, total, clearCart } = useCart();
  const navigate = useNavigate();
  const handleCheckout = async () => {
    try {
    
      const user = await getUser();
      const userId = user.id; 

      if (!userId) {
        alert("Unable to retrieve user information.");
        return;
      }

    
      const orderData = {
        userId: userId,
        items: cartItems.map(item => ({
          itemId: item.id, 
          count: item.count,
          startDate: item.startDate,
          endDate: item.endDate
        }))
      };

     
      const response = await addOrder(orderData);
      alert(response.message);

      clearCart(); 
      navigate("/dashboard");
    } catch (err) {
      alert(err.message);
    }
  };

  return (
    <div className="min-h-screen bg-[#D2B48C] p-6">
      <h1 className="text-2xl font-bold mb-6">Checkout</h1>
      {cartItems.length === 0 ? (
        <p>Your cart is empty.</p>
      ) : (
        <>
          <div className="space-y-4">
            {cartItems.map((item, i) => (
              <div key={i} className="flex items-center gap-4 p-4 bg-white rounded shadow">
                <img src={item.imageUrl} alt={item.name} className="w-16 h-16 object-cover rounded" />
                <div>
                  <p className="font-semibold">{item.name}</p>
                  <p className="font-semibold">Start date : {item.startDate}</p>
                  <p className="font-semibold">End date : {item.endDate}</p>
                  <p>{item.count} × {item.price} LE</p>
                  <p className="text-red-600 font-bold">Total: {item.count * item.price} LE</p>
                </div>
              </div>
            ))}
          </div>
          <div className="mt-6 text-xl font-bold">Grand Total: {total} LE</div>
          <div className="flex w-full items-center justify-center gap-4 mt-4">
            <button
              onClick={handleCheckout}
              className="bg-black text-white rounded-2xl w-[30%] hover:bg-[#c55050] cursor-pointer"
            >
              Checkout
            </button>
            <button
              onClick={clearCart}
              className="bg-black text-white rounded-2xl w-[30%] hover:bg-[#c55050] cursor-pointer"
            >
              Empty Cart
            </button>
          </div>
        </>
      )}
    </div>
  );
}
