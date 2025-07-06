import { useState, useRef, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import logo from "../../assets/logo.png";
import { UserCircleIcon } from "@heroicons/react/24/outline";
import { ShoppingCartIcon as ShoppingCartOutline } from "@heroicons/react/24/outline";
import { ShoppingCartIcon as ShoppingCartSolid } from "@heroicons/react/24/solid";
import { LogOut } from "../../API/Auth";
import { useCart } from "../../context/CartContext";

export default function DashboardNav() {
  const navigate = useNavigate();
  const [openDropdown, setOpenDropdown] = useState(false);
  const [cartOpen, setCartOpen] = useState(false);
  const [menuOpen, setMenuOpen] = useState(false);
  const dropdownRef = useRef(null);
  const cartRef = useRef(null);
  const { cartItems, total } = useCart();

  const handleLogout = async () => {
    try {
      await LogOut();
      navigate("/");
    } catch (error) {
      console.error(error.message);
      alert("Logout failed!");
    }
  };

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
        setOpenDropdown(false);
      }
      if (cartRef.current && !cartRef.current.contains(event.target)) {
        setCartOpen(false);
      }
    };
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  return (
    <>
      {/* Overlay */}
      {menuOpen && (
        <div
          className="fixed inset-0 bg-black opacity-40 z-40"
          onClick={() => setMenuOpen(false)}
        ></div>
      )}

      {/* Sidebar Drawer */}
      <div
        className={`fixed top-0 left-0 h-full w-64 bg-white shadow-lg z-50 transform transition-transform duration-300 ease-in-out ${
          menuOpen ? "translate-x-0" : "-translate-x-full"
        }`}
      >
        <div className="p-4 border-b flex justify-between items-center">
          <h2 className="text-lg font-bold">Menu</h2>
          <button
            onClick={() => setMenuOpen(false)}
            className="text-gray-600 hover:text-[#DA6868]"
          >
            ✕
          </button>
        </div>

        <nav className="flex flex-col p-4 space-y-4">
          <Link to="#" className="text-gray-700 hover:text-[#DA6868]" onClick={() => setMenuOpen(false)}>Contact Us</Link>
          <Link to="#" className="text-gray-700 hover:text-[#DA6868]" onClick={() => setMenuOpen(false)}>Location</Link>
          <Link to="/profile" className="text-gray-700 hover:text-[#DA6868]" onClick={() => setMenuOpen(false)}>Profile</Link>
          <Link to="/myorders" className="text-gray-700 hover:text-[#DA6868]" onClick={() => setMenuOpen(false)}>My Orders</Link>
          <button onClick={handleLogout} className="text-red-600 hover:text-red-800 text-left">Logout</button>
          <Link to="/checkout" className="text-[#DA6868] font-medium hover:underline" onClick={() => setMenuOpen(false)}>
            Go to Cart ({cartItems.length})
          </Link>
        </nav>
      </div>

      <nav className="w-full px-4 py-3 bg-white shadow-md border-b border-gray-100 fixed top-0 left-0 z-30 flex-wrap">
        <div className="max-w-7xl mx-auto flex items-center justify-between relative">
          {/* Hamburger Icon (Mobile Only) */}
          <div className="md:hidden">
            <button
              onClick={() => setMenuOpen(true)}
              className="text-gray-600 hover:text-[#DA6868]"
            >
              <svg
                className="w-8 h-8"
                fill="none"
                stroke="currentColor"
                strokeWidth={2}
                viewBox="0 0 24 24"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  d="M4 6h16M4 12h16M4 18h16"
                />
              </svg>
            </button>
          </div>

          {/* Left Side Nav (Desktop Only) */}
          <div className="hidden md:flex items-center gap-6 flex-1">
            <Link
              to="#"
              className="text-white bg-[#DA6868] rounded-2xl h-10 px-4 flex items-center justify-center font-medium hover:bg-[#c55050] transition"
            >
              Contact Us
            </Link>

            <Link
              to="#"
              className="text-white bg-[#DA6868] rounded-2xl h-10 px-4 flex items-center justify-center font-medium hover:bg-[#c55050] transition"
            >
              Location
            </Link>
          </div>

          {/* Logo (Center) */}
          <div className="absolute left-1/2 transform -translate-x-1/2">
            <Link to="/dashboard">
              <img src={logo} alt="Logo" className="h-20 w-auto" />
            </Link>
          </div>

          {/* Right Side Nav (Desktop Only) */}
          <div className="hidden md:flex items-center gap-6 justify-end flex-1">
            {/* Profile Dropdown */}
            <div className="relative" ref={dropdownRef}>
              <button
                onClick={() => setOpenDropdown((prev) => !prev)}
                className="flex items-center gap-2 focus:outline-none rounded-2xl"
              >
                <UserCircleIcon className="w-10 h-10 text-gray-600 hover:text-[#DA6868]" />
              </button>

              <div
                className={`absolute right-0 mt-2 w-40 bg-white border border-gray-200 rounded-lg shadow-lg z-50 transition-all duration-200 origin-top transform ${
                  openDropdown
                    ? "scale-100 opacity-100"
                    : "scale-95 opacity-0 pointer-events-none"
                }`}
              >
                <Link
                  to="/profile"
                  className="block px-4 py-2 text-gray-700 hover:bg-gray-100"
                >
                  Profile
                </Link>
                <Link
                  to="/myorders"
                  className="block px-4 py-2 text-gray-700 hover:bg-gray-100"
                >
                  My Orders
                </Link>
                <button
                  onClick={handleLogout}
                  className="w-full text-left block px-4 py-2 text-red-600 hover:bg-red-100"
                >
                  Logout
                </button>
              </div>
            </div>

            {/* Cart Icon */}
            <div className="relative" ref={cartRef}>
              <button onClick={() => setCartOpen((prev) => !prev)}>
                {cartItems.length > 0 ? (
                  <ShoppingCartSolid className="w-8 h-8 text-[#DA6868]" />
                ) : (
                  <ShoppingCartOutline className="w-8 h-8 text-gray-600 hover:text-[#DA6868]" />
                )}
              </button>

              {/* Cart Dropdown */}
              {cartOpen && (
                <div className="absolute right-0 mt-2 w-80 bg-white border border-gray-200 rounded-lg shadow-lg z-50 p-4">
                  <h3 className="text-lg font-semibold mb-2">Cart</h3>
                  <div className="max-h-60 overflow-y-auto space-y-3">
                    {cartItems.length === 0 ? (
                      <p className="text-gray-500">Your cart is empty.</p>
                    ) : (
                      cartItems.map((item, i) => (
                        <div
                          key={i}
                          className="flex items-center gap-4 border-b pb-2"
                        >
                          <img
                            src={item.imageUrl}
                            alt={item.name}
                            className="w-12 h-12 object-cover rounded"
                          />
                          <div className="flex-1">
                            <p className="font-medium">{item.name}</p>
                            <p className="text-sm">Qty: {item.count}</p>
                            <p className="text-sm text-[#DA6868] font-semibold">
                              Total: {item.count * item.price} LE
                            </p>
                            <p className="text-sm">Start date: {item.startDate}</p>
                            <p className="text-sm">End date: {item.endDate}</p>
                          </div>
                        </div>
                      ))
                    )}
                  </div>
                  {cartItems.length > 0 && (
                    <div className="mt-4 flex justify-between items-center">
                      <p className="font-bold">Total: {total} LE</p>
                      <Link
                        to="/checkout"
                        className="bg-[#DA6868] text-white px-4 py-2 rounded hover:bg-[#c55050] transition"
                      >
                        Checkout
                      </Link>
                    </div>
                  )}
                </div>
              )}
            </div>
          </div>
        </div>
      </nav>
    </>
  );
}
