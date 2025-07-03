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
  const dropdownRef = useRef(null);

;

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
      
    };
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  return (
    <nav className="w-full px-4 py-3 bg-white shadow-md border-b border-gray-100 fixed top-0 left-0 z-50 flex-wrap">
      <div className="max-w-7xl mx-auto flex items-center justify-between relative">
        {/* Left: Contact Us & Location */}
        <div className="flex items-center gap-6 flex-1">
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

        {/* Center: Logo */}

        <div className="absolute left-1/2 transform -translate-x-1/2">
          <Link to="/admin">
            <img src={logo} alt="Logo" className="h-20 w-auto" />
          </Link>
        </div>

        {/* Right: Profile + Manager */}
        <div className="flex items-center gap-6 justify-end flex-1">
          {/* Profile Dropdown */}
          <div className="relative" ref={dropdownRef}>
            <button
              onClick={() => setOpenDropdown((prev) => !prev)}
              className="flex items-center gap-2 focus:outline-none rounded-2xl"
            >
              <UserCircleIcon className="w-10 h-10 text-gray-600 hover:text-[#DA6868]" />
            </button>

            {/* Dropdown */}
            <div
              className={`absolute right-0 mt-2 w-40 bg-white border border-gray-200 rounded-lg shadow-lg z-50 transition-all duration-200 origin-top transform ${
                openDropdown
                  ? "scale-100 opacity-100"
                  : "scale-95 opacity-0 pointer-events-none"
              }`}
            >
              <Link
                to="/adminprofile"
                className="block px-4 py-2 text-gray-700 hover:bg-gray-100"
              >
                Profile
              </Link>
              <Link to="#" className="block px-4 py-2 text-gray-700 hover:bg-gray-100">
              Manager 
              </Link>
              <button
                onClick={handleLogout}
                className="w-full text-left block px-4 py-2 text-red-600 hover:bg-red-100"
              >
                Logout
              </button>
            </div>
          </div>
        </div>
      </div>
    </nav>
  );
}
